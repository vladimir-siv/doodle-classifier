namespace DoodleClassifier
{
	partial class SizeChoice
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
			this.lblSize = new System.Windows.Forms.Label();
			this.nudSize = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(8, 8);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(30, 13);
			this.lblSize.TabIndex = 0;
			this.lblSize.Text = "Size:";
			// 
			// nudSize
			// 
			this.nudSize.Location = new System.Drawing.Point(71, 5);
			this.nudSize.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.nudSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudSize.Name = "nudSize";
			this.nudSize.Size = new System.Drawing.Size(85, 20);
			this.nudSize.TabIndex = 1;
			this.nudSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// SizeChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nudSize);
			this.Controls.Add(this.lblSize);
			this.Name = "SizeChoice";
			this.Size = new System.Drawing.Size(160, 30);
			((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.NumericUpDown nudSize;
	}
}
