using System;
using System.Drawing;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class BuilderForm : Form
	{
		private NeuralPrototype prototype = null;

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

		public NeuralPrototype Build(NeuralPrototype current)
		{
			prototype = current;
			DisplayPrototype(current);
			ShowDialog();
			return prototype;
		}

		private NeuralPrototype BuildPrototype()
		{
			var proto = new NeuralPrototype();

			for (var i = 0; i < pnlLayers.Controls.Count; ++i)
			{
				var control = pnlLayers.Controls[i];
				if (!(control is UserControl)) continue;

				else if (control is ConvLayer conv)
				{
					proto.Add
					(
						new ConvPrototype
						{
							Size = conv.LayerSize,
							Filter = conv.LayerFilter,
							Stride = conv.LayerStride,
							Padding = conv.LayerPadding,
							Activation = conv.LayerActivation
						}
					);
				}
				else if (control is PoolLayer pool)
				{
					proto.Add
					(
						new PoolPrototype
						{
							Filter = pool.LayerFilter,
							Stride = pool.LayerStride,
							Type = pool.LayerPoolingType
						}
					);
				}
				else if (control is AdaptLayer adapt)
				{
					proto.Add
					(
						new AdaptPrototype
						{
							Normalize = adapt.LayerNormalize,
							Activation = adapt.LayerActivation,
							Reshape = adapt.LayerReshape,
							Shape = adapt.LayerReshape ? adapt.LayerShape : Shape.Scalar()
						}
					);
				}
				else if (control is FCLayer fc)
				{
					proto.Add
					(
						new FCPrototype
						{
							Size = fc.LayerSize,
							Activation = fc.LayerActivation
						}
					);
				}
			}

			return proto;
		}
		private void DisplayPrototype(NeuralPrototype proto)
		{
			if (proto == null) throw new ArgumentNullException(nameof(proto));

			Clear();

			for (var i = 0; i < proto.LayerCount; ++i)
			{
				var layer = proto[i];
				if (!(layer is LayerPrototype)) continue;

				else if (layer is ConvPrototype conv)
				{
					Add
					(
						new ConvLayer
						{
							LayerSize = conv.Size,
							LayerFilter = conv.Filter,
							LayerStride = conv.Stride,
							LayerPadding = conv.Padding,
							LayerActivation = conv.Activation
						}
					);
				}
				else if (layer is PoolPrototype pool)
				{
					Add
					(
						new PoolLayer
						{
							LayerFilter = pool.Filter,
							LayerStride = pool.Stride,
							LayerPoolingType = pool.Type,
						}
					);
				}
				else if (layer is AdaptPrototype adapt)
				{
					Add
					(
						new AdaptLayer
						{
							LayerNormalize = adapt.Normalize,
							LayerActivation = adapt.Activation,
							LayerReshape = adapt.Reshape,
							LayerShape = adapt.Reshape ? adapt.Shape : Shape.Scalar()
						}
					);
				}
				else if (layer is FCPrototype fc)
				{
					Add
					(
						new FCLayer
						{
							LayerSize = fc.Size,
							LayerActivation = fc.Activation
						}
					);
				}
			}
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			NeuralPrototype proto = null;

			try
			{
				proto = BuildPrototype();

				using (var nn = proto.Builder.Compile())
				{
					var outShape = nn.OutputShape;
					if (outShape.Hyperdimension != 2u) throw new ApplicationException("Output shape hyperdimension not equal to 2.");
					if (outShape[0] != 1) throw new ApplicationException($"Output shape 1rd dimension not equal to 1.");
					if (outShape[1] != Categories.Count) throw new ApplicationException($"Output shape 2nd dimension not equal to {Categories.Count}.");
				}

				prototype = proto;
				MessageBox.Show("Prototype created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				proto?.Dispose();
				var message = string.Empty;
				if (ex is ApplicationException) message = ex.Message;
				else message = "Prototype network cannot be compiled.";
				MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
