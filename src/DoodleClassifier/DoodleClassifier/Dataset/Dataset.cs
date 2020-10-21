using System;
using System.Threading.Tasks;
using GrandIntelligence;

namespace DoodleClassifier
{
	public sealed class Dataset
	{
		private static Dataset Current { get; }
		static Dataset()
		{
			var totalDataPoints = 0ul;

			foreach (var category in Categories.Enumerate())
			{
				var data = RawData.From(category);
				totalDataPoints += data.ImageCount;
			}

			Current = new Dataset(totalDataPoints);
		}

		private readonly float[] buffer = new float[RawData.ImageWidth * RawData.ImageHeight];
		
		public ulong Size { get; private set; }

		private double _trainRatio = 0.95;
		public double TrainRatio
		{
			get
			{
				return _trainRatio;
			}
			set
			{
				_trainRatio = value;
				if (_trainRatio < 0.0) _trainRatio = 0.0;
				if (_trainRatio > 1.0) _trainRatio = 1.0;
			}
		}

		private Dataset(ulong size) => Size = size;

		public ulong RandomImage(string category)
		{
			var data = RawData.From(category);
			var cnt = data.ImageCount;
			return (ulong)(cnt * Extension.RandomDouble());
		}
		public ulong RandomTrainImage(string category)
		{
			var data = RawData.From(category);
			var traincnt = (ulong)(data.ImageCount * TrainRatio);
			return (ulong)(traincnt * Extension.RandomDouble());
		}
		public ulong RandomTestImage(string category)
		{
			var data = RawData.From(category);
			var traincnt = (ulong)(data.ImageCount * TrainRatio);
			var testcnt = data.ImageCount - traincnt;
			return traincnt + (ulong)(testcnt * Extension.RandomDouble());
		}

		public async Task PreprocessImage(DataPoint point, string category, ulong image)
		{
			if (point == null) throw new ArgumentNullException(nameof(point));

			var data = RawData.From(category);

			if (image >= data.ImageCount) throw new IndexOutOfRangeException();

			var device = Device.Active;

			point.ClassString = category;

			var pointdata = point.Data;

			await Task.Run(async () =>
			{
				for (var i = 0u; i < RawData.ImageHeight; ++i)
				{
					for (var j = 0u; j < RawData.ImageWidth; ++j)
					{
						var index = i * RawData.ImageWidth + j;
						buffer[index] = data[image, index] / 255f;
					}
				}

				await pointdata.TransferAsync(buffer);
			});
		}
	}
}
