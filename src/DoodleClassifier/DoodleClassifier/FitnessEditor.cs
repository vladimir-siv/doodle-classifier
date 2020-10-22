using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class FitnessEditor : Form
	{
		private FitnessFunction function = null;

		public FitnessEditor()
		{
			InitializeComponent();
		}

		public void Edit(FitnessFunction function)
		{
			this.function = function;

			Display();

			if (ShowDialog() != DialogResult.OK) return;
			
			Parse();
		}

		private void Display()
		{
			tbHitsWeight.Text =				$"{function.HitsWeight}";
			tbHitsCorrection.Text =			$"{function.HitsCorrection}";
			tbHitsPower.Text =				$"{function.HitsPower}";
			
			tbMissWeight.Text =				$"{function.MissesWeight}";
			tbMissCorrection.Text =			$"{function.MissesCorrection}";
			tbMissPower.Text =				$"{function.MissesPower}";
			
			tbVarianceWeight.Text =			$"{function.VarianceWeight}";
			tbVarianceCorrection.Text =		$"{function.VarianceCorrection}";
			tbVariancePower.Text =			$"{function.VariancePower}";
		}

		private void Parse()
		{
			if
			(
				!double.TryParse(tbHitsWeight.Text, out var hitsWeight)
				||
				!double.TryParse(tbHitsCorrection.Text, out var hitsCorrection)
				||
				!double.TryParse(tbHitsPower.Text, out var hitsPower)

				||

				!double.TryParse(tbMissWeight.Text, out var missWeight)
				||
				!double.TryParse(tbMissCorrection.Text, out var missCorrection)
				||
				!double.TryParse(tbMissPower.Text, out var missPower)

				||

				!double.TryParse(tbVarianceWeight.Text, out var varianceWeight)
				||
				!double.TryParse(tbVarianceCorrection.Text, out var varianceCorrection)
				||
				!double.TryParse(tbVariancePower.Text, out var variancePower)
			)
			{
				MessageBox.Show("One or more values could not be parsed. Function editing was aborted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			function.HitsWeight = hitsWeight;
			function.HitsCorrection = hitsCorrection;
			function.HitsPower = hitsPower;

			function.MissesWeight = missWeight;
			function.MissesCorrection = missCorrection;
			function.MissesPower = missPower;

			function.VarianceWeight = varianceWeight;
			function.VarianceCorrection = varianceCorrection;
			function.VariancePower = variancePower;
		}
	}
}
