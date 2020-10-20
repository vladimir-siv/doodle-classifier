using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class PreviewForm : Form
	{
		public PreviewForm()
		{
			InitializeComponent();
			InitializeDrawing();
		}

		#region Dataset Display

		private CategoryChooser categoryChooser = new CategoryChooser();

		private uint current = 0u;
		private RawData data = null;

		private void DrawCurrent()
		{
			var old = pbPreview.BackgroundImage;

			var bmp = new Bitmap(28, 28, PixelFormat.Format32bppArgb);

			for (var i = 0; i < RawData.ImageHeight; ++i)
			{
				for (var j = 0; j < RawData.ImageWidth; ++j)
				{
					var value = 255 - data[current, i, j];
					bmp.SetPixel(j, i, Color.FromArgb(value, value, value));
				}
			}

			pbPreview.BackgroundImage = bmp;

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

		private Bitmap drawingBmp = null;
		private Graphics drawingGraphics = null;
		private Brush drawingBrush = null;

		private void InitializeDrawing()
		{
			drawingBmp = new Bitmap(140, 140, PixelFormat.Format32bppArgb);
			drawingGraphics = Graphics.FromImage(drawingBmp);
			drawingBrush = new SolidBrush(Color.Black);
			btnClear_Click(this, EventArgs.Empty);
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			drawingGraphics.Clear(Color.White);
			pbDraw.Refresh();
		}

		private void pbDraw_MouseMove(object sender, MouseEventArgs e)
		{
			if (!e.Button.HasFlag(MouseButtons.Left)) return;
			drawingGraphics.FillEllipse(drawingBrush, e.X, e.Y, 6, 6);
			pbDraw.Refresh();
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
