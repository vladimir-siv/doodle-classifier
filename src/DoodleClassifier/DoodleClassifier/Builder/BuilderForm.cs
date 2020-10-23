using System;
using System.Drawing;
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

		#region UI

		private void Add(UserControl control)
		{
			var ypos = 0;
			
			if (pnlLayers.Controls.Count > 0)
			{
				var last = pnlLayers.Controls[pnlLayers.Controls.Count - 1];
				ypos = last.Location.Y + last.Height;
			}

			control.Location = new Point(10, ypos);
			control.TabIndex = pnlLayers.Controls.Count;
			pnlLayers.Controls.Add(control);
		}
		private void RemoveLast()
		{
			if (pnlLayers.Controls.Count == 0) return;
			pnlLayers.Controls.RemoveAt(pnlLayers.Controls.Count - 1);
		}
		private void Clear()
		{
			pnlLayers.Controls.Clear();
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
				case "Convolutional": Add(new ConvLayer()); break;
				case "Pooling": Add(new PoolLayer()); break;
				case "Adapting": Add(new AdaptLayer()); break;
				case "FullyConnected": Add(new FCLayer()); break;
			}
		}
		private void btnRemoveLast_Click(object sender, EventArgs e)
		{
			RemoveLast();
		}
		private void btnClear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		#endregion

		public NeuralBuilder Build()
		{
			ShowDialog();
			return prototype;
		}

		private NeuralBuilder BuildPrototype()
		{
			throw new NotImplementedException();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			NeuralBuilder builder = null;

			try
			{
				builder = BuildPrototype();

				using (var nn = builder.Compile())
				{
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
