using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class PoolLayer : UserControl
	{
		public Layer.Pooling.Filter LayerFilter => new Layer.Pooling.Filter(dcFilter.ChosenWidth, dcFilter.ChosenHeight);
		public Layer.Pooling.Stride LayerStride => new Layer.Pooling.Stride(dcStride.ChosenWidth, dcStride.ChosenHeight);
		public PoolingType LayerPoolingType => pcPool.Pooling;

		public PoolLayer()
		{
			InitializeComponent();
		}
	}
}
