using System;
using System.Collections.Generic;
using GrandIntelligence;

namespace DoodleClassifier
{
	public class NeuralPrototype : IDisposable
	{
		private readonly List<LayerPrototype> Layers = new List<LayerPrototype>(16);

		public int LayerCount => Layers.Count;

		private NeuralBuilder builder = null;
		public NeuralBuilder Builder
		{
			get
			{
				if (builder == null)
				{
					try
					{
						builder = new NeuralBuilder(Shape.As3D(RawData.ImageHeight, RawData.ImageWidth, 1u), bindInput: false);

						for (var i = 0; i < Layers.Count; ++i)
						{
							Layers[i].InsertIn(builder);
						}

						return builder;
					}
					catch
					{
						builder?.Dispose();
						builder = null;
						throw;
					}
				}

				return builder;
			}
		}

		public LayerPrototype this[int index]
		{
			get
			{
				return Layers[index];
			}
			set
			{
				if (builder != null) throw new InvalidOperationException("Prototype was already built and cannot be changed.");
				Layers[index] = value;
			}
		}

		public void Dispose()
		{
			builder?.Dispose();
			builder = null;
			Clear();
		}

		public void Add(LayerPrototype layer)
		{
			if (builder != null) throw new InvalidOperationException("Prototype was already built and cannot be changed.");
			Layers.Add(layer);
		}
		public void Clear()
		{
			if (builder != null) throw new InvalidOperationException("Prototype was already built and cannot be changed.");
			Layers.Clear();
		}
	}
}
