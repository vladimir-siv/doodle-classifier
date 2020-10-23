namespace DoodleClassifier
{
	partial class ActivationFuncChoice
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
			this.lblActivation = new System.Windows.Forms.Label();
			this.cbActivation = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lblActivation
			// 
			this.lblActivation.AutoSize = true;
			this.lblActivation.Location = new System.Drawing.Point(8, 8);
			this.lblActivation.Name = "lblActivation";
			this.lblActivation.Size = new System.Drawing.Size(57, 13);
			this.lblActivation.TabIndex = 0;
			this.lblActivation.Text = "Activation:";
			// 
			// cbActivation
			// 
			this.cbActivation.FormattingEnabled = true;
			this.cbActivation.Items.AddRange(new object[] {
            "LTU",
            "Sigmoid",
            "Tanh",
            "RELU",
            "LeakyRELU",
            "ELU",
            "Softmax"});
			this.cbActivation.Location = new System.Drawing.Point(71, 5);
			this.cbActivation.Name = "cbActivation";
			this.cbActivation.Size = new System.Drawing.Size(85, 21);
			this.cbActivation.TabIndex = 1;
			this.cbActivation.Text = "ELU";
			// 
			// ActivationFuncChoice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblActivation);
			this.Controls.Add(this.cbActivation);
			this.Name = "ActivationFuncChoice";
			this.Size = new System.Drawing.Size(160, 30);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblActivation;
		private System.Windows.Forms.ComboBox cbActivation;
	}
}
