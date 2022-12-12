
namespace AnycubicPCB
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPDFPCBLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnLoadPcb = new System.Windows.Forms.Button();
            this.lblMachine = new System.Windows.Forms.Label();
            this.lblDPI = new System.Windows.Forms.Label();
            this.lblImgSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCalibration = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxExposure = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.cbxCalibLayer = new System.Windows.Forms.CheckBox();
            this.tbxCalibrationTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMachines = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.giaraPictureBox1 = new AnycubicPCB.CustomComponents.GiaraPictureBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openPDFPCBLayerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPDFPCBLayerToolStripMenuItem
            // 
            this.openPDFPCBLayerToolStripMenuItem.Name = "openPDFPCBLayerToolStripMenuItem";
            this.openPDFPCBLayerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.openPDFPCBLayerToolStripMenuItem.Text = "Open PCB";
            // 
            // configurationsToolStripMenuItem
            // 
            this.configurationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrationToolStripMenuItem,
            this.removeCalibrationToolStripMenuItem});
            this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
            this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.configurationsToolStripMenuItem.Text = "Calibrations";
            // 
            // calibrationToolStripMenuItem
            // 
            this.calibrationToolStripMenuItem.Name = "calibrationToolStripMenuItem";
            this.calibrationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.calibrationToolStripMenuItem.Text = "Add Calibration";
            this.calibrationToolStripMenuItem.Click += new System.EventHandler(this.calibrationToolStripMenuItem_Click);
            // 
            // removeCalibrationToolStripMenuItem
            // 
            this.removeCalibrationToolStripMenuItem.Name = "removeCalibrationToolStripMenuItem";
            this.removeCalibrationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removeCalibrationToolStripMenuItem.Text = "Remove Calibration";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 526);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(760, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // btnLoadPcb
            // 
            this.btnLoadPcb.Location = new System.Drawing.Point(12, 27);
            this.btnLoadPcb.Name = "btnLoadPcb";
            this.btnLoadPcb.Size = new System.Drawing.Size(150, 50);
            this.btnLoadPcb.TabIndex = 5;
            this.btnLoadPcb.Text = "Load PCB";
            this.btnLoadPcb.UseVisualStyleBackColor = true;
            this.btnLoadPcb.Click += new System.EventHandler(this.btnLoadPcb_Click);
            // 
            // lblMachine
            // 
            this.lblMachine.Location = new System.Drawing.Point(168, 27);
            this.lblMachine.Name = "lblMachine";
            this.lblMachine.Size = new System.Drawing.Size(150, 43);
            this.lblMachine.TabIndex = 7;
            this.lblMachine.Text = "lblMachine";
            this.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDPI
            // 
            this.lblDPI.Location = new System.Drawing.Point(480, 27);
            this.lblDPI.Name = "lblDPI";
            this.lblDPI.Size = new System.Drawing.Size(250, 43);
            this.lblDPI.TabIndex = 8;
            this.lblDPI.Text = "lblDPI";
            this.lblDPI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblImgSize
            // 
            this.lblImgSize.Location = new System.Drawing.Point(324, 27);
            this.lblImgSize.Name = "lblImgSize";
            this.lblImgSize.Size = new System.Drawing.Size(150, 43);
            this.lblImgSize.TabIndex = 9;
            this.lblImgSize.Text = "lblImgSize";
            this.lblImgSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Calibration";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCalibration
            // 
            this.cbCalibration.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCalibration.FormattingEnabled = true;
            this.cbCalibration.Location = new System.Drawing.Point(12, 156);
            this.cbCalibration.Name = "cbCalibration";
            this.cbCalibration.Size = new System.Drawing.Size(150, 21);
            this.cbCalibration.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Exposure Time [ms]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxExposure
            // 
            this.tbxExposure.Location = new System.Drawing.Point(12, 206);
            this.tbxExposure.Name = "tbxExposure";
            this.tbxExposure.Size = new System.Drawing.Size(150, 20);
            this.tbxExposure.TabIndex = 14;
            this.tbxExposure.Text = "180000";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.Location = new System.Drawing.Point(12, 470);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(150, 50);
            this.btnGenerate.TabIndex = 15;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // cbxCalibLayer
            // 
            this.cbxCalibLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbxCalibLayer.Location = new System.Drawing.Point(12, 391);
            this.cbxCalibLayer.Name = "cbxCalibLayer";
            this.cbxCalibLayer.Size = new System.Drawing.Size(150, 24);
            this.cbxCalibLayer.TabIndex = 17;
            this.cbxCalibLayer.Text = "Show Calibration Layer";
            this.cbxCalibLayer.UseVisualStyleBackColor = true;
            // 
            // tbxCalibrationTime
            // 
            this.tbxCalibrationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxCalibrationTime.Enabled = false;
            this.tbxCalibrationTime.Location = new System.Drawing.Point(12, 444);
            this.tbxCalibrationTime.Name = "tbxCalibrationTime";
            this.tbxCalibrationTime.Size = new System.Drawing.Size(150, 20);
            this.tbxCalibrationTime.TabIndex = 19;
            this.tbxCalibrationTime.Text = "1000";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(12, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 23);
            this.label3.TabIndex = 18;
            this.label3.Text = "Time [ms]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMachines
            // 
            this.cbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMachines.FormattingEnabled = true;
            this.cbMachines.Location = new System.Drawing.Point(12, 106);
            this.cbMachines.Name = "cbMachines";
            this.cbMachines.Size = new System.Drawing.Size(150, 21);
            this.cbMachines.TabIndex = 22;
            this.cbMachines.SelectedIndexChanged += new System.EventHandler(this.cbMachines_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Printer Type";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // giaraPictureBox1
            // 
            this.giaraPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.giaraPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.giaraPictureBox1.Location = new System.Drawing.Point(171, 80);
            this.giaraPictureBox1.Name = "giaraPictureBox1";
            this.giaraPictureBox1.Size = new System.Drawing.Size(601, 440);
            this.giaraPictureBox1.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cbMachines);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.giaraPictureBox1);
            this.Controls.Add(this.tbxCalibrationTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCalibLayer);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.tbxExposure);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCalibration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblImgSize);
            this.Controls.Add(this.lblDPI);
            this.Controls.Add(this.lblMachine);
            this.Controls.Add(this.btnLoadPcb);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPDFPCBLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calibrationToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnLoadPcb;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblDPI;
        private System.Windows.Forms.Label lblImgSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCalibration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxExposure;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox cbxCalibLayer;
        private System.Windows.Forms.TextBox tbxCalibrationTime;
        private System.Windows.Forms.Label label3;
        private CustomComponents.GiaraPictureBox giaraPictureBox1;
        private System.Windows.Forms.ComboBox cbMachines;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem removeCalibrationToolStripMenuItem;
    }
}

