using System.IO;
using System.Threading.Tasks;

namespace DoodleClassifier
{
	public static class ResourceManager
	{
		public const string ResourceDir = @"S:\#DATASETS\GQuickDraw\";
		public const string ResourceFormat = @"full_numpy_bitmap_{0}.npy";

		public static string GetResourcePath(string name) => Path.Combine(ResourceDir, string.Format(ResourceFormat, name));
		public static Task<byte[]> ReadBytes(string name) => Task.Run(() => File.ReadAllBytes(GetResourcePath(name)));
	}
}
