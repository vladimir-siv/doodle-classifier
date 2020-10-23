namespace DoodleClassifier
{
	partial class DimensionChoice
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
			this.gbDimension = new System.Windows.Forms.GroupBox();
			this.nudHeight = new System.Windows.Forms.NumericUpDown();
			this.lblHeight = new System.Windows.Forms.Label();
			this.nudWidth = new System.Windows.Forms.NumericUpDown();
			this.lblWidth = new System.Windows.Forms.Label();
			this.gbDimension.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// gbDimension
			// 
			this.gbDimension.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbDimension.Controls.Add(this.nudHeight);
			this.gbDimension.Controls.Add(this.lblHeight);
			this.gbDimension.Controls.Add(this.nudWidth);
			this.gbDimension.Controls.Add(this.lblWidth);
			this.gbDimension.Location = new System.Drawing.Point(3, 3);
			this.gbDimension.Name = "gbDimension";
			this.gbDimension.Size = new System.Drawing.Size(154, 74);
			this.gbDimension.TabIndex = 0;
			this.gbDimension.TabStop = false;
			this.gbDimension.Text = "Dimension";
			// 
			// nudHeight
			// 
			this.nudHeight.Location = new System.Drawing.Point(63, 43);
			this.nudHeight.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudHeight.Name = "nudHeight";
			this.nudHeight.Size = new System.Drawing.Size(85, 20);
			this.nudHeight.TabIndex = 3;
			this.nudHeight.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(4, 46);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(41, 13);
			this.lblHeight.TabIndex = 2;
			this.lblHeight.Text = "Height:";
			// 
			// nudWidth
			// 
			this.nudWidth.Location = new System.Drawing.Point(63, 17);
			this.nudWidth.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudWidth.Name = "nudWidth";
			this.nudWidth.Size = new System.Drawing.Size(85, 20);
			this.nudWidth.TabIndex = 1;
			this.nudWidth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(4, 20);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(38, 13);
			this.lblWidth.TabIndex = 0;
			this.lblWidth.Text = "Width:";
			// 
			// DimensionChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbDimension);
			this.Name = "DimensionChoice";
			this.Size = new System.Drawing.Size(160, 80);
			this.gbDimension.ResumeLayout(false);
			this.gbDimension.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbDimension;
		private System.Windows.Forms.NumericUpDown nudWidth;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.NumericUpDown nudHeight;
		private System.Windows.Forms.Label lblHeight;
	}
}
