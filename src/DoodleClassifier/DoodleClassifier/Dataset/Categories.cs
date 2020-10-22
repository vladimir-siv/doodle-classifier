using System;
using System.Collections.Generic;
using System.IO;

namespace DoodleClassifier
{
	public static class Categories
	{
		private static readonly List<string> categories = new List<string>();
		
		private static readonly Dictionary<string, float[]> oneHots = new Dictionary<string, float[]>();
		private static readonly Dictionary<string, uint> indices = new Dictionary<string, uint>();

		static Categories()
		{
			var classes = Properties.Settings.Default.Categories;

			for (var i = 0; i < classes.Count; ++i)
			{
				var path = ResourceManager.GetResourcePath(classes[i]);
				if (!File.Exists(path)) throw new ApplicationException($"Category '{classes[i]}' dataset file not found.");
				categories.Add(classes[i]);
			}

			for (var i = 0; i < categories.Count; ++i)
			{
				var oneHot = new float[categories.Count];
				oneHot[i] = 1f;
				oneHots.Add(categories[i], oneHot);
				indices.Add(categories[i], (uint)i);
			}
		}

		public static uint Count => (uint)categories.Count;
		public static IReadOnlyList<string> Enumerate() => categories;

		public static bool IsValid(string name) => oneHots.ContainsKey(name);
		public static float[] OneHot(string name) => oneHots[name];
		public static uint IndexOf(string name) => indices[name];
		public static string From(float[] oneHot)
		{
			if (oneHot.Length != categories.Count) throw new InvalidOperationException();

			var ind = -1;
			var max = float.NegativeInfinity;

			for (var i = 0; i < oneHot.Length; ++i)
			{
				if (oneHot[i] > max)
				{
					max = oneHot[i];
					ind = i;
				}
			}

			return categories[ind];
		}
		public static string RandomCategory() => categories[Extension.RandomInt(categories.Count)];
	}
}
