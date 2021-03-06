﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class MainForm : Form
	{
		#region Global

		private readonly OpenFileDialog ofd = new OpenFileDialog { InitialDirectory = Extension.Desktop };
		private readonly SaveFileDialog sfd = new SaveFileDialog { InitialDirectory = Extension.Desktop };

		#endregion

		#region Initialization

		public MainForm()
		{
			Application.ThreadException += Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

			if
			(
				!Enum.TryParse<DeviceType>
				(
					Properties.Settings.Default.Device,
					true,
					out var type
				)
			)
				throw new ApplicationException("Unknown device type supplied in app.config.");
			
			GICore.Init(new Spec(type));
			InitializeComponent();
			InitializeDatasetDisplay();
			InitializeDrawing();
			InitializeTraining();
			InitializeTesting();
			InitializeDataset();

			Text += $" [Running on: {Device.Active.Type}]";
		}
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (training || evaluating)
			{
				MessageBox.Show("Cannot close while training or evaluation is in progress.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				e.Cancel = true;
				return;
			}

			RawData.Clean();
			DisposeDatasetDisplay();
			DisposeDrawing();
			DisposeTraining();
			DisposeTesting();
			DisposeDataset();
			GICore.Release();
		}

		#endregion

		#region Dataset Display

		private CategoryChooser categoryChooser = null;

		private ulong current = 0ul;
		private RawData data = null;

		private void InitializeDatasetDisplay()
		{
			categoryChooser = new CategoryChooser();
		}
		private void DisposeDatasetDisplay()
		{
			categoryChooser?.Dispose();
			categoryChooser = null;
		}

		private void DrawCurrent()
		{
			var old = pbPreview.BackgroundImage;

			using (var bmp = new Bitmap((int)RawData.ImageWidth, (int)RawData.ImageHeight, PixelFormat.Format32bppArgb))
			{
				for (var i = 0; i < RawData.ImageHeight; ++i)
				{
					for (var j = 0; j < RawData.ImageWidth; ++j)
					{
						var value = 255 - data[current, i, j];
						bmp.SetPixel(j, i, Color.FromArgb(value, value, value));
					}
				}

				pbPreview.BackgroundImage = bmp.Resize(pbPreview.Width, pbPreview.Height);
			}

			old?.Dispose();
		}

		private void btnLoadData_Click(object sender, EventArgs e)
		{
			var choice = categoryChooser.ShowDialog();
			if (choice == null) return;
			data = RawData.From(choice);
			current = 0ul;
			DrawCurrent();
		}
		private void btnNext_Click(object sender, EventArgs e)
		{
			if (data != null && current < data.ImageCount)
			{
				++current;
				DrawCurrent();
			}
		}
		private void btnPrev_Click(object sender, EventArgs e)
		{
			if (data != null && current > 0ul)
			{
				--current;
				DrawCurrent();
			}
		}

		#endregion

		#region Drawing

		private Bitmap brushPattern = null;
		private Bitmap drawingBmp = null;
		private Graphics drawingGraphics = null;
		private Point lastPoint;

		private Bitmap saved = null;

		private void InitializeDrawing()
		{
			brushPattern = Properties.Resources.BrushPattern;
			drawingBmp = new Bitmap(pbDraw.Width, pbDraw.Height, PixelFormat.Format32bppArgb);
			drawingGraphics = Graphics.FromImage(drawingBmp);
			drawingGraphics.TranslateTransform(-brushPattern.Width / 2, -brushPattern.Height / 2);
			btnClear_Click(this, EventArgs.Empty);
		}
		private void DisposeDrawing()
		{
			drawingBmp.Dispose();
			saved?.Dispose();
			var old = pbSaved.BackgroundImage;
			pbSaved.BackgroundImage = null;
			old?.Dispose();
		}

		private void DrawLine(Point from, Point to, float delta = 1f)
		{
			var f = new PointF(from.X, from.Y);
			var t = new PointF(to.X, to.Y);

			var dist = Extension.Distance(f, t);
			var steps = (uint)Math.Ceiling(dist / delta);
			delta = dist / steps;

			var vec = Extension.Vector(f, t, delta);
			var current = f;

			for (var i = 0u; i <= steps; ++i)
			{
				drawingGraphics.DrawImage(brushPattern, current);
				current = Extension.Add(current, vec);
			}

			pbDraw.Invalidate();
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			drawingGraphics.Clear(Color.White);
			pbDraw.Invalidate();
		}
		private void btnSave_Click(object sender, EventArgs e)
		{
			saved?.Dispose();

			var old = pbSaved.BackgroundImage;

			saved = drawingBmp.Resize((int)RawData.ImageWidth, (int)RawData.ImageHeight);
			pbSaved.BackgroundImage = saved.Resize(pbSaved.Width, pbSaved.Height);
			
			old?.Dispose();
		}

		private void pbDraw_MouseDown(object sender, MouseEventArgs e)
		{
			lastPoint = e.Location;
		}
		private void pbDraw_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			DrawLine(lastPoint, e.Location);
			lastPoint = e.Location;
		}
		private void pbDraw_MouseUp(object sender, MouseEventArgs e)
		{
			DrawLine(lastPoint, e.Location);
		}
		private void pbDraw_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(drawingBmp, 0, 0);
		}

		#endregion

		#region Training

		private NeuralNetwork classifier = null;
		private bool training = false;

		private FitnessFunction func = null;
		private FitnessEditor funceditor = null;

		private BuilderForm builder = null;

		private DateTime? SleepStartTime = null;
		private int SleepTime = 0;

		private void InitializeTraining()
		{
			AI.PointEvaluated += AI_PointEvaluated;
			AI.PopulationEvaluated += AI_PopulationEvaluated;
			AI.SleepStarting += AI_SleepStarting;
			AI.SleepEnded += AI_SleepEnded;

			func = new FitnessFunction();
			funceditor = new FitnessEditor();

			tbFitness.Text = func.ToString();

			builder = new BuilderForm();
		}
		private void DisposeTraining()
		{
			AI.PointEvaluated -= AI_PointEvaluated;
			AI.PopulationEvaluated -= AI_PopulationEvaluated;
			AI.SleepStarting -= AI_SleepStarting;
			AI.SleepEnded -= AI_SleepEnded;

			funceditor?.Dispose();
			funceditor = null;
			func = null;
			builder?.Dispose();
			builder = null;

			AI.Dispose();
		}

		private void tbFitness_DoubleClick(object sender, EventArgs e)
		{
			funceditor.Edit(func);
			tbFitness.Text = func.ToString();
		}
		private void btnBuilder_Click(object sender, EventArgs e)
		{
			AI.BrainPrototype = builder.Build(AI.BrainPrototype);
		}
		private void lblTrainIndicator_MouseEnter(object sender, EventArgs e)
		{
			if (SleepStartTime == null) return;
			var passed = DateTime.Now - (DateTime)SleepStartTime;
			var remaining = SleepTime - passed.TotalMilliseconds;
			tooltip.SetToolTip(lblTrainIndicator, $"Sleeping [Remaining: {remaining:#.00} ms]");
		}

		private void AI_PointEvaluated(uint hits, uint total, uint point, uint size)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<uint, uint, uint, uint>(AI_PointEvaluated), hits, total, point, size);
				return;
			}

			lblTrainStatus.ForeColor = Color.DarkGoldenrod;
			lblTrainStatus.Text = $"Point [{point + 1u}/{size}] of Gen [{AI.System.CurrentGeneration}/{AI.System.Generations}] -> Hits: [{hits}/{total}] Misses: [{total - hits}/{total}]";
		}
		private void AI_PopulationEvaluated(uint hits, uint total)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<uint, uint>(AI_PopulationEvaluated), hits, total);
				return;
			}

			lblTrainStatus.ForeColor = Color.DarkCyan;
			lblTrainStatus.Text = $"Gen [{AI.System.CurrentGeneration}/{AI.System.Generations}] -> Hits: [{hits}/{total}] Misses: [{total - hits}/{total}]";
		}
		private void AI_SleepStarting(int time)
		{
			if (SleepStartTime == null)
			{
				SleepStartTime = DateTime.Now;
				SleepTime = time;
			}

			if (InvokeRequired)
			{
				Invoke(new Action<int>(AI_SleepStarting), time);
				return;
			}

			lblTrainIndicator.ForeColor = Color.DeepSkyBlue;
		}
		private void AI_SleepEnded(int time)
		{
			SleepStartTime = null;
			SleepTime = 0;

			if (InvokeRequired)
			{
				Invoke(new Action<int>(AI_SleepEnded), time);
				return;
			}

			tooltip.SetToolTip(lblTrainIndicator, "Training");
			lblTrainIndicator.ForeColor = Color.DarkGreen;
		}

		private async void btnTrain_Click(object sender, EventArgs e)
		{
			if (training)
			{
				AI.StopTrain();
			}
			else
			{
				if
				(
					!Enum.TryParse<AI.Crossover>(cbCrossover.Text, out var crossover)
					||
					!uint.TryParse(tbPopSize.Text, out var popSize)
					||
					!uint.TryParse(tbParentCnt.Text, out var parentCnt)
					||
					!float.TryParse(tbMutation.Text, out var mutationRate)
					||
					!uint.TryParse(tbGenerations.Text, out var generations)
					||
					!uint.TryParse(tbLocalBatch.Text, out var localBatch)
					||
					!uint.TryParse(tbGlobalBatch.Text, out var globalBatch)
				)
				{
					MessageBox.Show("One or more parameters could not be parsed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				training = true;
				lblTrainIndicator.ForeColor = Color.DarkGreen;
				tooltip.SetToolTip(lblTrainIndicator, "Training");

				btnSaveClassifier.Enabled = false;
				btnBuilder.Enabled = false;
				btnTest.Enabled = btnClassifySaved.Enabled = btnClassifierLoading.Enabled = false;
				btnTrain.Text = "Stop";

				lblTrainStatus.ForeColor = Color.DarkCyan;
				lblTrainStatus.Text = "Initializing . . .";

				var ds = Dataset.Surrogate;
				ds.TrainRatio = tbDatasetRatio.Value / 100.0;

				var done = false;
				var failed = false;

				try
				{
					await AI.Init(crossover, popSize, parentCnt, mutationRate, generations);

					lblTrainStatus.ForeColor = Color.DarkOrange;
					lblTrainStatus.Text = "Preparing . . .";

					done = await AI.Train(func, localBatch, globalBatch);
				}
				catch (Exception ex)
				{
					var sb = new StringBuilder();

					sb.AppendLine("Training failed! Reason:");

					if (GICore.ExceptionCount > 0u)
					{
						while (GICore.ExceptionCount > 0u)
						{
							sb.Append($"{Environment.NewLine}\t'{GICore.NextException}'");
						}
					}
					else sb.Append($"{Environment.NewLine}\t'{ex.Message}'");

					var message = sb.ToString();

					failed = true;

					MessageBox.Show(message, ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				if (!failed)
				{
					if (done)
					{
						lblTrainStatus.ForeColor = Color.DarkGreen;
						lblTrainStatus.Text = "Training done.";
					}
					else
					{
						lblTrainStatus.ForeColor = Color.DarkRed;
						lblTrainStatus.Text = "Training stopped.";
					}
				}
				else
				{
					lblTrainStatus.ForeColor = Color.Red;
					lblTrainStatus.Text = "Training failed.";
				}

				btnTrain.Text = "Train";
				btnTrain.Enabled = false;
				btnResetTrain.Enabled = true;
				btnSaveClassifier.Enabled = true;
				btnTest.Enabled = btnClassifySaved.Enabled = btnClassifierLoading.Enabled = true;

				tooltip.SetToolTip(lblTrainIndicator, "Idling");
				lblTrainIndicator.ForeColor = Color.DimGray;
				training = false;

				if (!failed)
				{
					if (done || AI.System.CurrentGeneration == 1u) classifier = AI.Best();
					else classifier = AI.PrevBest();
				}
			}
		}

		private void btnResetTrain_Click(object sender, EventArgs e)
		{
			btnResetTrain.Enabled = false;
			btnBuilder.Enabled = btnTrain.Enabled = true;

			classifier = null;
			AI.Dispose(false);

			lblTrainStatus.ForeColor = Color.Brown;
			lblTrainStatus.Text = "Training reset.";
		}

		private async void btnSaveClassifier_Click(object sender, EventArgs e)
		{
			sfd.Title = "Save network";
			sfd.Filter = "Artificial Neural Network | *.ann";
			sfd.DefaultExt = ".ann";

			if (sfd.ShowDialog() != DialogResult.OK) return;

			lblTrainStatus.ForeColor = Color.DarkOrange;
			lblTrainStatus.Text = "Saving . . .";

			await AI.BrainPrototype.Save(sfd.FileName, classifier);

			lblTrainStatus.ForeColor = Color.DarkGreen;
			lblTrainStatus.Text = "Saved!";
		}

		#endregion

		#region Testing

		private NeuralNetwork loaded = null;
		private InputDataPoint input = null;
		private bool evaluating = false;

		private void InitializeTesting()
		{
			input = new InputDataPoint();
		}
		private void DisposeTesting()
		{
			loaded?.Dispose();
			loaded = null;

			input?.Dispose();
			input = null;
		}

		private NeuralNetwork ChooseNetwork()
		{
			if (classifier == null && loaded == null) throw new InvalidOperationException();
			if (loaded == null) return classifier;
			if (classifier == null) return loaded;
			if (cbUseLoaded.Checked) return loaded;
			else return classifier;
		}

		private async void btnTest_Click(object sender, EventArgs e)
		{
			if (classifier == null && loaded == null)
			{
				MessageBox.Show("Please, train a classifier first, or load one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var network = ChooseNetwork();
			var name = network == loaded ? "LOADED" : "TRAINED";

			btnTest.Enabled = false;
			evaluating = true;

			lblTestStatus.ForeColor = Color.DarkOrange;
			lblTestStatus.Text = "Please wait . . .";

			await new TestForm(name).Evaluate(network, (uint)nudDataCount.Value);

			lblTestStatus.ForeColor = Color.DarkGreen;
			lblTestStatus.Text = "Evaluation done!";

			evaluating = false;
			btnTest.Enabled = true;
		}

		private async void btnClassifySaved_Click(object sender, EventArgs e)
		{
			if (classifier == null && loaded == null)
			{
				MessageBox.Show("Please, train a classifier first, or load one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (saved == null)
			{
				MessageBox.Show("Please, draw something, then save it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var network = ChooseNetwork();

			var ds = Dataset.Surrogate;
			await ds.PreprocessImage(input, saved);

			network.Eval(input.Data);
			network.Output.Retrieve(AI.OutputBuffer);
			var predicted = Categories.From(AI.OutputBuffer);
			lblTestStatus.Text = $"'{predicted}'!";
		}

		private async void btnClassifierLoading_Click(object sender, EventArgs e)
		{
			if (loaded == null)
			{
				ofd.Title = "Open network";
				ofd.Filter = "Artificial Neural Network | *.ann";
				ofd.DefaultExt = ".ann";

				if (ofd.ShowDialog() != DialogResult.OK) return;

				lblTestStatus.ForeColor = Color.DarkOrange;
				lblTestStatus.Text = "Loading . . .";

				btnClassifierLoading.Enabled = false;

				var prototype = new NeuralPrototype();

				try
				{
					loaded = await prototype.Load(ofd.FileName);
				}
				catch (Exception ex)
				{
					if (ex is FormatException fex)
					{
						MessageBox.Show(fex.Message, "Invalid file format", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					prototype.Dispose();
					btnClassifierLoading.Enabled = true;

					lblTestStatus.ForeColor = Color.DarkRed;
					lblTestStatus.Text = "Loading failed!";
					return;
				}

				var choice = DialogResult.No;
				
				if (loaded != null)
				{
					if (!training && classifier == null) choice = MessageBox.Show("Loading successful. Would you also like to load the neural prototype as well?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					btnClassifierLoading.Text = "Unload";
					btnClassifierLoading.Enabled = true;
					cbUseLoaded.Enabled = true;
				}
				else
				{
					if (!training && classifier == null) choice = MessageBox.Show($"Neural network not found in the file, but the prototype has been found.{Environment.NewLine}Would you like to load the neural prototype?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					else MessageBox.Show("Neural network not found in the file. Prototype will be discarded since training is in progress or a trained classifier is present.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					btnClassifierLoading.Enabled = true;
				}

				if (choice == DialogResult.Yes)
				{
					AI.BrainPrototype = prototype;
				}
				else prototype.Dispose();

				lblTestStatus.ForeColor = Color.DarkGreen;
				lblTestStatus.Text = "Done!";
			}
			else
			{
				loaded.Dispose();
				loaded = null;

				btnClassifierLoading.Text = "Load";
				cbUseLoaded.Enabled = false;
			}
		}

		#endregion

		#region Dataset

		private void InitializeDataset()
		{
			lblTotal.Text = $"Dataset size: {Dataset.Surrogate.Size}";
		}
		private void DisposeDataset()
		{

		}

		private void tbDatasetRatio_ValueChanged(object sender, EventArgs e)
		{
			var val = tbDatasetRatio.Value;
			lblDatasetRatio.Text = $"Train/Test ratio: {val}%";
		}

		#endregion

		#region Exception Handling

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) => HandleException(e.ExceptionObject as Exception);
		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e) => HandleException(e.Exception);

		private void HandleException(Exception ex)
		{
			var sb = new StringBuilder();

			sb.AppendLine("=======================");

			if (ex != null)
			{
				sb.AppendLine($"Exception: {ex.Message}");
				sb.AppendLine("-----------------------");
				sb.AppendLine(ex.StackTrace);

				if (ex.InnerException != null)
				{
					sb.AppendLine("-----------------------");
					sb.AppendLine($"Inner Exception: {ex.Message}");
					sb.AppendLine("-----------------------");
					sb.AppendLine(ex.StackTrace);
				}

				sb.AppendLine("=======================");
			}

			if (GICore.ExceptionCount == 0u) sb.AppendLine("0 GI Exceptions.");
			while (GICore.ExceptionCount > 0u) sb.AppendLine(GICore.NextException);

			sb.AppendLine("=======================");

			MessageBox.Show(sb.ToString(), ex?.GetType().FullName ?? "An exception has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#endregion
	}
}
