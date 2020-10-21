using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GrandIntelligence;

namespace DoodleClassifier
{
	public static class AI
	{
		#region Utility

		private static List<(uint, uint)> outputClassification = null;
		public static List<(uint, uint)> OutputClassification
		{
			get
			{
				if (outputClassification == null) outputClassification = new List<(uint, uint)>();
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

		public static event Action EvaluationPrepared;
		public static event Action<uint, uint, uint, uint> PointEvaluated;
		public static event Action PopulationEvaluated;

		#endregion

		#region Initialization

		public static async Task Init(uint populationSize = 100u, uint parentCount = 2u, float mutationRate = 5.0f, uint generations = 100u)
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

			System = new DarwinBgea
			(
				firstGeneration,
				Selection.RandFit(parentCount),
				BasicBrain.Mating(populationSize, ((BasicBrain)firstGeneration[0u]).NeuralNetwork.Params),
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
				OutputClassification.Add((0u, 0u));
			}

			for (var p = 0u; p < batch.Count; ++p)
			{
				if (stopTrain) break;

				var dp = batch[p];
				await ds.PreprocessImage(Input, dp.Category, dp.Image);

				var hits = 0u;
				var misses = 0u;

				for (var i = 0u; i < population.Size; ++i)
				{
					var brain = (BasicBrain)population[i];
					brain.NeuralNetwork.Eval(Input.Data);
					brain.NeuralNetwork.Output.Retrieve(OutputBuffer);

					var decision = Categories.From(OutputBuffer);

					var progress = OutputClassification[(int)i];

					var hit = 0u;
					var miss = 0u;

					if (decision == Input.ClassString) ++hit;
					else ++miss;

					progress = (progress.Item1 + hit, progress.Item2 + miss);
					hits += hit;
					misses += miss;

					OutputClassification[(int)i] = progress;
				}

				PointEvaluated?.Invoke(hits, misses, p, batch.Count);
			}

			for (var i = 0u; i < population.Size; ++i)
			{
				var brain = (BasicBrain)population[i];
				var progress = OutputClassification[(int)i];

				var reward = Math.Pow(progress.Item1, 4.0);
				var penalty = Math.Pow(progress.Item2 / 10.0, 2.0);
				var evalue =  Math.Min(reward - penalty, 1e-8f);

				brain.EvolutionValue = (float)evalue;
			}
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
					EvaluationPrepared?.Invoke();
					await EvaluatePopulation(population, Batch);
					if (stopTrain) break;
					PopulationEvaluated?.Invoke();
				}
				while (System.Cycle());
			});

			return !stopTrain;
		}

		public static void StopTrain() => stopTrain = true;

		#endregion

		#region Testing

		public static NeuralNetwork Best()
		{
			var best = (BasicBrain)null;

			var population = System.Generation;

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

		public static void Test()
		{

		}

		#endregion
	}
}
