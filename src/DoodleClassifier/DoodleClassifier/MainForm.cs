using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			InitializeDrawing();
		}

		private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			DisposeDrawing();
		}

		#region Dataset Display

		private CategoryChooser categoryChooser = new CategoryChooser();

		private uint current = 0u;
		private RawData data = null;

		private void DrawCurrent()
		{
			var old = pbPreview.BackgroundImage;

			using (var bmp = new Bitmap(28, 28, PixelFormat.Format32bppArgb))
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
			current = 0u;
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
			if (data != null && current > 0u)
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

		#region Testing

		private void btnTest_Click(object sender, EventArgs e)
		{

		}

		#endregion
	}
}
