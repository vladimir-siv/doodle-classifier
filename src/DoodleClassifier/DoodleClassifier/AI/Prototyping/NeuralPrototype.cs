using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
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

		public Task<NeuralNetwork> Load(string file)
		{
			Clear();

			return Task.Run(() =>
			{
				var doc = new XmlDocument();

				doc.Load(file);

				var root = doc.FirstChild;
				if (root is XmlDeclaration) root = root.NextSibling;

				if (root.Name != "neural") throw new FormatException("Invalid root tag.");

				var prototype = root.FirstChild;
				if (prototype.Name != "prototype") throw new FormatException("Invalid prototype specification.");

				foreach (XmlElement layer in prototype.ChildNodes)
				{
					if (layer.Name != "layer") throw new FormatException("Invalid layer specification.");
					if (!layer.HasAttribute("type")) throw new FormatException("Invalid layer type specification.");
					var type = Type.GetType(layer.GetAttribute("type"));
					if (type == null) throw new FormatException("Unknown layer type.");
					var layerprototype = (LayerPrototype)Activator.CreateInstance(type);
					try { layerprototype.Load(layer); }
					catch { throw new FormatException($"Layer loading failed due to incorrect format [Type: {type.Name}]."); }
					Layers.Add(layerprototype);
				}

				var network = prototype.NextSibling;
				if (network == null) return null;

				if (network.Name != "network") throw new FormatException("Invalid network parameter specification.");
				var parameters = network.FirstChild;
				if (!(parameters is XmlText ptext)) throw new FormatException("Could not parse network parameters.");

				var neuralnetwork = Builder.Compile();
				try { neuralnetwork.LoadParams(ptext.Value); }
				catch { neuralnetwork.Dispose(); throw; }
				return neuralnetwork;
			});
		}
		public Task Save(string file, NeuralNetwork network = null)
		{
			return Task.Run(() =>
			{
				var doc = new XmlDocument();
				doc.AppendChild(doc.CreateXmlDeclaration("1.0", "UTF-8", null));

				var root = doc.AppendChild(doc.CreateElement("neural"));
				var proto = root.AppendChild(doc.CreateElement("prototype"));

				for (var i = 0; i < Layers.Count; ++i)
				{
					var layer = (XmlElement)proto.AppendChild(doc.CreateElement("layer"));
					layer.SetAttribute("type", Layers[i].GetType().AssemblyQualifiedName);
					Layers[i].Save(layer);
				}

				if (network != null)
				{
					var net = root.AppendChild(doc.CreateElement("network"));
					var netparams = network.SaveParams();
					net.AppendChild(doc.CreateTextNode(netparams));
				}

				doc.Save(file);
			});
		}
	}
}
