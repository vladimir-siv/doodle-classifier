namespace DoodleClassifier
{
	partial class PoolChoice
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblPooling = new System.Windows.Forms.Label();
			this.cbPool = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblPooling
			// 
			this.lblPooling.AutoSize = true;
			this.lblPooling.Location = new System.Drawing.Point(8, 8);
			this.lblPooling.Name = "lblPooling";
			this.lblPooling.Size = new System.Drawing.Size(45, 13);
			this.lblPooling.TabIndex = 0;
			this.lblPooling.Text = "Pooling:";
			// 
			// cbPool
			// 
			this.cbPool.FormattingEnabled = true;
			this.cbPool.Items.AddRange(new object[] {
            "None",
            "Max",
            "Avg"});
			this.cbPool.Location = new System.Drawing.Point(71, 5);
			this.cbPool.Name = "cbPool";
			this.cbPool.Size = new System.Drawing.Size(85, 21);
			this.cbPool.TabIndex = 1;
			this.cbPool.Text = "None";
			// 
			// PoolChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblPooling);
			this.Controls.Add(this.cbPool);
			this.Name = "PoolChoice";
			this.Size = new System.Drawing.Size(160, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblPooling;
		private System.Windows.Forms.ComboBox cbPool;
	}
}
