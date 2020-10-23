namespace DoodleClassifier
{
	partial class FCLayer
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
			this.gbEncapsulate.Controls.Add(this.afcActivation);
			this.gbEncapsulate.Location = new System.Drawing.Point(3, 3);
			this.gbEncapsulate.Name = "gbEncapsulate";
			this.gbEncapsulate.Size = new System.Drawing.Size(194, 84);
			this.gbEncapsulate.TabIndex = 0;
			this.gbEncapsulate.TabStop = false;
			this.gbEncapsulate.Text = "Fully Connected Layer";
			// 
			// scSize
			// 
			this.scSize.Location = new System.Drawing.Point(11, 15);
			this.scSize.TabIndex = 0;
			this.scSize.Name = "scSize";
			// 
			// afcActivation
			// 
			// 
			this.afcActivation.Location = new System.Drawing.Point(11, 45);
			this.afcActivation.TabIndex = 1;
			this.afcActivation.Name = "afcActivation";
			// 
			// FCLayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbEncapsulate);
			this.Name = "FCLayer";
			this.Size = new System.Drawing.Size(200, 90);
			this.gbEncapsulate.ResumeLayout(false);
			this.gbEncapsulate.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbEncapsulate;
		private SizeChoice scSize;
		private ActivationFuncChoice afcActivation;
	}
}
