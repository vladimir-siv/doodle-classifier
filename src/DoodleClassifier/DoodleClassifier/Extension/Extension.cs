using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace DoodleClassifier
{
	public static class Extension
	{
		private static readonly Random rng = new Random();
		
		/// <summary>
		/// Resize the image to the specified width and height.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="width">The width to resize to.</param>
		/// <param name="height">The height to resize to.</param>
		/// <returns>The resized image.</returns>
		public static Bitmap Resize(this Image image, int width, int height)
		{
			var destRect = new Rectangle(0, 0, width, height);
			var destImage = new Bitmap(width, height);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

		public static float Distance(PointF from, PointF to)
		{
			var xdist = to.X - from.X;
			var ydist = to.Y - from.Y;
			return (float)Math.Sqrt(xdist * xdist + ydist * ydist);
		}
		public static PointF Vector(PointF from, PointF to, float len = 1.0f)
		{
			var dist = Distance(from, to);
			return new PointF(len * (to.X - from.X) / dist, len * (to.Y - from.Y) / dist);
		}
		public static PointF Add(PointF a, PointF b)
		{
			return new PointF(a.X + b.X, a.Y + b.Y);
		}

		public static double RandomDouble() => rng.NextDouble();
		public static int RandomInt(int max) => rng.Next(max);
	}
}
