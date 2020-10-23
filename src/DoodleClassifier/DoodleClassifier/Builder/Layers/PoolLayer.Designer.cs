namespace DoodleClassifier
{
	partial class PoolLayer
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
			this.gbEncapsulate = new System.Windows.Forms.GroupBox();
			this.dcFilter = new DimensionChoice();
			this.dcStride = new DimensionChoice();
			this.pcPool = new PoolChoice();
			this.gbEncapsulate.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbEncapsulate
			// 
			this.gbEncapsulate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.gbEncapsulate.Controls.Add(this.dcFilter);
			this.gbEncapsulate.Controls.Add(this.dcStride);
			this.gbEncapsulate.Controls.Add(this.pcPool);
			this.gbEncapsulate.Location = new System.Drawing.Point(3, 3);
			this.gbEncapsulate.Name = "gbEncapsulate";
			this.gbEncapsulate.Size = new System.Drawing.Size(194, 224);
			this.gbEncapsulate.TabIndex = 0;
			this.gbEncapsulate.TabStop = false;
			this.gbEncapsulate.Text = "Pooling Layer";
			// 
			// dcFilter
			// 
			this.dcFilter.Location = new System.Drawing.Point(16, 15);
			this.dcFilter.TabIndex = 0;
			this.dcFilter.Name = "dcFilter";
			this.dcFilter.Title = "Filter";
			// 
			// dcStride
			// 
			this.dcStride.Location = new System.Drawing.Point(16, 100);
			this.dcStride.TabIndex = 1;
			this.dcStride.Name = "dcStride";
			this.dcStride.Title = "Stride";
			// 
			// pcPool
			// 
			this.pcPool.Location = new System.Drawing.Point(11, 185);
			this.pcPool.TabIndex = 2;
			this.pcPool.Name = "pcPool";
			// 
			// PoolLayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbEncapsulate);
			this.Name = "PoolLayer";
			this.Size = new System.Drawing.Size(200, 230);
			this.gbEncapsulate.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbEncapsulate;
		private DimensionChoice dcFilter;
		private DimensionChoice dcStride;
		private PoolChoice pcPool;
	}
}
