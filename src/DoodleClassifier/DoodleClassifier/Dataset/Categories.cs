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

		public static IReadOnlyList<string> Enumerate() => categories;
	}
}
