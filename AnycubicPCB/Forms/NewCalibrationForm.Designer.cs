
namespace AnycubicPCB.Forms
{
    partial class NewCalibrationForm
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
            this.cbxMachineList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.giaraPictureBox1 = new AnycubicPCB.CustomComponents.GiaraPictureBox();
            this.tbxSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxX = new System.Windows.Forms.TextBox();
            this.lblFidList = new System.Windows.Forms.Label();
            this.btnSaveCalibration = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btnTestCalibration = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxMachineList
            // 
            this.cbxMachineList.FormattingEnabled = true;
            this.cbxMachineList.Location = new System.Drawing.Point(10, 42);
            this.cbxMachineList.Name = "cbxMachineList";
            this.cbxMachineList.Size = new System.Drawing.Size(200, 21);
            this.cbxMachineList.TabIndex = 0;
            this.cbxMachineList.SelectedIndexChanged += new System.EventHandler(this.cbxMachineList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Printer Type";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // giaraPictureBox1
            // 
            this.giaraPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.giaraPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.giaraPictureBox1.Location = new System.Drawing.Point(216, 12);
            this.giaraPictureBox1.Name = "giaraPictureBox1";
            this.giaraPictureBox1.Size = new System.Drawing.Size(616, 537);
            this.giaraPictureBox1.TabIndex = 2;
            // 
            // tbxSize
            // 
            this.tbxSize.Location = new System.Drawing.Point(78, 121);
            this.tbxSize.Name = "tbxSize";
            this.tbxSize.Size = new System.Drawing.Size(132, 20);
            this.tbxSize.TabIndex = 3;
            this.tbxSize.Text = "2000";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fiducial List";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(12, 144);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(198, 23);
            this.btnAddPoint.TabIndex = 5;
            this.btnAddPoint.Text = "Add Reference Point";
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Size [um]";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y [um]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxY
            // 
            this.tbxY.Location = new System.Drawing.Point(78, 95);
            this.tbxY.Name = "tbxY";
            this.tbxY.Size = new System.Drawing.Size(132, 20);
            this.tbxY.TabIndex = 8;
            this.tbxY.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "X [um]";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxX
            // 
            this.tbxX.Location = new System.Drawing.Point(78, 68);
            this.tbxX.Name = "tbxX";
            this.tbxX.Size = new System.Drawing.Size(132, 20);
            this.tbxX.TabIndex = 10;
            this.tbxX.Text = "0";
            // 
            // lblFidList
            // 
            this.lblFidList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFidList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFidList.Location = new System.Drawing.Point(12, 200);
            this.lblFidList.Name = "lblFidList";
            this.lblFidList.Size = new System.Drawing.Size(198, 204);
            this.lblFidList.TabIndex = 12;
            // 
            // btnSaveCalibration
            // 
            this.btnSaveCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveCalibration.Location = new System.Drawing.Point(9, 504);
            this.btnSaveCalibration.Name = "btnSaveCalibration";
            this.btnSaveCalibration.Size = new System.Drawing.Size(201, 45);
            this.btnSaveCalibration.TabIndex = 13;
            this.btnSaveCalibration.Text = "Save Calibration";
            this.btnSaveCalibration.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.Location = new System.Drawing.Point(9, 455);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Calibration Name:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox4.Location = new System.Drawing.Point(9, 478);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(201, 20);
            this.textBox4.TabIndex = 14;
            // 
            // btnTestCalibration
            // 
            this.btnTestCalibration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTestCalibration.Location = new System.Drawing.Point(12, 407);
            this.btnTestCalibration.Name = "btnTestCalibration";
            this.btnTestCalibration.Size = new System.Drawing.Size(198, 45);
            this.btnTestCalibration.TabIndex = 16;
            this.btnTestCalibration.Text = "Test Calibration Pattern";
            this.btnTestCalibration.UseVisualStyleBackColor = true;
            // 
            // NewCalibrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 561);
            this.Controls.Add(this.btnTestCalibration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.btnSaveCalibration);
            this.Controls.Add(this.lblFidList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxSize);
            this.Controls.Add(this.giaraPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxMachineList);
            this.Name = "NewCalibrationForm";
            this.Text = "Add New Calibration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMachineList;
        private System.Windows.Forms.Label label1;
        private CustomComponents.GiaraPictureBox giaraPictureBox1;
        private System.Windows.Forms.TextBox tbxSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxX;
        private System.Windows.Forms.Label lblFidList;
        private System.Windows.Forms.Button btnSaveCalibration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btnTestCalibration;
    }
}