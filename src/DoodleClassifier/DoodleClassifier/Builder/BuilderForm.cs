using System;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class BuilderForm : Form
	{
		private NeuralBuilder prototype = null;

		public BuilderForm()
		{
			InitializeComponent();
			lblOutput.Text = $"Output: 1x{Categories.Count}";
		}

		public NeuralBuilder Build()
		{
			ShowDialog();
			return prototype;
		}

		private NeuralBuilder BuildPrototype()
		{
			throw new NotImplementedException();
		}

		private void lbLayers_MouseClick(object sender, MouseEventArgs e)
		{
			var index = lbLayers.IndexFromPoint(e.X, e.Y);
			lbLayers.SelectedIndex = index;
		}
		private void lbLayers_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lbLayers.SelectedIndex == -1) return;

			switch (lbLayers.SelectedItem.ToString())
			{
				case "Convolutional":
					pnlLayers.Controls.Add(new ConvLayer());
					break;
				case "Pooling":
					pnlLayers.Controls.Add(new PoolLayer());
					break;
				case "Adapting":
					pnlLayers.Controls.Add(new AdaptLayer());
					break;
				case "FullyConnected":
					pnlLayers.Controls.Add(new FCLayer());
					break;
			}
		}
		private void btnRemoveLast_Click(object sender, EventArgs e)
		{
			if (pnlLayers.Controls.Count == 0) return;
			pnlLayers.Controls.RemoveAt(pnlLayers.Controls.Count - 1);
		}
		private void btnClear_Click(object sender, EventArgs e)
		{
			pnlLayers.Controls.Clear();
		}
		private void btnAccept_Click(object sender, EventArgs e)
		{
			NeuralBuilder builder = null;

			try
			{
				builder = BuildPrototype();

				using (var nn = builder.Compile())
				{
					var inShape = nn.InputShape;
					if (inShape.Hyperdimension != 3u) throw new ApplicationException("Input shape hyperdimension not equal to 3.");
					if (inShape[0] != RawData.ImageHeight) throw new ApplicationException($"Input shape 1st dimension not equal to {RawData.ImageHeight}.");
					if (inShape[1] != RawData.ImageWidth) throw new ApplicationException($"Input shape 2nd dimension not equal to {RawData.ImageWidth}.");
					if (inShape[2] != 1) throw new ApplicationException($"Input shape 3rd dimension not equal to 1.");

					var outShape = nn.OutputShape;
					if (outShape.Hyperdimension != 2u) throw new ApplicationException("Output shape hyperdimension not equal to 2.");
					if (outShape[0] != 1) throw new ApplicationException($"Output shape 1rd dimension not equal to 1.");
					if (outShape[1] != Categories.Count) throw new ApplicationException($"Output shape 2nd dimension not equal to {Categories.Count}.");
				}

				prototype = builder;
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				builder?.Dispose();
				var message = string.Empty;
				if (ex is ApplicationException) message = ex.Message;
				else message = "Prototype network cannot be compiled.";
				MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
