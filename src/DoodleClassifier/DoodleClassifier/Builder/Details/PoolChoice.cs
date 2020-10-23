using System;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class PoolChoice : UserControl
	{
		public PoolingType Pooling
		{
			get
			{
				if (Enum.TryParse<PoolingType>(cbPool.Text, out var pool)) return pool;
				throw new FormatException("Unknown pooling.");
			}
			set
			{
				cbPool.Text = value.ToString();
			}
		}

		public PoolChoice()
		{
			InitializeComponent();
		}
	}
}
