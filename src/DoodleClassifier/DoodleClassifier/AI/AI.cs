using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GrandIntelligence;

namespace DoodleClassifier
{
	public static class AI
	{
		public enum Crossover
		{
			RUC = 1,
			RFC = 2,
			SEC = 3
		}

		#region Utility

		private static List<(uint[], uint, uint)> outputClassification = null;
		public static List<(uint[], uint, uint)> OutputClassification
		{
			get
			{
				if (outputClassification == null) outputClassification = new List<(uint[], uint, uint)>();
				return outputClassification;
			}
		}

		private static float[] outputBuffer = null;
		public static float[] OutputBuffer
		{
			get
			{
				if (outputBuffer == null) outputBuffer = new float[Categories.Count];
				return outputBuffer;
			}
		}

		#endregion

		#region Global

		private static NeuralBuilder brainPrototype = null;
		public static NeuralBuilder BrainPrototype
		{
			get
			{
				if (brainPrototype == null)
				{
					brainPrototype = new NeuralBuilder(Shape.As3D(RawData.ImageHeight, RawData.ImageWidth, 1u), bindInput: false);

					brainPrototype.ConvLayer
					(
						32u,
						new Layer.Convolutional.Filter(7u, 7u),
						new Layer.Convolutional.Stride(1u, 1u),
						new Layer.Convolutional.Padding(3u, 3u),
						ActivationFunction.ELU
					);
					brainPrototype.ConvLayer
					(
						32u,
						new Layer.Convolutional.Filter(7u, 7u),
						new Layer.Convolutional.Stride(1u, 1u),
						new Layer.Convolutional.Padding(3u, 3u),
						ActivationFunction.ELU
					);
					brainPrototype.PoolLayer
					(
						new Layer.Pooling.Filter(2u, 2u),
						new Layer.Pooling.Stride(2u, 2u),
						PoolingType.Max
					);
					brainPrototype.AdaptLayer
					(

					);
					brainPrototype.ConvLayer
					(
						16u,
						new Layer.Convolutional.Filter(5u, 5u),
						new Layer.Convolutional.Stride(1u, 1u),
						new Layer.Convolutional.Padding(2u, 2u),
						ActivationFunction.ELU
					);
					brainPrototype.ConvLayer
					(
						16u,
						new Layer.Convolutional.Filter(5u, 5u),
						new Layer.Convolutional.Stride(1u, 1u),
						new Layer.Convolutional.Padding(2u, 2u),
						ActivationFunction.ELU
					);
					brainPrototype.PoolLayer
					(
						new Layer.Pooling.Filter(2u, 2u),
						new Layer.Pooling.Stride(2u, 2u),
						PoolingType.Max
					);
					brainPrototype.AdaptLayer
					(

					);
					brainPrototype.ConvLayer
					(
						8u,
						new Layer.Convolutional.Filter(3u, 3u),
						new Layer.Convolutional.Stride(1u, 1u),
						new Layer.Convolutional.Padding(1u, 1u),
						ActivationFunction.ELU
					);
					brainPrototype.ConvLayer
					(
						8u,
						new Layer.Convolutional.Filter(3u, 3u),
						new Layer.Convolutional.Stride(2u, 2u),
						new Layer.Convolutional.Padding(1u, 1u),
						ActivationFunction.ELU
					);
					brainPrototype.AdaptLayer
					(
						Shape.As2D(1u, 4u*4u*8u),
						true
					);
					brainPrototype.FCLayer
					(
						32u,
						ActivationFunction.ELU
					);
					brainPrototype.FCLayer
					(
						Categories.Count,
						ActivationFunction.Softmax
					);
				}
				return brainPrototype;
			}
		}

		public static DarwinBgea System { get; private set; } = null;
		public static InputDataPoint Input { get; private set; } = null;
		public static Batch Batch { get; private set; } = null;

		public static event Action EvaluationPrepare;
		public static event Action<uint, uint, uint, uint> PointEvaluated;
		public static event Action<uint, uint> PopulationEvaluated;

		#endregion

		#region Initialization

