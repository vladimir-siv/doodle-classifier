using System;
using System.Collections.Generic;
using System.IO;

namespace DoodleClassifier
{
	public sealed class RawData : IDisposable
	{
		private const uint HeaderLength = 80u;

		public const uint ImageWidth = 28u;
		public const uint ImageHeight = 28u;

		private static readonly Dictionary<string, RawData> DataCache = new Dictionary<string, RawData>();
		public static RawData From(string category)
		{
			if (DataCache.TryGetValue(category, out var data)) return data;
			var categoryData = new RawData(category);
			DataCache.Add(category, categoryData);
			return categoryData;
		}
		public static void Clean()
		{
			foreach (var category in Categories.Enumerate())
			{
				if (!DataCache.TryGetValue(category, out var data)) continue;
				data.Dispose();
			}
		}

		private readonly FileStream stream;
		private readonly FileInfo info;

		public string Category { get; private set; }
		public ulong ImageCount { get; private set; }

		private ulong current;
		private byte[] values;

		private RawData(string category)
		{
			var path = ResourceManager.GetResourcePath(category);
			stream = File.OpenRead(path);
			info = new FileInfo(path);

			Category = category;
			ImageCount = ((ulong)info.Length - HeaderLength) / (ImageWidth * ImageHeight);

			current = 0u;
			values = null;
		}

		public void Dispose() => stream.Dispose();

		public byte this[ulong image, int i, int j] => this[image, (uint)i, (uint)j];
		public byte this[ulong image, uint i, uint j] => this[image, i * ImageWidth + j];
		public byte this[ulong image, uint index]
		{
			get
			{
				if (image >= ImageCount || index >= ImageWidth * ImageHeight) throw new IndexOutOfRangeException();
				
				if (image != current || values == null)
				{
					values = values ?? new byte[ImageWidth * ImageHeight];
					stream.Seek((long)(HeaderLength + image * ImageWidth * ImageHeight), SeekOrigin.Begin);
					stream.Read(values, 0, values.Length);
				}

				current = image;
				return values[index];
			}
		}
	}
}
