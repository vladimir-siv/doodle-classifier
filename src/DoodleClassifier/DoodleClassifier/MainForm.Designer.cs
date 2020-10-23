namespace DoodleClassifier
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.btnTest = new System.Windows.Forms.Button();
			this.pbPreview = new System.Windows.Forms.PictureBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.gbDatasetDisplay = new System.Windows.Forms.GroupBox();
			this.btnLoadData = new System.Windows.Forms.Button();
			this.gbTesting = new System.Windows.Forms.GroupBox();
			this.nudDataCount = new System.Windows.Forms.NumericUpDown();
			this.cbUseLoaded = new System.Windows.Forms.CheckBox();
			this.btnClassifierLoading = new System.Windows.Forms.Button();
			this.lblTestStatus = new System.Windows.Forms.Label();
			this.btnClassifySaved = new System.Windows.Forms.Button();
			this.gbDrawing = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.pbSaved = new System.Windows.Forms.PictureBox();
			this.pbDraw = new System.Windows.Forms.PictureBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.gbTraining = new System.Windows.Forms.GroupBox();
			this.tbFitness = new System.Windows.Forms.TextBox();
			this.lblFitness = new System.Windows.Forms.Label();
			this.lblCrossover = new System.Windows.Forms.Label();
			this.cbCrossover = new System.Windows.Forms.ComboBox();
			this.btnSaveClassifier = new System.Windows.Forms.Button();
			this.lblTrainStatus = new System.Windows.Forms.Label();
			this.tbGenerations = new System.Windows.Forms.TextBox();
			this.lblGenerations = new System.Windows.Forms.Label();
			this.btnResetTrain = new System.Windows.Forms.Button();
			this.btnTrain = new System.Windows.Forms.Button();
			this.tbGlobalBatch = new System.Windows.Forms.TextBox();
			this.lblGlobalBatch = new System.Windows.Forms.Label();
			this.tbLocalBatch = new System.Windows.Forms.TextBox();
			this.lblLocalBatch = new System.Windows.Forms.Label();
			this.tbMutation = new System.Windows.Forms.TextBox();
			this.lblMutation = new System.Windows.Forms.Label();
			this.tbParentCnt = new System.Windows.Forms.TextBox();
			this.lblParentCnt = new System.Windows.Forms.Label();
			this.tbPopSize = new System.Windows.Forms.TextBox();
			this.lblPopSize = new System.Windows.Forms.Label();
			this.gbDataset = new System.Windows.Forms.GroupBox();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblDatasetRatio = new System.Windows.Forms.Label();
			this.tbDatasetRatio = new System.Windows.Forms.TrackBar();
			this.lblTrainIndicator = new System.Windows.Forms.Label();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
			this.gbDatasetDisplay.SuspendLayout();
			this.gbTesting.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDataCount)).BeginInit();
			this.gbDrawing.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbSaved)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
			this.gbTraining.SuspendLayout();
			this.gbDataset.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbDatasetRatio)).BeginInit();
			this.SuspendLayout();
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(15, 24);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(139, 23);
			this.btnTest.TabIndex = 0;
			this.btnTest.Text = "Test classifier";
			this.btnTest.UseVisualStyleBackColor = true;
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// pbPreview
			// 
			this.pbPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbPreview.Location = new System.Drawing.Point(15, 51);
			this.pbPreview.Name = "pbPreview";
			this.pbPreview.Size = new System.Drawing.Size(84, 84);
			this.pbPreview.TabIndex = 1;
			this.pbPreview.TabStop = false;
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(59, 144);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(40, 23);
			this.btnNext.TabIndex = 2;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(15, 144);
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
			this.gbDatasetDisplay.Size = new System.Drawing.Size(114, 177);
			this.gbDatasetDisplay.TabIndex = 0;
			this.gbDatasetDisplay.TabStop = false;
			this.gbDatasetDisplay.Text = "Dataset Display";
			// 
			// btnLoadData
			// 
			this.btnLoadData.Location = new System.Drawing.Point(15, 19);
			this.btnLoadData.Name = "btnLoadData";
			this.btnLoadData.Size = new System.Drawing.Size(84, 23);
			this.btnLoadData.TabIndex = 0;
			this.btnLoadData.Text = "Load";
			this.btnLoadData.UseVisualStyleBackColor = true;
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			// 
			// gbTesting
			// 
			this.gbTesting.Controls.Add(this.nudDataCount);
			this.gbTesting.Controls.Add(this.cbUseLoaded);
			this.gbTesting.Controls.Add(this.btnClassifierLoading);
			this.gbTesting.Controls.Add(this.lblTestStatus);
			this.gbTesting.Controls.Add(this.btnTest);
			this.gbTesting.Controls.Add(this.btnClassifySaved);
			this.gbTesting.Location = new System.Drawing.Point(17, 435);
			this.gbTesting.Name = "gbTesting";
			this.gbTesting.Size = new System.Drawing.Size(252, 115);
			this.gbTesting.TabIndex = 3;
			this.gbTesting.TabStop = false;
			this.gbTesting.Text = "Testing";
			// 
			// nudDataCount
			// 
			this.nudDataCount.Location = new System.Drawing.Point(164, 26);
			this.nudDataCount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
			this.nudDataCount.Name = "nudDataCount";
			this.nudDataCount.Size = new System.Drawing.Size(75, 20);
			this.nudDataCount.TabIndex = 2;
			this.nudDataCount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			// 
			// cbUseLoaded
			// 
			this.cbUseLoaded.AutoSize = true;
			this.cbUseLoaded.Checked = true;
			this.cbUseLoaded.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbUseLoaded.Enabled = false;
			this.cbUseLoaded.Location = new System.Drawing.Point(163, 86);
			this.cbUseLoaded.Name = "cbUseLoaded";
			this.cbUseLoaded.Size = new System.Drawing.Size(80, 17);
			this.cbUseLoaded.TabIndex = 4;
			this.cbUseLoaded.Text = "Use loaded";
			this.cbUseLoaded.UseVisualStyleBackColor = true;
			// 
			// btnClassifierLoading
			// 
			this.btnClassifierLoading.Location = new System.Drawing.Point(164, 53);
			this.btnClassifierLoading.Name = "btnClassifierLoading";
			this.btnClassifierLoading.Size = new System.Drawing.Size(75, 23);
			this.btnClassifierLoading.TabIndex = 3;
			this.btnClassifierLoading.Text = "Load";
			this.btnClassifierLoading.UseVisualStyleBackColor = true;
			this.btnClassifierLoading.Click += new System.EventHandler(this.btnClassifierLoading_Click);
			// 
			// lblTestStatus
			// 
			this.lblTestStatus.AutoSize = true;
			this.lblTestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTestStatus.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lblTestStatus.Location = new System.Drawing.Point(24, 86);
			this.lblTestStatus.Name = "lblTestStatus";
			this.lblTestStatus.Size = new System.Drawing.Size(0, 13);
			this.lblTestStatus.TabIndex = 5;
			// 
			// btnClassifySaved
			// 
			this.btnClassifySaved.Location = new System.Drawing.Point(15, 53);
			this.btnClassifySaved.Name = "btnClassifySaved";
			this.btnClassifySaved.Size = new System.Drawing.Size(139, 23);
			this.btnClassifySaved.TabIndex = 1;
			this.btnClassifySaved.Text = "Classify saved drawing";
			this.btnClassifySaved.UseVisualStyleBackColor = true;
			this.btnClassifySaved.Click += new System.EventHandler(this.btnClassifySaved_Click);
			// 
			// gbDrawing
			// 
			this.gbDrawing.Controls.Add(this.btnSave);
			this.gbDrawing.Controls.Add(this.pbSaved);
			this.gbDrawing.Controls.Add(this.pbDraw);
			this.gbDrawing.Controls.Add(this.btnClear);
			this.gbDrawing.Location = new System.Drawing.Point(156, 17);
			this.gbDrawing.Name = "gbDrawing";
			this.gbDrawing.Size = new System.Drawing.Size(277, 177);
			this.gbDrawing.TabIndex = 1;
			this.gbDrawing.TabStop = false;
			this.gbDrawing.Text = "Drawing";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(20, 47);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(84, 23);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pbSaved
			// 
			this.pbSaved.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pbSaved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbSaved.Location = new System.Drawing.Point(20, 76);
			this.pbSaved.Name = "pbSaved";
			this.pbSaved.Size = new System.Drawing.Size(84, 84);
			this.pbSaved.TabIndex = 3;
			this.pbSaved.TabStop = false;
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
			this.pbDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseDown);
			this.pbDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseMove);
			this.pbDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseUp);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(20, 22);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(84, 23);
			this.btnClear.TabIndex = 0;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// gbTraining
			// 
			this.gbTraining.Controls.Add(this.lblTrainIndicator);
			this.gbTraining.Controls.Add(this.tbFitness);
			this.gbTraining.Controls.Add(this.lblFitness);
			this.gbTraining.Controls.Add(this.lblCrossover);
			this.gbTraining.Controls.Add(this.cbCrossover);
			this.gbTraining.Controls.Add(this.btnSaveClassifier);
			this.gbTraining.Controls.Add(this.lblTrainStatus);
			this.gbTraining.Controls.Add(this.tbGenerations);
			this.gbTraining.Controls.Add(this.lblGenerations);
			this.gbTraining.Controls.Add(this.btnResetTrain);
			this.gbTraining.Controls.Add(this.btnTrain);
			this.gbTraining.Controls.Add(this.tbGlobalBatch);
			this.gbTraining.Controls.Add(this.lblGlobalBatch);
			this.gbTraining.Controls.Add(this.tbLocalBatch);
			this.gbTraining.Controls.Add(this.lblLocalBatch);
			this.gbTraining.Controls.Add(this.tbMutation);
			this.gbTraining.Controls.Add(this.lblMutation);
			this.gbTraining.Controls.Add(this.tbParentCnt);
			this.gbTraining.Controls.Add(this.lblParentCnt);
			this.gbTraining.Controls.Add(this.tbPopSize);
			this.gbTraining.Controls.Add(this.lblPopSize);
			this.gbTraining.Location = new System.Drawing.Point(17, 209);
			this.gbTraining.Name = "gbTraining";
			this.gbTraining.Size = new System.Drawing.Size(416, 212);
			this.gbTraining.TabIndex = 2;
			this.gbTraining.TabStop = false;
			this.gbTraining.Text = "Training";
			// 
			// tbFitness
			// 
			this.tbFitness.Cursor = System.Windows.Forms.Cursors.Default;
			this.tbFitness.Location = new System.Drawing.Point(296, 85);
			this.tbFitness.Name = "tbFitness";
			this.tbFitness.ReadOnly = true;
			this.tbFitness.Size = new System.Drawing.Size(100, 20);
			this.tbFitness.TabIndex = 11;
			this.tbFitness.DoubleClick += new System.EventHandler(this.tbFitness_DoubleClick);
			// 
			// lblFitness
			// 
			this.lblFitness.AutoSize = true;
			this.lblFitness.Location = new System.Drawing.Point(247, 88);
			this.lblFitness.Name = "lblFitness";
			this.lblFitness.Size = new System.Drawing.Size(43, 13);
			this.lblFitness.TabIndex = 10;
			this.lblFitness.Text = "Fitness:";
			// 
			// lblCrossover
			// 
			this.lblCrossover.AutoSize = true;
			this.lblCrossover.Location = new System.Drawing.Point(39, 88);
			this.lblCrossover.Name = "lblCrossover";
			this.lblCrossover.Size = new System.Drawing.Size(57, 13);
			this.lblCrossover.TabIndex = 8;
			this.lblCrossover.Text = "Crossover:";
			// 
			// cbCrossover
			// 
			this.cbCrossover.FormattingEnabled = true;
			this.cbCrossover.Items.AddRange(new object[] {
            "RUC",
            "RFC",
            "SEC"});
			this.cbCrossover.Location = new System.Drawing.Point(104, 85);
			this.cbCrossover.Name = "cbCrossover";
			this.cbCrossover.Size = new System.Drawing.Size(100, 21);
			this.cbCrossover.TabIndex = 9;
			this.cbCrossover.Text = "SEC";
			// 
			// btnSaveClassifier
			// 
			this.btnSaveClassifier.Enabled = false;
			this.btnSaveClassifier.Location = new System.Drawing.Point(264, 148);
			this.btnSaveClassifier.Name = "btnSaveClassifier";
			this.btnSaveClassifier.Size = new System.Drawing.Size(104, 23);
			this.btnSaveClassifier.TabIndex = 18;
			this.btnSaveClassifier.Text = "Save";
			this.btnSaveClassifier.UseVisualStyleBackColor = true;
			this.btnSaveClassifier.Click += new System.EventHandler(this.btnSaveClassifier_Click);
			// 
			// lblTrainStatus
			// 
			this.lblTrainStatus.AutoSize = true;
			this.lblTrainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrainStatus.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.lblTrainStatus.Location = new System.Drawing.Point(10, 182);
			this.lblTrainStatus.Name = "lblTrainStatus";
			this.lblTrainStatus.Size = new System.Drawing.Size(0, 13);
			this.lblTrainStatus.TabIndex = 19;
			// 
			// tbGenerations
			// 
			this.tbGenerations.Location = new System.Drawing.Point(296, 30);
			this.tbGenerations.Name = "tbGenerations";
			this.tbGenerations.Size = new System.Drawing.Size(100, 20);
			this.tbGenerations.TabIndex = 3;
			this.tbGenerations.Text = "1000";
			// 
			// lblGenerations
			// 
			this.lblGenerations.AutoSize = true;
			this.lblGenerations.Location = new System.Drawing.Point(223, 33);
			this.lblGenerations.Name = "lblGenerations";
			this.lblGenerations.Size = new System.Drawing.Size(67, 13);
			this.lblGenerations.TabIndex = 2;
			this.lblGenerations.Text = "Generations:";
			// 
			// btnResetTrain
			// 
			this.btnResetTrain.Enabled = false;
			this.btnResetTrain.Location = new System.Drawing.Point(154, 148);
			this.btnResetTrain.Name = "btnResetTrain";
			this.btnResetTrain.Size = new System.Drawing.Size(104, 23);
			this.btnResetTrain.TabIndex = 17;
			this.btnResetTrain.Text = "Reset";
			this.btnResetTrain.UseVisualStyleBackColor = true;
			this.btnResetTrain.Click += new System.EventHandler(this.btnResetTrain_Click);
			// 
			// btnTrain
			// 
			this.btnTrain.Location = new System.Drawing.Point(44, 148);
			this.btnTrain.Name = "btnTrain";
			this.btnTrain.Size = new System.Drawing.Size(104, 23);
			this.btnTrain.TabIndex = 16;
			this.btnTrain.Text = "Train";
			this.btnTrain.UseVisualStyleBackColor = true;
			this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
			// 
			// tbGlobalBatch
			// 
			this.tbGlobalBatch.Location = new System.Drawing.Point(296, 114);
			this.tbGlobalBatch.Name = "tbGlobalBatch";
			this.tbGlobalBatch.Size = new System.Drawing.Size(100, 20);
			this.tbGlobalBatch.TabIndex = 15;
			this.tbGlobalBatch.Text = "4";
			// 
			// lblGlobalBatch
			// 
			this.lblGlobalBatch.AutoSize = true;
			this.lblGlobalBatch.Location = new System.Drawing.Point(220, 117);
			this.lblGlobalBatch.Name = "lblGlobalBatch";
			this.lblGlobalBatch.Size = new System.Drawing.Size(70, 13);
			this.lblGlobalBatch.TabIndex = 14;
			this.lblGlobalBatch.Text = "Global batch:";
			// 
			// tbLocalBatch
			// 
			this.tbLocalBatch.Location = new System.Drawing.Point(104, 114);
			this.tbLocalBatch.Name = "tbLocalBatch";
			this.tbLocalBatch.Size = new System.Drawing.Size(100, 20);
			this.tbLocalBatch.TabIndex = 13;
			this.tbLocalBatch.Text = "4";
			// 
			// lblLocalBatch
			// 
			this.lblLocalBatch.AutoSize = true;
			this.lblLocalBatch.Location = new System.Drawing.Point(32, 117);
			this.lblLocalBatch.Name = "lblLocalBatch";
			this.lblLocalBatch.Size = new System.Drawing.Size(66, 13);
			this.lblLocalBatch.TabIndex = 12;
			this.lblLocalBatch.Text = "Local batch:";
			// 
			// tbMutation
			// 
			this.tbMutation.Location = new System.Drawing.Point(296, 56);
			this.tbMutation.Name = "tbMutation";
			this.tbMutation.Size = new System.Drawing.Size(100, 20);
			this.tbMutation.TabIndex = 7;
			this.tbMutation.Text = "15.0";
			// 
			// lblMutation
			// 
			this.lblMutation.AutoSize = true;
			this.lblMutation.Location = new System.Drawing.Point(218, 59);
			this.lblMutation.Name = "lblMutation";
			this.lblMutation.Size = new System.Drawing.Size(72, 13);
			this.lblMutation.TabIndex = 6;
			this.lblMutation.Text = "Mutation rate:";
			// 
			// tbParentCnt
			// 
			this.tbParentCnt.Location = new System.Drawing.Point(104, 56);
			this.tbParentCnt.Name = "tbParentCnt";
			this.tbParentCnt.Size = new System.Drawing.Size(100, 20);
			this.tbParentCnt.TabIndex = 5;
			this.tbParentCnt.Text = "2";
			// 
			// lblParentCnt
			// 
			this.lblParentCnt.AutoSize = true;
			this.lblParentCnt.Location = new System.Drawing.Point(27, 59);
			this.lblParentCnt.Name = "lblParentCnt";
			this.lblParentCnt.Size = new System.Drawing.Size(71, 13);
			this.lblParentCnt.TabIndex = 4;
			this.lblParentCnt.Text = "Parent count:";
			// 
			// tbPopSize
			// 
			this.tbPopSize.Location = new System.Drawing.Point(104, 30);
			this.tbPopSize.Name = "tbPopSize";
			this.tbPopSize.Size = new System.Drawing.Size(100, 20);
			this.tbPopSize.TabIndex = 1;
			this.tbPopSize.Text = "100";
			// 
			// lblPopSize
			// 
			this.lblPopSize.AutoSize = true;
			this.lblPopSize.Location = new System.Drawing.Point(17, 33);
			this.lblPopSize.Name = "lblPopSize";
			this.lblPopSize.Size = new System.Drawing.Size(81, 13);
			this.lblPopSize.TabIndex = 0;
			this.lblPopSize.Text = "Population size:";
			// 
			// gbDataset
			// 
			this.gbDataset.Controls.Add(this.lblTotal);
			this.gbDataset.Controls.Add(this.lblDatasetRatio);
			this.gbDataset.Controls.Add(this.tbDatasetRatio);
			this.gbDataset.Location = new System.Drawing.Point(290, 435);
			this.gbDataset.Name = "gbDataset";
			this.gbDataset.Size = new System.Drawing.Size(143, 115);
			this.gbDataset.TabIndex = 4;
			this.gbDataset.TabStop = false;
			this.gbDataset.Text = "Dataset";
			// 
			// lblTotal
			// 
			this.lblTotal.AutoSize = true;
			this.lblTotal.Location = new System.Drawing.Point(17, 88);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(95, 13);
			this.lblTotal.TabIndex = 2;
			this.lblTotal.Text = "Dataset size: 0000";
			// 
			// lblDatasetRatio
			// 
			this.lblDatasetRatio.AutoSize = true;
			this.lblDatasetRatio.Location = new System.Drawing.Point(17, 69);
			this.lblDatasetRatio.Name = "lblDatasetRatio";
			this.lblDatasetRatio.Size = new System.Drawing.Size(106, 13);
			this.lblDatasetRatio.TabIndex = 1;
			this.lblDatasetRatio.Text = "Train/Test ratio: 95%";
			// 
			// tbDatasetRatio
			// 
			this.tbDatasetRatio.Location = new System.Drawing.Point(20, 22);
			this.tbDatasetRatio.Maximum = 100;
			this.tbDatasetRatio.Minimum = 1;
			this.tbDatasetRatio.Name = "tbDatasetRatio";
			this.tbDatasetRatio.Size = new System.Drawing.Size(104, 45);
			this.tbDatasetRatio.TabIndex = 0;
			this.tbDatasetRatio.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.tbDatasetRatio.Value = 95;
			this.tbDatasetRatio.ValueChanged += new System.EventHandler(this.tbDatasetRatio_ValueChanged);
			// 
			// lblTrainIndicator
			// 
			this.lblTrainIndicator.AutoSize = true;
			this.lblTrainIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTrainIndicator.ForeColor = System.Drawing.Color.DimGray;
			this.lblTrainIndicator.Location = new System.Drawing.Point(9, 148);
			this.lblTrainIndicator.Name = "lblTrainIndicator";
			this.lblTrainIndicator.Size = new System.Drawing.Size(26, 31);
			this.lblTrainIndicator.TabIndex = 20;
			this.lblTrainIndicator.Text = "*";
			this.tooltip.SetToolTip(this.lblTrainIndicator, "Idling");
			this.lblTrainIndicator.MouseEnter += new System.EventHandler(this.lblTrainIndicator_MouseEnter);
			// 
			// tooltip
			// 
			this.tooltip.AutoPopDelay = 10000;
			this.tooltip.InitialDelay = 500;
			this.tooltip.ReshowDelay = 100;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(454, 565);
			this.Controls.Add(this.gbDataset);
			this.Controls.Add(this.gbTraining);
			this.Controls.Add(this.gbDrawing);
			this.Controls.Add(this.gbTesting);
			this.Controls.Add(this.gbDatasetDisplay);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NT-GI Doodle Classifier";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
			this.gbDatasetDisplay.ResumeLayout(false);
			this.gbTesting.ResumeLayout(false);
			this.gbTesting.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudDataCount)).EndInit();
			this.gbDrawing.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbSaved)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
			this.gbTraining.ResumeLayout(false);
			this.gbTraining.PerformLayout();
			this.gbDataset.ResumeLayout(false);
			this.gbDataset.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbDatasetRatio)).EndInit();
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
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.PictureBox pbSaved;
		private System.Windows.Forms.GroupBox gbTraining;
		private System.Windows.Forms.TextBox tbGlobalBatch;
		private System.Windows.Forms.Label lblGlobalBatch;
		private System.Windows.Forms.TextBox tbLocalBatch;
		private System.Windows.Forms.Label lblLocalBatch;
		private System.Windows.Forms.TextBox tbMutation;
		private System.Windows.Forms.Label lblMutation;
		private System.Windows.Forms.TextBox tbParentCnt;
		private System.Windows.Forms.Label lblParentCnt;
		private System.Windows.Forms.TextBox tbPopSize;
		private System.Windows.Forms.Label lblPopSize;
		private System.Windows.Forms.Button btnTrain;
		private System.Windows.Forms.Button btnResetTrain;
		private System.Windows.Forms.Button btnClassifySaved;
		private System.Windows.Forms.Label lblTestStatus;
		private System.Windows.Forms.TextBox tbGenerations;
		private System.Windows.Forms.Label lblGenerations;
		private System.Windows.Forms.Label lblTrainStatus;
		private System.Windows.Forms.GroupBox gbDataset;
		private System.Windows.Forms.TrackBar tbDatasetRatio;
		private System.Windows.Forms.Label lblDatasetRatio;
		private System.Windows.Forms.Button btnSaveClassifier;
		private System.Windows.Forms.Button btnClassifierLoading;
		private System.Windows.Forms.CheckBox cbUseLoaded;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.NumericUpDown nudDataCount;
		private System.Windows.Forms.Label lblCrossover;
		private System.Windows.Forms.ComboBox cbCrossover;
		private System.Windows.Forms.TextBox tbFitness;
		private System.Windows.Forms.Label lblFitness;
		private System.Windows.Forms.Label lblTrainIndicator;
		private System.Windows.Forms.ToolTip tooltip;
	}
}

