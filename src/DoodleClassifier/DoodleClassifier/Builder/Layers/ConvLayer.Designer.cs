namespace DoodleClassifier
{
	partial class ConvLayer
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
			this.scSize = new SizeChoice();
			this.dcFilter = new DimensionChoice();
			this.dcStride = new DimensionChoice();
			this.dcPadding = new DimensionChoice();
			this.afcActivation = new ActivationFuncChoice();
			this.gbEncapsulate.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbEncapsulate
			// 
			this.gbEncapsulate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbEncapsulate.Controls.Add(this.scSize);
			this.gbEncapsulate.Controls.Add(this.dcFilter);
			this.gbEncapsulate.Controls.Add(this.dcStride);
			this.gbEncapsulate.Controls.Add(this.dcPadding);
			this.gbEncapsulate.Controls.Add(this.afcActivation);
			this.gbEncapsulate.Location = new System.Drawing.Point(3, 3);
			this.gbEncapsulate.Name = "gbEncapsulate";
			this.gbEncapsulate.Size = new System.Drawing.Size(194, 344);
			this.gbEncapsulate.TabIndex = 0;
			this.gbEncapsulate.TabStop = false;
			this.gbEncapsulate.Text = "Convolutional Layer";
			// 
			// scSize
			// 
			this.scSize.Location = new System.Drawing.Point(11, 18);
			this.scSize.TabIndex = 0;
			this.scSize.Name = "scSize";
			// 
			// dcFilter
			// 
			this.dcFilter.Location = new System.Drawing.Point(16, 50);
			this.dcFilter.TabIndex = 1;
			this.dcFilter.Name = "dcFilter";
			this.dcFilter.Title = "Filter";
			// 
			// dcStride
			// 
			this.dcStride.Location = new System.Drawing.Point(16, 135);
			this.dcStride.TabIndex = 2;
			this.dcStride.Name = "dcStride";
			this.dcStride.Title = "Stride";
			// 
			// dcPadding
			// 
			this.dcPadding.Location = new System.Drawing.Point(16, 220);
			this.dcPadding.TabIndex = 3;
			this.dcPadding.Name = "dcPadding";
			this.dcPadding.Title = "Padding";
			// 
			// afcActivation
			// 
			// 
			this.afcActivation.Location = new System.Drawing.Point(11, 305);
			this.afcActivation.TabIndex = 4;
			this.afcActivation.Name = "afcActivation";
			// 
			// ConvLayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbEncapsulate);
			this.Name = "ConvLayer";
			this.Size = new System.Drawing.Size(200, 350);
			this.gbEncapsulate.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbEncapsulate;
		private SizeChoice scSize;
		private DimensionChoice dcFilter;
		private DimensionChoice dcStride;
		private DimensionChoice dcPadding;
		private ActivationFuncChoice afcActivation;
	}
}
