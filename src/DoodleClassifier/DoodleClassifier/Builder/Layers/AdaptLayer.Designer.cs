namespace DoodleClassifier
{
	partial class AdaptLayer
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
			this.cbNormalize = new System.Windows.Forms.CheckBox();
			this.afcActivation = new ActivationFuncChoice();
			this.cbReshape = new System.Windows.Forms.CheckBox();
			this.scShape = new ShapeChoice();
			this.gbEncapsulate.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbEncapsulate
			// 
			this.gbEncapsulate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbEncapsulate.Controls.Add(this.cbNormalize);
			this.gbEncapsulate.Controls.Add(this.afcActivation);
			this.gbEncapsulate.Controls.Add(this.cbReshape);
			this.gbEncapsulate.Controls.Add(this.scShape);
			this.gbEncapsulate.Location = new System.Drawing.Point(3, 3);
			this.gbEncapsulate.Name = "gbEncapsulate";
			this.gbEncapsulate.Size = new System.Drawing.Size(194, 189);
			this.gbEncapsulate.TabIndex = 0;
			this.gbEncapsulate.TabStop = false;
			this.gbEncapsulate.Text = "Adapting Layer";
			// 
			// cbNormalize
			// 
			this.cbNormalize.AutoSize = true;
			this.cbNormalize.Location = new System.Drawing.Point(20, 18);
			this.cbNormalize.Name = "cbNormalize";
			this.cbNormalize.Size = new System.Drawing.Size(126, 17);
			this.cbNormalize.TabIndex = 0;
			this.cbNormalize.Text = "Perform normalization";
			this.cbNormalize.UseVisualStyleBackColor = true;
			// 
			// afcActivation
			// 
			// 
			this.afcActivation.Location = new System.Drawing.Point(11, 33);
			this.afcActivation.TabIndex = 1;
			this.afcActivation.Name = "afcActivation";
			// 
			// cbReshape
			// 
			this.cbReshape.AutoSize = true;
			this.cbReshape.Checked = true;
			this.cbReshape.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbReshape.Location = new System.Drawing.Point(20, 63);
			this.cbReshape.Name = "cbReshape";
			this.cbReshape.Size = new System.Drawing.Size(102, 17);
			this.cbReshape.TabIndex = 2;
			this.cbReshape.Text = "Reshape output";
			this.cbReshape.UseVisualStyleBackColor = true;
			// 
			// scShape
			// 
			// 
			this.scShape.Location = new System.Drawing.Point(16, 78);
			this.scShape.TabIndex = 3;
			this.scShape.Name = "scShape";
			// 
			// AdaptLayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbEncapsulate);
			this.Name = "AdaptLayer";
			this.Size = new System.Drawing.Size(200, 195);
			this.gbEncapsulate.ResumeLayout(false);
			this.gbEncapsulate.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbEncapsulate;
		private System.Windows.Forms.CheckBox cbNormalize;
		private ActivationFuncChoice afcActivation;
		private System.Windows.Forms.CheckBox cbReshape;
		private ShapeChoice scShape;
	}
}
