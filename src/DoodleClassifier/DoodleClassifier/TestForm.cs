using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class TestForm : Form
	{
		public TestForm(NeuralNetwork network, string name)
		{
			InitializeComponent();
			Text += $" [{name}]";
		}

		public async Task Evaluate()
		{
			Show();
		}
	}
}
