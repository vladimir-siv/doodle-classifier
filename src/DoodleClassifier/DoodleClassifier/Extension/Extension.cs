using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text;
using GrandIntelligence;

namespace DoodleClassifier
{
	public static class Extension
	{
		private static readonly Random rng = new Random();
		
		public static readonly string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
		
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

		public static double Variance(this uint[] array)
		{
			var mean = 0.0;
			for (var i = 0u; i < array.Length; ++i)
			{
				mean += array[i];
			}
			mean /= array.Length;

			var variance = 0.0;
			for (var i = 0u; i < array.Length; ++i)
			{
				var diff = array[i] - mean;
				variance += diff * diff;
			}
			variance /= array.Length;

			return variance;
		}

		public static string SaveParams(this NeuralNetwork network)
		{
			if (network == null) throw new ArgumentNullException(nameof(network));

			var sb = new StringBuilder();

			using (var it = new NeuralIterator())
			{
				for (var param = it.Begin(network); param != null; param = it.Next())
				{
					sb.Append($"{it.CurrentParam}:");

					var data = param.GetData();

					for (var i = 0u; i < data.Length; ++i)
					{
						sb.Append($" {data[i]}");
					}

					sb.AppendLine();
				}
			}

			return sb.ToString();
		}
		public static void LoadParams(this NeuralNetwork network, string parameters)
		{
			if (network == null) throw new ArgumentNullException(nameof(network));

			var lines = parameters.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

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

			using (var it = new NeuralIterator())
			{
				for (var param = it.Begin(network); param != null; param = it.Next())
				{
					param.Transfer(vals[it.CurrentParam]);
				}
			}
		}

		public static string Serialize(this Layer.Convolutional.Filter filter) => $"{filter.width},{filter.height}";
		public static string Serialize(this Layer.Convolutional.Stride stride) => $"{stride.horizontal},{stride.vertical}";
		public static string Serialize(this Layer.Convolutional.Padding padding) => $"{padding.horizontal},{padding.vertical}";
		public static string Serialize(this Layer.Pooling.Filter filter) => $"{filter.width},{filter.height}";
		public static string Serialize(this Layer.Pooling.Stride stride) => $"{stride.horizontal},{stride.vertical}";
		
		public static Layer.Convolutional.Filter DeserializeAsConvFilter(this string str)
		{
			var parts = str.Split(',');
			if (parts.Length != 2) throw new FormatException("Invalid format.");
			return new Layer.Convolutional.Filter(Convert.ToUInt32(parts[0]), Convert.ToUInt32(parts[1]));
		}
		public static Layer.Convolutional.Stride DeserializeAsConvStride(this string str)
		{
			var parts = str.Split(',');
			if (parts.Length != 2) throw new FormatException("Invalid format.");
			return new Layer.Convolutional.Stride(Convert.ToUInt32(parts[0]), Convert.ToUInt32(parts[1]));
		}
		public static Layer.Convolutional.Padding DeserializeAsConvPadding(this string str)
		{
			var parts = str.Split(',');
			if (parts.Length != 2) throw new FormatException("Invalid format.");
			return new Layer.Convolutional.Padding(Convert.ToUInt32(parts[0]), Convert.ToUInt32(parts[1]));
		}
		public static Layer.Pooling.Filter DeserializeAsPoolFilter(this string str)
		{
			var parts = str.Split(',');
			if (parts.Length != 2) throw new FormatException("Invalid format.");
			return new Layer.Pooling.Filter(Convert.ToUInt32(parts[0]), Convert.ToUInt32(parts[1]));
		}
		public static Layer.Pooling.Stride DeserializeAsPoolStride(this string str)
		{
			var parts = str.Split(',');
			if (parts.Length != 2) throw new FormatException("Invalid format.");
			return new Layer.Pooling.Stride(Convert.ToUInt32(parts[0]), Convert.ToUInt32(parts[1]));
		}

		public static string Serialize(this Shape shape)
		{
			switch (shape.Hyperdimension)
			{
				case 0: return string.Empty;
				case 1: return $"{shape[0u]}";
				case 2: return $"{shape[0u]}x{shape[1u]}";
				case 3: return $"{shape[0u]}x{shape[1u]}x{shape[2u]}";
				default: throw new InvalidOperationException("Invalid shape hyperdimension.");
			}
		}
		public static Shape DeserializeAsShape(this string str)
		{
			var parts = string.IsNullOrWhiteSpace(str) ? null : str.Split('x');
			if (parts != null && parts.Length == 0 && parts.Length > 3) throw new FormatException("Invalid format.");

			var dim1 = parts != null ? Convert.ToUInt32(parts[0]) : 0u;
			var dim2 = parts.Length > 1 ? Convert.ToUInt32(parts[1]) : 0u;
			var dim3 = parts.Length > 2 ? Convert.ToUInt32(parts[2]) : 0u;

			return new Shape(dim1, dim2, dim3);
		}
	}
}
