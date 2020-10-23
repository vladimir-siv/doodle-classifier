using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class ConvLayer : UserControl
	{
		public uint LayerSize => scSize.ChosenSize;
		public Layer.Convolutional.Filter LayerFilter => new Layer.Convolutional.Filter(dcFilter.ChosenWidth, dcFilter.ChosenHeight);
		public Layer.Convolutional.Stride LayerStride => new Layer.Convolutional.Stride(dcStride.ChosenWidth, dcStride.ChosenHeight);
		public Layer.Convolutional.Padding LayerPadding => new Layer.Convolutional.Padding(dcPadding.ChosenWidth, dcPadding.ChosenHeight);
		public ActivationFunction LayerActivation => afcActivation.Activation;

		public ConvLayer()
		{
			InitializeComponent();
		}
	}
}
