using System.IO;

namespace DoodleClassifier
{
	public static class ResourceManager
	{
		public const string ResourceDir = @"D:\Desktop\ai\#DATASETS\GQuickDraw\";
		public const string ResourceFormat = @"full_numpy_bitmap_{0}.npy";

		public static string GetResourcePath(string name) => Path.Combine(ResourceDir, string.Format(ResourceFormat, name));
		public static byte[] ReadBytes(string name) => File.ReadAllBytes(GetResourcePath(name));
	}
}
