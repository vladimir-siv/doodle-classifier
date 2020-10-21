﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitializeDrawing();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			GICore.Init(new Spec(DeviceType.NvidiaGpu));
		}
		private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			RawData.Clean();
			DisposeDrawing();
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

		#region Dataset

		

		#endregion

		#region Testing

		private async void btnTest_Click(object sender, EventArgs e)
		{
			if (data == null)
			{
				MessageBox.Show("Please, select an image from dataset preview.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			var log = System.IO.Path.Combine(desktop, "log.txt");
			if (System.IO.File.Exists(log)) System.IO.File.Delete(log);

			void dumpvals(params float[] values)
			{
				var sb = new System.Text.StringBuilder();

				for (var i = 0; i < values.Length; ++i)
				{
					sb.Append($"{values[i]:0.00000000} ");
				}

				sb.AppendLine();

				System.IO.File.AppendAllText(log, sb.ToString());
			}

			using (var dp = new DataPoint())
			{
				var ds = Dataset.Current;

				// Zero out
				{
					dp.Data.Format(0f);
					var vals = dp.Data.GetData();
					dumpvals(vals);
				}

				// Direct preprocess
				{
					await ds.PreprocessImage(dp, data.Category, current);
					var vals = dp.Data.GetData();
					dumpvals(vals);
				}

				// Zero out
				{
					dp.Data.Format(0f);
					var vals = dp.Data.GetData();
					dumpvals(vals);
				}

				// Bitmap preprocess
				{
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

						await ds.PreprocessImage(dp, bmp);
					}

					var vals = dp.Data.GetData();
					dumpvals(vals);
				}
			}
		}

		#endregion
	}
}
