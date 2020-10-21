using GrandIntelligence;

namespace DoodleClassifier
{
	public static class Preprocessing
	{
		private static float[] buffer = new float[RawData.ImageWidth * RawData.ImageHeight];

		public static DataPoint PreprocessImage(this RawData data, uint image)
		{
			var device = Device.Active;

			var pointdata = device.Tensor(Shape.As2D(RawData.ImageHeight, RawData.ImageWidth));

			for (var i = 0u; i < RawData.ImageHeight; ++i)
			{
				for (var j = 0u; j < RawData.ImageWidth; ++j)
				{
					var index = i * RawData.ImageWidth + j;
					buffer[index] = data[image, index] / 255f;
				}
			}

			pointdata.Transfer(buffer);

			return new DataPoint(pointdata, data.Category);
		}
	}
}
