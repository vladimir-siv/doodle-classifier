namespace DoodleClassifier
{
	partial class ShapeChoice
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
			this.gbShape = new System.Windows.Forms.GroupBox();
			this.nudDepth = new System.Windows.Forms.NumericUpDown();
			this.lblDepth = new System.Windows.Forms.Label();
			this.nudHeight = new System.Windows.Forms.NumericUpDown();
			this.lblHeight = new System.Windows.Forms.Label();
			this.nudWidth = new System.Windows.Forms.NumericUpDown();
			this.lblWidth = new System.Windows.Forms.Label();
			this.gbShape.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDepth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
			this.SuspendLayout();
			// 
			// gbShape
			// 
			this.gbShape.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbShape.Controls.Add(this.nudDepth);
			this.gbShape.Controls.Add(this.lblDepth);
			this.gbShape.Controls.Add(this.nudHeight);
			this.gbShape.Controls.Add(this.lblHeight);
			this.gbShape.Controls.Add(this.nudWidth);
			this.gbShape.Controls.Add(this.lblWidth);
			this.gbShape.Location = new System.Drawing.Point(3, 3);
			this.gbShape.Name = "gbShape";
			this.gbShape.Size = new System.Drawing.Size(154, 99);
			this.gbShape.TabIndex = 0;
			this.gbShape.TabStop = false;
			this.gbShape.Text = "Shape";
			// 
			// nudDepth
			// 
			this.nudDepth.Location = new System.Drawing.Point(63, 69);
			this.nudDepth.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
			this.nudDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudDepth.Name = "nudDepth";
			this.nudDepth.Size = new System.Drawing.Size(85, 20);
			this.nudDepth.TabIndex = 5;
			this.nudDepth.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
			// 
			// lblDepth
			// 
			this.lblDepth.AutoSize = true;
			this.lblDepth.Location = new System.Drawing.Point(4, 72);
			this.lblDepth.Name = "lblDepth";
			this.lblDepth.Size = new System.Drawing.Size(39, 13);
			this.lblDepth.TabIndex = 4;
			this.lblDepth.Text = "Depth:";
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
			// ShapeChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbShape);
			this.Name = "ShapeChoice";
			this.Size = new System.Drawing.Size(160, 105);
			this.gbShape.ResumeLayout(false);
			this.gbShape.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDepth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbShape;
		private System.Windows.Forms.NumericUpDown nudDepth;
		private System.Windows.Forms.Label lblDepth;
		private System.Windows.Forms.NumericUpDown nudHeight;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.NumericUpDown nudWidth;
		private System.Windows.Forms.Label lblWidth;
	}
}
