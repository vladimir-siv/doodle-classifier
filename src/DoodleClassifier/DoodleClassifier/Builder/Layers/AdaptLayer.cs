using System;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class AdaptLayer : UserControl
	{
		public bool LayerNormalize
		{
			get => cbNormalize.Checked;
			set => cbNormalize.Checked = value;
		}
		public ActivationFunction LayerActivation
		{
			get => afcActivation.Activation;
			set => afcActivation.Activation = value;
		}
		public bool LayerReshape
		{
			get => cbReshape.Checked;
			set => cbReshape.Checked = value;
		}
		public Shape LayerShape
		{
			get => new Shape(scShape.ChosenHeight, scShape.ChosenWidth, scShape.ChosenDepth);
			set { scShape.ChosenHeight = value.SafeDimension(0u); scShape.ChosenWidth = value.SafeDimension(1u); scShape.ChosenDepth = value.SafeDimension(2u); }
		}

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
