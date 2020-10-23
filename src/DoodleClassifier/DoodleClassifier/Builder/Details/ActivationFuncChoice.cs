using System;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class ActivationFuncChoice : UserControl
	{
		public ActivationFunction Activation
		{
			get
			{
				if (Enum.TryParse<ActivationFunction>(cbActivation.Text, out var func)) return func;
				throw new FormatException("Unknown activation function.");
			}
			set
			{
				cbActivation.Text = value.ToString();
			}
		}

		public ActivationFuncChoice()
		{
			InitializeComponent();
		}
	}
}
