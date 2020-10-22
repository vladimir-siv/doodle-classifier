using System;
using System.IO;
using System.Threading.Tasks;

namespace DoodleClassifier
{
	public static class ResourceManager
	{
		public static readonly string ResourceDir;
		public static readonly string ResourceFormat;

		static ResourceManager()
		{
			ResourceDir = Properties.Settings.Default.Location;
			ResourceFormat = Properties.Settings.Default.Format;

			if (!Directory.Exists(ResourceDir)) throw new ApplicationException("Dataset directory from app.config not found.");
		}

		public static string GetResourcePath(string name) => Path.Combine(ResourceDir, string.Format(ResourceFormat, name));
		public static Task<byte[]> ReadBytes(string name) => Task.Run(() => File.ReadAllBytes(GetResourcePath(name)));
	}
}