		public static async Task Init(Crossover crossover = Crossover.SEC, uint populationSize = 100u, uint parentCount = 2u, float mutationRate = 15.0f, uint generations = 1000u)
		{
			if (System != null) return;

			var device = Device.Active;

			Input = new InputDataPoint();

			var firstGeneration = new Population(populationSize);

			using (var randomize = device.Prepare("randomize"))
			using (var it = new NeuralIterator())
			{
				randomize.Set('U');
				randomize.Set(-1.0f, 0);
				randomize.Set(+1.0f, 1);

				for (var i = 0u; i < populationSize; ++i)
				{
					var brain = new BasicBrain(BrainPrototype);

					for (var param = it.Begin(brain.NeuralNetwork); param != null; param = it.Next())
					{
						randomize.Set(param.Memory);
						await randomize.Invoke();
					}

					firstGeneration.Add(brain);
				}
			}
			
			Func<uint, uint, Reproduction> rep = null;

			switch (crossover)
			{
				case Crossover.RUC: rep = BasicBrain.RandomUniformCrossover; break;
				case Crossover.RFC: rep = BasicBrain.RandomFullCrossover; break;
				case Crossover.SEC: rep = BasicBrain.SequentialEvenCrossover; break;
			}

			System = new DarwinBgea
			(
				firstGeneration,
				Selection.RandFit(parentCount),
				rep(populationSize, ((BasicBrain)firstGeneration[0u]).NeuralNetwork.Params),
				generations,
				mutationRate
			);
		}

		public static void Dispose()
		{
			brainPrototype?.Dispose();
			brainPrototype = null;

			Batch = null;

			Input?.Dispose();
			Input = null;

			System?.Dispose();
			System = null;
		}

		#endregion

		#region Training

		private static bool stopTrain = false;

		private static async Task EvaluatePopulation(Population population, Batch batch)
		{
			var ds = Dataset.Surrogate;
			OutputClassification.Clear();

			for (var i = 0u; i < population.Size; ++i)
			{
				OutputClassification.Add((new uint[Categories.Count], 0u, 0u));
			}

			EvaluationPrepare?.Invoke();

			var totalhits = 0u;
			var totalevals = 0u;

			for (var p = 0u; p < batch.Count; ++p)
			{
				if (stopTrain) break;

				await ds.PreprocessImage(Input, batch[p]);

				var hits = 0u;

				for (var i = 0u; i < population.Size; ++i)
				{
					var brain = (BasicBrain)population[i];
					brain.NeuralNetwork.Eval(Input.Data);
					brain.NeuralNetwork.Output.Retrieve(OutputBuffer);

					var predicted = Categories.From(OutputBuffer);

					var progress = OutputClassification[(int)i];

					var hit = 0u;
					var miss = 0u;

					if (predicted == Input.ClassString)
					{
						var c = Categories.IndexOf(Input.ClassString);
						++progress.Item1[c];
						++hit;
					}
					else ++miss;

					progress = (progress.Item1, progress.Item2 + hit, progress.Item3 + miss);
					hits += hit;

					OutputClassification[(int)i] = progress;
				}

				totalhits += hits;
				totalevals += population.Size;

				PointEvaluated?.Invoke(hits, population.Size, p, batch.Count);
			}

			for (var i = 0u; i < population.Size; ++i)
			{
				var brain = (BasicBrain)population[i];
				var progress = OutputClassification[(int)i];
				var hits = progress.Item2;
				var misses = progress.Item3;
				var hitvar = progress.Item1.Variance();

				var reward = Math.Pow(hits, 3.0);
				var penalty = Math.Pow(hitvar * 10.0, 2.0) + Math.Pow(misses / 10.0, 2.0);

				var evalue = (float)(reward - penalty);
				if (evalue < 1e-8f) evalue = 1e-8f;

				brain.EvolutionValue = evalue;
			}

			PopulationEvaluated?.Invoke(totalhits, totalevals);
		}

		public static async Task<bool> Train(uint localCount, uint globalCount = 0u)
		{
			if (System == null) throw new InvalidOperationException();
			if (Batch != null) throw new InvalidOperationException();
			
			stopTrain = false;

			await Task.Run(async () =>
			{
				Batch = new Batch(Categories.Count * localCount + globalCount);
				var ds = Dataset.Surrogate;

				do
				{
					if (stopTrain) break;
					var population = System.Generation;
					await ds.RandomFillBatch(Batch, localCount, globalCount);
					await EvaluatePopulation(population, Batch);
					if (stopTrain) break;
				}
				while (System.Cycle());
			});

			return !stopTrain;
		}

		public static void StopTrain() => stopTrain = true;

		#endregion

		#region Testing

		private static NeuralNetwork Best(Population population)
		{
			var best = (BasicBrain)null;

			for (var i = 0u; i < population.Size; ++i)
			{
				var brain = (BasicBrain)population[i];

				if (best == null || brain.EvolutionValue > best.EvolutionValue)
				{
					best = brain;
				}
			}

			return best.NeuralNetwork;
		}

		public static NeuralNetwork Best() => Best(System.Generation);
		public static NeuralNetwork PrevBest() => Best(System.Previous);

		#endregion
	}
}
