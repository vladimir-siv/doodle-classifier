using System;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class AdaptLayer : UserControl
	{
		public bool LayerNormalize => cbNormalize.Checked;
		public ActivationFunction LayerActivation => afcActivation.Activation;
		public bool LayerReshape => cbReshape.Checked;
		public Shape LayerShape => new Shape(scShape.ChosenHeight, scShape.ChosenWidth, scShape.ChosenDepth);

		public AdaptLayer()
		{
			InitializeComponent();
		}

		private void cbReshape_CheckedChanged(object sender, EventArgs e)
		{
			scShape.Enabled = cbReshape.Checked;
		}
	}
}
