using System;

namespace DoodleClassifier
{
	public class FitnessFunction
	{
		public double HitsPower { get; set; } = 2.17;
		public double HitsCorrection { get; set; } = 0.0;
		public double HitsWeight { get; set; } = 1.5;

		public double MissesPower { get; set; } = 2.0;
		public double MissesCorrection { get; set; } = 0.0;
		public double MissesWeight { get; set; } = 0.01;

		public double VariancePower { get; set; } = 2.0;
		public double VarianceCorrection { get; set; } = 0.0;
		public double VarianceWeight { get; set; } = 7.4;

		public float Calculate(uint[] hitdistribution, uint hits, uint misses)
		{
			var hitvar = hitdistribution.Variance();
			var reward = HitsWeight * Math.Pow(hits + HitsCorrection, HitsPower);
			var penalty = MissesWeight * Math.Pow(misses + MissesCorrection, MissesPower) + VarianceWeight * Math.Pow(hitvar + VarianceCorrection, VariancePower);
			return (float)(reward - penalty);
		}

		public override string ToString() => $"{{ [{HitsPower}, {HitsCorrection}, {HitsWeight}], [{MissesPower}, {MissesCorrection}, {MissesWeight}], [{VariancePower}, {VarianceCorrection}, {VarianceWeight}] }}";
	}
}
