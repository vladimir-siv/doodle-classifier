using System;
using System.Collections.Generic;

namespace DoodleClassifier
{
	public sealed class RawData
	{
		private const uint HeaderLength = 80u;

		public const uint ImageWidth = 28u;
		public const uint ImageHeight = 28u;

		private static readonly Dictionary<string, RawData> DataCache = new Dictionary<string, RawData>();
		public static RawData From(string category)
		{
			if (DataCache.TryGetValue(category, out var data)) return data;
			var bytes = ResourceManager.ReadBytes(category);
			var categoryData = new RawData(category, bytes);
			DataCache.Add(category, categoryData);
			return categoryData;
		}

		public string Category { get; private set; }
		public uint ImageCount { get; private set; }

		private byte[] Bytes { get; set; }

		private RawData(string category, byte[] bytes)
		{
			Category = category;
			Bytes = bytes;
			ImageCount = ((uint)bytes.Length - HeaderLength) / (ImageWidth * ImageHeight);
		}

		public byte this[uint image, uint i, uint j] => this[image, i * ImageWidth + j];
		public byte this[uint image, int i, int j] => this[image, (uint)i, (uint)j];
		public byte this[uint image, uint index]
		{
			get
			{
				if (index > ImageWidth * ImageHeight) throw new IndexOutOfRangeException();
				return Bytes[HeaderLength + image * ImageWidth * ImageHeight + index];
			}
		}
	}
}
