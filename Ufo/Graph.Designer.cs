
namespace Ufo
{
    partial class Graph
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.layoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.labelAcc = new System.Windows.Forms.Label();
            this.numericAcc = new System.Windows.Forms.NumericUpDown();
            this.labelStep = new System.Windows.Forms.Label();
            this.numericStep = new System.Windows.Forms.NumericUpDown();
            this.AnalysisPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.researchButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.layoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStep)).BeginInit();
            this.AnalysisPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.Controls.Add(this.startButton);
            this.layoutPanel.Controls.Add(this.pauseButton);
            this.layoutPanel.Controls.Add(this.resetButton);
            this.layoutPanel.Controls.Add(this.labelAcc);
            this.layoutPanel.Controls.Add(this.numericAcc);
            this.layoutPanel.Controls.Add(this.labelStep);
            this.layoutPanel.Controls.Add(this.numericStep);
            this.layoutPanel.Controls.Add(this.AnalysisPanel);
            this.layoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.Size = new System.Drawing.Size(800, 69);
            this.layoutPanel.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Начать";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Location = new System.Drawing.Point(84, 3);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(75, 23);
            this.pauseButton.TabIndex = 1;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(165, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 2;
            this.resetButton.Text = "Сброс";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // labelAcc
            // 
            this.labelAcc.AutoSize = true;
            this.labelAcc.Location = new System.Drawing.Point(246, 7);
            this.labelAcc.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelAcc.Name = "labelAcc";
            this.labelAcc.Size = new System.Drawing.Size(58, 15);
            this.labelAcc.TabIndex = 3;
            this.labelAcc.Text = "Точность";
            // 
            // numericAcc
            // 
            this.numericAcc.Location = new System.Drawing.Point(310, 3);
            this.numericAcc.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericAcc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAcc.Name = "numericAcc";
            this.numericAcc.Size = new System.Drawing.Size(120, 23);
            this.numericAcc.TabIndex = 5;
            this.numericAcc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(436, 7);
            this.labelStep.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(29, 15);
            this.labelStep.TabIndex = 4;
            this.labelStep.Text = "Шаг";
            // 
            // numericStep
            // 
            this.numericStep.Location = new System.Drawing.Point(471, 3);
            this.numericStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericStep.Name = "numericStep";
            this.numericStep.Size = new System.Drawing.Size(120, 23);
            this.numericStep.TabIndex = 6;
            this.numericStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AnalysisPanel
            // 
            this.AnalysisPanel.Controls.Add(this.researchButton);
            this.AnalysisPanel.Controls.Add(this.progressBar);
            this.AnalysisPanel.Location = new System.Drawing.Point(597, 3);
            this.AnalysisPanel.Name = "AnalysisPanel";
            this.AnalysisPanel.Size = new System.Drawing.Size(200, 61);
            this.AnalysisPanel.TabIndex = 8;
            // 
            // researchButton
            // 
            this.researchButton.Location = new System.Drawing.Point(3, 3);
            this.researchButton.Name = "researchButton";
            this.researchButton.Size = new System.Drawing.Size(100, 23);
            this.researchButton.TabIndex = 7;
            this.researchButton.Text = "Исследование";
            this.researchButton.UseVisualStyleBackColor = true;
            this.researchButton.Click += new System.EventHandler(this.researchButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 32);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(188, 23);
            this.progressBar.TabIndex = 8;
            this.progressBar.Visible = false;
            // 
            // timerDraw
            // 
            this.timerDraw.Interval = 50;
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 69);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(800, 381);
            this.mainPanel.TabIndex = 1;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.layoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Graph";
            this.ShowIcon = false;
            this.Text = "Движение по прямой";
            this.layoutPanel.ResumeLayout(false);
            this.layoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStep)).EndInit();
            this.AnalysisPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label labelAcc;
        private System.Windows.Forms.NumericUpDown numericAcc;
        private System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.NumericUpDown numericStep;
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button researchButton;
        private System.Windows.Forms.FlowLayoutPanel AnalysisPanel;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}