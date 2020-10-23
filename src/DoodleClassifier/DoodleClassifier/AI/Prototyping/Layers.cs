using System;
using System.Xml;
using GrandIntelligence;

namespace DoodleClassifier
{
	public abstract class LayerPrototype
	{
		public abstract void InsertIn(NeuralBuilder builder);
		public abstract void Load(XmlElement layer);
		public abstract void Save(XmlElement layer);
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

		public override void Load(XmlElement layer)
		{
			Size = Convert.ToUInt32(layer.GetAttribute("size"));
			Filter = layer.GetAttribute("filter").DeserializeAsConvFilter();
			Stride = layer.GetAttribute("stride").DeserializeAsConvStride();
			Padding = layer.GetAttribute("padding").DeserializeAsConvPadding();
			Activation = (ActivationFunction)Enum.Parse(typeof(ActivationFunction), layer.GetAttribute("activation"));
		}
		public override void Save(XmlElement layer)
		{
			layer.SetAttribute("size", Size.ToString());
			layer.SetAttribute("filter", Filter.Serialize());
			layer.SetAttribute("stride", Stride.Serialize());
			layer.SetAttribute("padding", Padding.Serialize());
			layer.SetAttribute("activation", Activation.ToString());
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

		public override void Load(XmlElement layer)
		{
			Filter = layer.GetAttribute("filter").DeserializeAsPoolFilter();
			Stride = layer.GetAttribute("stride").DeserializeAsPoolStride();
			Type = (PoolingType)Enum.Parse(typeof(PoolingType), layer.GetAttribute("pooling-type"));
		}
		public override void Save(XmlElement layer)
		{
			layer.SetAttribute("filter", Filter.Serialize());
			layer.SetAttribute("stride", Stride.Serialize());
			layer.SetAttribute("pooling-type", Type.ToString());
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

		public override void Load(XmlElement layer)
		{
			Normalize = Convert.ToBoolean(layer.GetAttribute("normalize"));
			Activation = (ActivationFunction)Enum.Parse(typeof(ActivationFunction), layer.GetAttribute("activation"));
			Reshape = Convert.ToBoolean(layer.GetAttribute("reshape"));
			if (Reshape) Shape = layer.GetAttribute("shape").DeserializeAsShape();
		}
		public override void Save(XmlElement layer)
		{
			layer.SetAttribute("normalize", Normalize.ToString().ToLowerInvariant());
			layer.SetAttribute("activation", Activation.ToString());
			layer.SetAttribute("reshape", Reshape.ToString().ToLowerInvariant());
			if (Reshape) layer.SetAttribute("shape", Shape.Serialize());
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

		public override void Load(XmlElement layer)
		{
			Size = Convert.ToUInt32(layer.GetAttribute("size"));
			Activation = (ActivationFunction)Enum.Parse(typeof(ActivationFunction), layer.GetAttribute("activation"));
		}
		public override void Save(XmlElement layer)
		{
			layer.SetAttribute("size", Size.ToString());
			layer.SetAttribute("activation", Activation.ToString());
		}
	}
}
