using System;
using System.Collections;
using System.Collections.Generic;

namespace DoodleClassifier
{
	public sealed class Batch : IEnumerable<DataPoint>
	{
		private readonly DataPoint[] points;

		public bool IsFull => Count == Capacity;
		public uint Capacity => (uint)points.Length;
		public uint Count { get; private set; }

		public Batch(uint capacity)
		{
			points = new DataPoint[capacity];
			Count = 0u;
		}

		public DataPoint this[uint index]
		{
			get
			{
				if (index >= Count) throw new IndexOutOfRangeException();
				return points[index];
			}
			set
			{
				if (index >= Count) throw new IndexOutOfRangeException();
				points[index] = value;
			}
		}

		public void Add(DataPoint dp)
		{
			if (Count >= points.Length) throw new InvalidOperationException("Batch already full.");
			points[Count++] = dp;
		}

		public void Clear() => Count = 0u;
		public IEnumerator<DataPoint> GetEnumerator() => (IEnumerator<DataPoint>)points.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => points.GetEnumerator();
	}
}
