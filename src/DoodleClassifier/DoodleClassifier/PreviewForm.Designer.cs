namespace DoodleClassifier
{
	partial class PreviewForm
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
			this.btnTest = new System.Windows.Forms.Button();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.gbDatasetDisplay = new System.Windows.Forms.GroupBox();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.gbTesting = new System.Windows.Forms.GroupBox();
			this.gbDrawing = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.pbDraw = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.gbDatasetDisplay.SuspendLayout();
			this.gbTesting.SuspendLayout();
			this.gbDrawing.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
			this.SuspendLayout();
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(18, 36);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(75, 23);
			this.btnTest.TabIndex = 0;
			this.btnTest.Text = "Test";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// pbPreview
			// 
			this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbPreview.Location = new System.Drawing.Point(6, 57);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(84, 84);
			this.pbPreview.TabIndex = 1;
			this.pbPreview.TabStop = false;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(50, 147);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(40, 23);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(6, 147);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(40, 23);
			this.btnPrev.TabIndex = 1;
			this.btnPrev.Text = "Prev";
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// gbDatasetDisplay
			// 
			this.gbDatasetDisplay.Controls.Add(this.btnLoadData);
			this.gbDatasetDisplay.Controls.Add(this.pbPreview);
			this.gbDatasetDisplay.Controls.Add(this.btnPrev);
			this.gbDatasetDisplay.Controls.Add(this.btnNext);
			this.gbDatasetDisplay.Location = new System.Drawing.Point(17, 17);
			this.gbDatasetDisplay.Name = "gbDatasetDisplay";
			this.gbDatasetDisplay.Size = new System.Drawing.Size(96, 177);
			this.gbDatasetDisplay.TabIndex = 0;
			this.gbDatasetDisplay.TabStop = false;
			this.gbDatasetDisplay.Text = "Dataset Display";
			// 
			// btnLoadData
			// 
			this.btnLoadData.Location = new System.Drawing.Point(6, 22);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(84, 23);
			this.btnLoadData.TabIndex = 0;
			this.btnLoadData.Text = "Load";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// gbTesting
			// 
			this.gbTesting.Controls.Add(this.btnTest);
			this.gbTesting.Location = new System.Drawing.Point(518, 362);
			this.gbTesting.Name = "gbTesting";
			this.gbTesting.Size = new System.Drawing.Size(118, 87);
			this.gbTesting.TabIndex = 10000;
			this.gbTesting.TabStop = false;
			this.gbTesting.Text = "Testing";
			// 
			// gbDrawing
			// 
			this.gbDrawing.Controls.Add(this.pbDraw);
			this.gbDrawing.Controls.Add(this.btnClear);
			this.gbDrawing.Location = new System.Drawing.Point(142, 17);
			this.gbDrawing.Name = "gbDrawing";
			this.gbDrawing.Size = new System.Drawing.Size(277, 177);
			this.gbDrawing.TabIndex = 1;
			this.gbDrawing.TabStop = false;
			this.gbDrawing.Text = "Drawing";
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(20, 22);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(82, 23);
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// pbDraw
			// 
			this.pbDraw.BackColor = System.Drawing.Color.White;
			this.pbDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pbDraw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbDraw.Location = new System.Drawing.Point(122, 20);
			this.pbDraw.Name = "pbDraw";
			this.pbDraw.Size = new System.Drawing.Size(140, 140);
			this.pbDraw.TabIndex = 2;
			this.pbDraw.TabStop = false;
			this.pbDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDraw_Paint);
			this.pbDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseMove);
			// 
			// PreviewForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(669, 462);
			this.Controls.Add(this.gbDrawing);
			this.Controls.Add(this.gbTesting);
			this.Controls.Add(this.gbDatasetDisplay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "PreviewForm";
			this.ShowIcon = false;
			this.Text = "NT-GI Doodle Classifier";
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.gbDatasetDisplay.ResumeLayout(false);
			this.gbTesting.ResumeLayout(false);
			this.gbDrawing.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnTest;
		private System.Windows.Forms.PictureBox pbPreview;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.GroupBox gbDatasetDisplay;
		private System.Windows.Forms.Button btnLoadData;
		private System.Windows.Forms.GroupBox gbTesting;
		private System.Windows.Forms.GroupBox gbDrawing;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.PictureBox pbDraw;
	}
}

