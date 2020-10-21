using System;
using System.Drawing;
using System.Threading.Tasks;

namespace DoodleClassifier
{
	public sealed class Dataset
	{
		public static Dataset Surrogate { get; }
		static Dataset()
		{
			var totalDataPoints = 0ul;

			foreach (var category in Categories.Enumerate())
			{
				var data = RawData.From(category);
				totalDataPoints += data.ImageCount;
			}

			Surrogate = new Dataset(totalDataPoints);
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

		public async Task PreprocessImage(InputDataPoint point, string category, ulong image)
		{
			if (point == null) throw new ArgumentNullException(nameof(point));

			var data = RawData.From(category);

			if (image >= data.ImageCount) throw new IndexOutOfRangeException();

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
		public async Task PreprocessImage(InputDataPoint point, Bitmap image)
		{
			if (point == null) throw new ArgumentNullException(nameof(point));

			point.ClassString = null;

			var pointdata = point.Data;

			await Task.Run(async () =>
			{
				for (var i = 0; i < RawData.ImageHeight; ++i)
				{
					for (var j = 0; j < RawData.ImageWidth; ++j)
					{
						var color = image.GetPixel(j, i);
						var value = (byte)((color.R + color.G + color.B) / 3);
						var index = i * RawData.ImageWidth + j;
						buffer[index] = (255 - value) / 255f;
					}
				}

				await pointdata.TransferAsync(buffer);
			});
		}

		public async Task RandomFillBatch(Batch batch, uint localCount, uint globalCount = 0u)
		{
			if (batch == null) throw new ArgumentNullException(nameof(batch));
			if (localCount == 0u) throw new ArgumentException("Argument localCount cannot be zero.");
			if (batch.Capacity != Categories.Count * localCount + globalCount) throw new ArgumentException("Incorrect batch size.");

			await Task.Run(() =>
			{
				batch.Clear();

				for (var i = 0u; i < localCount; ++i)
				{
					foreach (var category in Categories.Enumerate())
					{
						batch.Add
						(
							new DataPoint
							(
								category,
								RandomTrainImage(category)
							)
						);
					}
				}

				for (var i = 0u; i < globalCount; ++i)
				{
					var category = Categories.RandomCategory();

					batch.Add
					(
						new DataPoint
						(
							category,
							RandomTrainImage(category)
						)
					);
				}
			});
		}
	}
}
