using System.Windows.Forms;

namespace DoodleClassifier
{
	public partial class CategoryChooser : Form
	{
		public CategoryChooser()
		{
			InitializeComponent();
			foreach (var category in Categories.Enumerate()) lbCategories.Items.Add(category);
		}

		public new string ShowDialog()
		{
			var result = base.ShowDialog();
			if (result != DialogResult.OK) return null;
			return (string)lbCategories.SelectedItem;
		}

		private void lbCategories_MouseClick(object sender, MouseEventArgs e)
		{
			var index = lbCategories.IndexFromPoint(e.X, e.Y);
			lbCategories.SelectedIndex = index;
		}

		private void lbCategories_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (lbCategories.SelectedIndex != -1) DialogResult = DialogResult.OK;
		}
	}
}
