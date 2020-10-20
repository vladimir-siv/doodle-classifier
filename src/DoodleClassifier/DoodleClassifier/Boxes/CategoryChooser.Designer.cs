namespace DoodleClassifier
{
	partial class CategoryChooser
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbCategories = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// lbCategories
			// 
			this.lbCategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbCategories.FormattingEnabled = true;
			this.lbCategories.Location = new System.Drawing.Point(0, 0);
			this.lbCategories.Name = "lbCategories";
			this.lbCategories.Size = new System.Drawing.Size(249, 278);
			this.lbCategories.TabIndex = 0;
			this.lbCategories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbCategories_MouseClick);
			this.lbCategories.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbCategories_MouseDoubleClick);
			// 
			// CategoryChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(249, 278);
			this.Controls.Add(this.lbCategories);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CategoryChooser";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select a category";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbCategories;
	}
}