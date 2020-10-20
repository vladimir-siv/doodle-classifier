using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class PreviewForm : Form
	{
		private uint current = 0u;
		private RawData data = RawData.From(Categories.Bananas);

		public PreviewForm()
		{
			InitializeComponent();
		}

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

		private void PreviewForm_Load(object sender, EventArgs e)
		{
			DrawCurrent();
		}
		private void btnNext_Click(object sender, EventArgs e)
		{
			if (current < data.ImageCount)
			{
				++current;
				DrawCurrent();
			}
		}
		private void btnPrev_Click(object sender, EventArgs e)
		{
			if (current > 0u)
			{
				--current;
				DrawCurrent();
			}
		}

		private void btnTest_Click(object sender, EventArgs e)
		{

		}
	}
}
