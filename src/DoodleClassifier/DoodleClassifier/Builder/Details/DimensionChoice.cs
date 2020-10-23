using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class DimensionChoice : UserControl
	{
		public string Title
		{
			get
			{
				return gbDimension.Text;
			}
			set
			{
				gbDimension.Text = value;
			}
		}

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

		public DimensionChoice()
		{
			InitializeComponent();
		}
	}
}
