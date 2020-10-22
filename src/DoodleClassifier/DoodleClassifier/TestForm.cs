using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrandIntelligence;

namespace DoodleClassifier
{
	public partial class TestForm : Form
	{
		public TestForm(string name = null)
		{
			InitializeComponent();
			if (!string.IsNullOrWhiteSpace(name)) Text += $" [{name}]";
		}

		public async Task Evaluate(NeuralNetwork network, uint dataCount)
		{
			dgvDisplay.RowTemplate.Height = dgvDisplay.Height / ((int)Categories.Count + 1);

			dgvDisplay.DataSource = await Task.Run(() =>
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

				return table;
			});

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
