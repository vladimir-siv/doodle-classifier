using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class ConvLayer : UserControl
	{
		public uint LayerSize
		{
			get => scSize.ChosenSize;
			set => scSize.ChosenSize = value;
		}
		public Layer.Convolutional.Filter LayerFilter
		{
			get => new Layer.Convolutional.Filter(dcFilter.ChosenWidth, dcFilter.ChosenHeight);
			set { dcFilter.ChosenWidth = value.width; dcFilter.ChosenHeight = value.height; }
		}
		public Layer.Convolutional.Stride LayerStride
		{
			get => new Layer.Convolutional.Stride(dcStride.ChosenWidth, dcStride.ChosenHeight);
			set { dcStride.ChosenWidth = value.horizontal; dcStride.ChosenHeight = value.vertical; }
		}
		public Layer.Convolutional.Padding LayerPadding
		{
			get => new Layer.Convolutional.Padding(dcPadding.ChosenWidth, dcPadding.ChosenHeight);
			set { dcPadding.ChosenWidth = value.horizontal; dcPadding.ChosenHeight = value.vertical; }
		}
		public ActivationFunction LayerActivation
		{
			get => afcActivation.Activation;
			set => afcActivation.Activation = value;
		}

		public ConvLayer()
		{
			InitializeComponent();
		}
	}
}
