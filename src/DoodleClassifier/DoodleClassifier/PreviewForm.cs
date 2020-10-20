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

		#region Testing

		private void btnTest_Click(object sender, EventArgs e)
		{

		}

		#endregion
	}
}
