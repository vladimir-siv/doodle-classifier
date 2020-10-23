using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class PoolLayer : UserControl
	{
		public Layer.Pooling.Filter LayerFilter
		{
			get => new Layer.Pooling.Filter(dcFilter.ChosenWidth, dcFilter.ChosenHeight);
			set { dcFilter.ChosenWidth = value.width; dcFilter.ChosenHeight = value.height; }
		}
		public Layer.Pooling.Stride LayerStride
		{
			get => new Layer.Pooling.Stride(dcStride.ChosenWidth, dcStride.ChosenHeight);
			set { dcStride.ChosenWidth = value.horizontal; dcStride.ChosenHeight = value.vertical; }
		}
		public PoolingType LayerPoolingType
		{
			get => pcPool.Pooling;
			set => pcPool.Pooling = value;
		}

		public PoolLayer()
		{
			InitializeComponent();
		}
	}
}
