using System;
using GrandIntelligence;

namespace DoodleClassifier
{
	public class DataPoint : IDisposable
	{
		public Tensor Data { get; private set; } = null;
		public float[] Class { get; private set; } = null;

		private string classString = null;
		public string ClassString
		{
			get
			{
				return classString;
			}
			set
			{
				if (value == classString) return;
				Class = Categories.OneHot(value);
				classString = value;
				if (classString == null) Class = null;
			}
		}

		public DataPoint(string cls = null)
		{
			Data = Device.Active.Tensor(Shape.As2D(RawData.ImageHeight, RawData.ImageWidth));
			ClassString = cls;
		}

		public void Dispose()
		{
			Data.Dispose();
			Data = null;
			ClassString = null;
		}
	}
}
