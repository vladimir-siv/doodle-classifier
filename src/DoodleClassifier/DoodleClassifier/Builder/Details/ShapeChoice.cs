using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class ShapeChoice : UserControl
	{
		public uint ChosenWidth
		{
			get
			{
				return (uint)nudWidth.Value;
			}
			set
			{
				nudWidth.Value = value;
			}
		}
		public uint ChosenHeight
		{
			get
			{
				return (uint)nudHeight.Value;
			}
			set
			{
				nudHeight.Value = value;
			}
		}
		public uint ChosenDepth
		{
			get
			{
				return (uint)nudDepth.Value;
			}
			set
			{
				nudDepth.Value = value;
			}
		}

		public ShapeChoice()
		{
			InitializeComponent();
		}
	}
}
