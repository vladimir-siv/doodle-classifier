using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class SizeChoice : UserControl
	{
		public uint ChosenSize
		{
			get
			{
				return (uint)nudSize.Value;
			}
			set
			{
				nudSize.Value = value;
			}
		}

		public SizeChoice()
		{
			InitializeComponent();
		}
	}
}
