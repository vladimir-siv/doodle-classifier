using System;
using System.Collections.Generic;

namespace DoodleClassifier
{
	public static class Categories
	{
		public const string Airplanes = "airplane";
		public const string Angels = "angel";
		public const string Apples = "apple";
		public const string Bananas = "banana";
		public const string Cats = "cat";
		public const string Dogs = "dog";
		public const string Dragons = "dragon";

		private static readonly List<string> categories = new List<string>()
		{
			Airplanes,
			Angels,
			Apples,
			Bananas,
			Cats,
			Dogs,
			Dragons
		};
		
		private static readonly Dictionary<string, float[]> oneHots = new Dictionary<string, float[]>();

		static Categories()
		{
			for (var i = 0; i < categories.Count; ++i)
			{
				var oneHot = new float[categories.Count];
				oneHot[i] = 1f;
				oneHots.Add(categories[i], oneHot);
			}
		}

		public static uint Count => (uint)categories.Count;
		public static IReadOnlyList<string> Enumerate() => categories;

		public static bool IsValid(string name) => oneHots.ContainsKey(name);
		public static float[] OneHot(string name) => oneHots[name];
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
