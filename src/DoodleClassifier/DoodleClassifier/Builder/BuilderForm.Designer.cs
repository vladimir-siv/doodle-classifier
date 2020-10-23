namespace DoodleClassifier
{
	partial class BuilderForm
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
			this.lbLayers = new System.Windows.Forms.ListBox();
			this.gbPrototype = new System.Windows.Forms.GroupBox();
			this.pnlLayers = new System.Windows.Forms.Panel();
			this.lblOutput = new System.Windows.Forms.Label();
			this.lblInput = new System.Windows.Forms.Label();
			this.btnRemoveLast = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.gbPrototype.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbLayers
			// 
			this.lbLayers.FormattingEnabled = true;
			this.lbLayers.Items.AddRange(new object[] {
            "Convolutional",
            "Pooling",
            "Adapting",
            "FullyConnected"});
			this.lbLayers.Location = new System.Drawing.Point(12, 12);
			this.lbLayers.Name = "lbLayers";
			this.lbLayers.Size = new System.Drawing.Size(88, 95);
			this.lbLayers.TabIndex = 0;
			this.lbLayers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbLayers_MouseClick);
			this.lbLayers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbLayers_MouseDoubleClick);
			// 
			// gbPrototype
			// 
			this.gbPrototype.Controls.Add(this.pnlLayers);
			this.gbPrototype.Controls.Add(this.lblOutput);
			this.gbPrototype.Controls.Add(this.lblInput);
			this.gbPrototype.Location = new System.Drawing.Point(118, 12);
			this.gbPrototype.Name = "gbPrototype";
			this.gbPrototype.Size = new System.Drawing.Size(248, 405);
			this.gbPrototype.TabIndex = 4;
			this.gbPrototype.TabStop = false;
			this.gbPrototype.Text = "Prototype";
			// 
			// pnlLayers
			// 
			this.pnlLayers.AutoScroll = true;
			this.pnlLayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlLayers.Location = new System.Drawing.Point(6, 43);
			this.pnlLayers.Name = "pnlLayers";
			this.pnlLayers.Size = new System.Drawing.Size(236, 327);
			this.pnlLayers.TabIndex = 2;
			// 
			// lblOutput
			// 
			this.lblOutput.AutoSize = true;
			this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOutput.Location = new System.Drawing.Point(69, 375);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(104, 20);
			this.lblOutput.TabIndex = 1;
			this.lblOutput.Text = "Output: 1xN";
			// 
			// lblInput
			// 
			this.lblInput.AutoSize = true;
			this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInput.Location = new System.Drawing.Point(60, 17);
			this.lblInput.Name = "lblInput";
			this.lblInput.Size = new System.Drawing.Size(127, 20);
			this.lblInput.TabIndex = 0;
			this.lblInput.Text = "Input: 28x28x1";
			// 
			// btnRemoveLast
			// 
			this.btnRemoveLast.Location = new System.Drawing.Point(12, 116);
			this.btnRemoveLast.Name = "btnRemoveLast";
			this.btnRemoveLast.Size = new System.Drawing.Size(88, 23);
			this.btnRemoveLast.TabIndex = 1;
			this.btnRemoveLast.Text = "Remove Last";
			this.btnRemoveLast.UseVisualStyleBackColor = true;
			this.btnRemoveLast.Click += new System.EventHandler(this.btnRemoveLast_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(12, 145);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(88, 23);
			this.btnClear.TabIndex = 2;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Location = new System.Drawing.Point(12, 174);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(88, 23);
			this.btnAccept.TabIndex = 3;
			this.btnAccept.Text = "Accept";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// BuilderForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 429);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnRemoveLast);
			this.Controls.Add(this.gbPrototype);
			this.Controls.Add(this.lbLayers);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BuilderForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "NT-GI Doodle Classifier | Neural Builder";
			this.gbPrototype.ResumeLayout(false);
			this.gbPrototype.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox lbLayers;
		private System.Windows.Forms.GroupBox gbPrototype;
		private System.Windows.Forms.Label lblInput;
		private System.Windows.Forms.Label lblOutput;
		private System.Windows.Forms.Panel pnlLayers;
		private System.Windows.Forms.Button btnRemoveLast;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnAccept;
	}
}