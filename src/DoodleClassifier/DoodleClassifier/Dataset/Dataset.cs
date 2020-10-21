using System.Threading.Tasks;

namespace DoodleClassifier
{
	public sealed class Dataset
	{
		private static Dataset instance = null;

		public static async Task<Dataset> Load()
		{
			if (instance != null) return instance;

			var totalDataPoints = 0u;

			foreach (var category in Categories.Enumerate())
			{
				var data = await RawData.From(category);
				totalDataPoints += data.ImageCount;
			}

			return instance = new Dataset(totalDataPoints);
		}

		public uint Size { get; private set; }

		private Dataset(uint size) => Size = size;
	}
}
