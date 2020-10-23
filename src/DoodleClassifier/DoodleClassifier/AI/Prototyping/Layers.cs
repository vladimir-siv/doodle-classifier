using GrandIntelligence;

namespace DoodleClassifier
{
	public abstract class LayerPrototype
	{
		public abstract void InsertIn(NeuralBuilder builder);
	}

	public sealed class ConvPrototype : LayerPrototype
	{
		public uint Size { get; set; } = 8u;
		public Layer.Convolutional.Filter Filter { get; set; } = new Layer.Convolutional.Filter(7u, 7u);
		public Layer.Convolutional.Stride Stride { get; set; } = new Layer.Convolutional.Stride(1u, 1u);
		public Layer.Convolutional.Padding Padding { get; set; } = new Layer.Convolutional.Padding(3u, 3u);
		public ActivationFunction Activation { get; set; } = ActivationFunction.ELU;

		public override void InsertIn(NeuralBuilder builder)
		{
			builder.ConvLayer
			(
				Size,
				Filter,
				Stride,
				Padding,
				Activation
			);
		}
	}
	public sealed class PoolPrototype : LayerPrototype
	{
		public Layer.Pooling.Filter Filter { get; set; } = new Layer.Pooling.Filter(2u, 2u);
		public Layer.Pooling.Stride Stride { get; set; } = new Layer.Pooling.Stride(2u, 2u);
		public PoolingType Type { get; set; } = PoolingType.Max;

		public override void InsertIn(NeuralBuilder builder)
		{
			builder.PoolLayer
			(
				Filter,
				Stride,
				Type
			);
		}
	}
	public sealed class AdaptPrototype : LayerPrototype
	{
		public bool Normalize { get; set; } = false;
		public ActivationFunction Activation { get; set; } = ActivationFunction.LTU;
		public bool Reshape { get; set; } = true;
		public Shape Shape { get; set; } = Shape.As3D(8u, 8u, 8u);

		public override void InsertIn(NeuralBuilder builder)
		{
			if (Reshape)
			{
				builder.AdaptLayer
				(
					Shape,
					Normalize,
					Activation
				);
			}
			else
			{
				builder.AdaptLayer
				(
					Normalize,
					Activation
				);
			}
		}
	}
	public sealed class FCPrototype : LayerPrototype
	{
		public uint Size { get; set; } = 8u;
		public ActivationFunction Activation { get; set; } = ActivationFunction.ELU;

		public override void InsertIn(NeuralBuilder builder)
		{
			builder.FCLayer
			(
				Size,
				Activation
			);
		}
	}
}
