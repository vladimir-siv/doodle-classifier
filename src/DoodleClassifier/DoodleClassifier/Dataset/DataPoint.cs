using GrandIntelligence;

namespace DoodleClassifier
{
	public struct DataPoint
	{
		public Tensor Data { get; private set; }
		public float[] Class { get; private set; }

		public DataPoint(Tensor data, string cls)
		{
			Data = data;
			Class = Categories.OneHot(cls);
		}
	}
}
