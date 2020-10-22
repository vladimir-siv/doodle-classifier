using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class TestForm : Form
	{
		private readonly InputDataPoint Input = new InputDataPoint();
		private readonly float[] Output = new float[Categories.Count];

		public TestForm(string name = null)
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(name)) Text += $" <{name}>";
		}

		private async Task<(uint[,], uint, uint)> GenerateConfusionMatrix(NeuralNetwork network, uint dataCount)
		{
			var categories = Categories.Enumerate();
			var ds = Dataset.Surrogate;
			
			var matrix = new uint[categories.Count, categories.Count];
			var correct = 0u;
			var total = 0u;

			for (var c = 0; c < categories.Count; ++c)
			{
				var category = categories[c];

				var count = ds.TestSize(category);
				if (dataCount != 0u && dataCount < count) count = dataCount;

				for (var i = 0u; i < count; ++i)
				{
					var dp = ds.GetTestDataPoint(category, i);
					await ds.PreprocessImage(Input, dp);

					network.Eval(Input.Data);
					network.Output.Retrieve(Output);

					var predicted = Categories.From(Output);
					var p = Categories.IndexOf(predicted);

					++matrix[p, c];
					if (predicted == category) ++correct;
					++total;
				}
			}

			return (matrix, correct, total);
		}

		public async Task Evaluate(NeuralNetwork network, uint dataCount)
		{
			dgvDisplay.RowTemplate.Height = dgvDisplay.Height / ((int)Categories.Count + 1);

			var result = await Task.Run(async () =>
			{
				var table = new DataTable("evaluation");

				var categories = Categories.Enumerate();

				table.Columns.Add(new DataColumn("id", typeof(string)));

				for (var i = 0; i < categories.Count; ++i)
				{
					table.Columns.Add(new DataColumn(categories[i], typeof(string)));
				}

				var idrow = table.NewRow();
				table.Rows.Add(idrow);

				for (var i = 0; i < categories.Count; ++i)
				{
					idrow[categories[i]] = categories[i];
					var row = table.NewRow();
					table.Rows.Add(row);
					row["id"] = categories[i];
				}

				var confusion = await GenerateConfusionMatrix(network, dataCount);

				for (var i = 0; i < Categories.Count; ++i)
				{
					for (var j = 0; j < Categories.Count; ++j)
					{
						table.Rows[i + 1][j + 1] = confusion.Item1[i, j].ToString();
					}
				}

				return (table, confusion.Item2, confusion.Item3);
			});

			Text += $" [Hits: {result.Item2}/{result.Item3} | Misses: {result.Item3 - result.Item2}/{result.Item3}]";

			dgvDisplay.DataSource = result.Item1;

			var columnWidth = dgvDisplay.Width / dgvDisplay.Columns.Count;
			for (var i = 0; i < dgvDisplay.Columns.Count; ++i)
			{
				dgvDisplay.Columns[i].Width = columnWidth;
				dgvDisplay.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			}
			
			Show();
		}
	}
}
