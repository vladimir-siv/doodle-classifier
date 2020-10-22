﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class MainForm : Form
	{
		private readonly OpenFileDialog ofd = new OpenFileDialog { InitialDirectory = Extension.Desktop };
		private readonly SaveFileDialog sfd = new SaveFileDialog { InitialDirectory = Extension.Desktop };

		public MainForm()
		{
			GICore.Init(new Spec(DeviceType.NvidiaGpu));
			InitializeComponent();
			InitializeDrawing();
			InitializeTraining();
			InitializeTesting();
		}
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (training)
			{
				MessageBox.Show("Cannot close while training is in progress. Please, stop the training first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				e.Cancel = true;
				return;
			}

			RawData.Clean();
			DisposeDrawing();
			DisposeTraining();
			DisposeTesting();
			GICore.Release();
		}

		#region Dataset Display

		private readonly CategoryChooser categoryChooser = new CategoryChooser();

		private ulong current = 0ul;
		private RawData data = null;

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

		private void InitializeTraining()
		{
			AI.PointEvaluated += AI_PointEvaluated;
		}
		private void DisposeTraining()
		{
			AI.PointEvaluated -= AI_PointEvaluated;
		}

		private void AI_PointEvaluated(uint hits, uint misses, uint point, uint total)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<uint, uint, uint, uint>(AI_PointEvaluated), hits, misses, point, total);
				return;
			}

			lblTrainStatus.ForeColor = Color.DarkGoldenrod;
			lblTrainStatus.Text = $"Point [{point + 1u}/{total}] of Gen [{AI.System.CurrentGeneration}/{AI.System.Generations}] -> Hits: [{hits}/{hits + misses}] Misses: [{misses}/{hits + misses}]";
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

				btnTrain.Text = "Stop";

				lblTrainStatus.ForeColor = Color.DarkCyan;
				lblTrainStatus.Text = "Initializing . . .";

				await AI.Init(popSize, parentCnt, mutationRate, generations);

				lblTrainStatus.ForeColor = Color.DarkOrange;
				lblTrainStatus.Text = "Preparing . . .";

				var done = await AI.Train(localBatch, globalBatch);

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

				btnTrain.Text = "Train";
				btnTrain.Enabled = false;
				btnSaveClassifier.Enabled = btnResetTrain.Enabled = true;

				training = false;

				classifier = AI.Best();
			}
		}

		private void btnResetTrain_Click(object sender, EventArgs e)
		{
			btnSaveClassifier.Enabled = btnResetTrain.Enabled = false;
			btnTrain.Enabled = true;

			classifier = null;
			AI.Dispose();

			lblTrainStatus.ForeColor = Color.Brown;
			lblTrainStatus.Text = "Training reset.";
		}

		private async void btnSaveClassifier_Click(object sender, EventArgs e)
		{
			sfd.Title = "Save network";
			sfd.Filter = "Convolutional Network | *.cnn";
			sfd.DefaultExt = ".cnn";

			if (sfd.ShowDialog() != DialogResult.OK) return;

			lblTrainStatus.ForeColor = Color.DarkOrange;
			lblTrainStatus.Text = "Saving . . .";

			await Task.Run(() =>
			{
				using (var stream = new StreamWriter(sfd.FileName))
				using (var it = new NeuralIterator())
				{
					for (var param = it.Begin(classifier); param != null; param = it.Next())
					{
						stream.Write($"{it.CurrentParam}:");

						var data = param.GetData();

						for (var i = 0u; i < data.Length; ++i)
						{
							stream.Write($" {data[i]}");
						}

						stream.WriteLine();
					}
				}
			});

			lblTrainStatus.ForeColor = Color.DarkGreen;
			lblTrainStatus.Text = "Saved!";
		}

		#endregion

		#region Testing

		private NeuralNetwork loaded = null;
		private InputDataPoint input = null;

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

		private void btnTest_Click(object sender, EventArgs e)
		{

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
			var decision = Categories.From(AI.OutputBuffer);
			lblTestStatus.Text = $"Your drawing is a(n) '{decision}'.";
		}

		private async void btnClassifierLoading_Click(object sender, EventArgs e)
		{
			if (loaded == null)
			{
				ofd.Title = "Open network";
				ofd.Filter = "Convolutional Network | *.cnn";
				ofd.DefaultExt = ".cnn";

				if (ofd.ShowDialog() != DialogResult.OK) return;

				lblTestStatus.ForeColor = Color.DarkOrange;
				lblTestStatus.Text = "Loading . . .";

				btnClassifierLoading.Enabled = false;

				loaded = await Task.Run(() =>
				{
					try
					{
						var lines = File.ReadAllLines(ofd.FileName);

						var vals = new float[lines.Length][];

						for (var ln = 0; ln < lines.Length; ++ln)
						{
							var line = lines[ln];

							var s1 = line.Split(':');

							var i = Convert.ToUInt32(s1[0]);

							var svals = s1[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

							vals[i] = new float[svals.Length];

							for (var v = 0u; v < svals.Length; ++v)
							{
								vals[i][v] = Convert.ToSingle(svals[v]);
							}
						}

						loaded = AI.BrainPrototype.Compile();

						using (var it = new NeuralIterator())
						{
							for (var param = it.Begin(loaded); param != null; param = it.Next())
							{
								param.Transfer(vals[it.CurrentParam]);
							}
						}
					}
					catch
					{
						loaded?.Dispose();
						loaded = null;
					}

					return loaded;
				});

				if (loaded != null)
				{
					btnClassifierLoading.Text = "Unload";
					btnClassifierLoading.Enabled = true;
					cbUseLoaded.Enabled = true;

					lblTestStatus.ForeColor = Color.DarkGreen;
					lblTestStatus.Text = "Done!";
				}
				else
				{
					btnClassifierLoading.Enabled = true;

					lblTestStatus.ForeColor = Color.DarkRed;
					lblTestStatus.Text = "Failed to load the file!";
				}
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

		private void tbDatasetRatio_ValueChanged(object sender, EventArgs e)
		{
			var ds = Dataset.Surrogate;
			var val = tbDatasetRatio.Value;
			lblDatasetRatio.Text = $"Train/Test ratio: {val}%";
			ds.TrainRatio = val / 100.0;
		}

		#endregion
	}
}
