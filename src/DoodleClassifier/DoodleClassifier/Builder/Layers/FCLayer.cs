using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class FCLayer : UserControl
	{
		public uint LayerSize
		{
			get => scSize.ChosenSize;
			set => scSize.ChosenSize = value;
		}
		public ActivationFunction LayerActivation
		{
			get => afcActivation.Activation;
			set => afcActivation.Activation = value;
		}

		public FCLayer()
		{
			InitializeComponent();
		}
	}
}
