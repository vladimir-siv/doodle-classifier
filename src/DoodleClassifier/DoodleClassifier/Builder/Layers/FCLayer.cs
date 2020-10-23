using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class FCLayer : UserControl
	{
		public uint LayerSize => scSize.ChosenSize;
		public ActivationFunction LayerActivation => afcActivation.Activation;

		public FCLayer()
		{
			InitializeComponent();
		}
	}
}
