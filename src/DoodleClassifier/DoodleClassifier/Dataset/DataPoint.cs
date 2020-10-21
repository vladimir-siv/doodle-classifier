namespace DoodleClassifier
{
	public struct DataPoint
	{
		public string Category { get; set; }
		public ulong Image { get; set; }

		public DataPoint(string category, ulong image)
		{
			Category = category;
			Image = image;
		}
	}
}
