namespace DoodleClassifier
{
	partial class TestForm
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
			this.dgvDisplay = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvDisplay
			// 
			this.dgvDisplay.AllowUserToAddRows = false;
			this.dgvDisplay.AllowUserToDeleteRows = false;
			this.dgvDisplay.AllowUserToResizeColumns = false;
			this.dgvDisplay.AllowUserToResizeRows = false;
			this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvDisplay.ColumnHeadersVisible = false;
			this.dgvDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvDisplay.Location = new System.Drawing.Point(0, 0);
			this.dgvDisplay.Name = "dgvDisplay";
			this.dgvDisplay.ReadOnly = true;
			this.dgvDisplay.RowHeadersVisible = false;
			this.dgvDisplay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvDisplay.Size = new System.Drawing.Size(459, 420);
			this.dgvDisplay.TabIndex = 0;
			// 
			// TestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(459, 420);
			this.Controls.Add(this.dgvDisplay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TestForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "NT-GI Doodle Classifier Evaluation";
			((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvDisplay;
	}
}