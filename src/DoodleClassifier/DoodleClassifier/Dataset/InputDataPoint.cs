using System;
using GrandIntelligence;

namespace DoodleClassifier
{
	public class InputDataPoint : IDisposable
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
				classString = value;
				if (classString == null) Class = null;
				else Class = Categories.OneHot(classString);
			}
		}

		public InputDataPoint(string cls = null)
		{
			Data = Device.Active.Tensor(Shape.As3D(RawData.ImageHeight, RawData.ImageWidth, 1u));
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
