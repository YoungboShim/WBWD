namespace patternTest
{
    partial class ExpManager
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
            this.panelSerial = new System.Windows.Forms.Panel();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxSerials = new System.Windows.Forms.ComboBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.comboBoxTest = new System.Windows.Forms.ComboBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxFanMotor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelSerial.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSerial
            // 
            this.panelSerial.Controls.Add(this.buttonConnect);
            this.panelSerial.Controls.Add(this.comboBoxSerials);
            this.panelSerial.Controls.Add(this.buttonReset);
            this.panelSerial.Location = new System.Drawing.Point(0, 0);
            this.panelSerial.Name = "panelSerial";
            this.panelSerial.Size = new System.Drawing.Size(391, 66);
            this.panelSerial.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.Location = new System.Drawing.Point(266, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(101, 32);
            this.buttonConnect.TabIndex = 4;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxSerials
            // 
            this.comboBoxSerials.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSerials.FormattingEnabled = true;
            this.comboBoxSerials.Location = new System.Drawing.Point(119, 12);
            this.comboBoxSerials.Name = "comboBoxSerials";
            this.comboBoxSerials.Size = new System.Drawing.Size(123, 32);
            this.comboBoxSerials.TabIndex = 3;
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(12, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(101, 32);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.label3);
            this.panelSetting.Controls.Add(this.textBoxID);
            this.panelSetting.Controls.Add(this.label2);
            this.panelSetting.Controls.Add(this.label1);
            this.panelSetting.Controls.Add(this.comboBoxFanMotor);
            this.panelSetting.Controls.Add(this.comboBoxTest);
            this.panelSetting.Location = new System.Drawing.Point(0, 72);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(391, 66);
            this.panelSetting.TabIndex = 1;
            // 
            // comboBoxTest
            // 
            this.comboBoxTest.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTest.FormattingEnabled = true;
            this.comboBoxTest.Items.AddRange(new object[] {
            "Training",
            "Exp#1"});
            this.comboBoxTest.Location = new System.Drawing.Point(49, 17);
            this.comboBoxTest.Name = "comboBoxTest";
            this.comboBoxTest.Size = new System.Drawing.Size(93, 32);
            this.comboBoxTest.TabIndex = 5;
            this.comboBoxTest.SelectedIndexChanged += new System.EventHandler(this.comboBoxTest_SelectedIndexChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(266, 144);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(116, 37);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // comboBoxFanMotor
            // 
            this.comboBoxFanMotor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFanMotor.FormattingEnabled = true;
            this.comboBoxFanMotor.Items.AddRange(new object[] {
            "Fan",
            "Motor"});
            this.comboBoxFanMotor.Location = new System.Drawing.Point(295, 18);
            this.comboBoxFanMotor.Name = "comboBoxFanMotor";
            this.comboBoxFanMotor.Size = new System.Drawing.Size(80, 32);
            this.comboBoxFanMotor.TabIndex = 6;
            this.comboBoxFanMotor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFanMotor_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Exp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(149, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(172, 18);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(78, 32);
            this.textBoxID.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(260, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Set";
            // 
            // ExpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(394, 193);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panelSerial);
            this.Name = "ExpManager";
            this.Text = "ExpManager";
            this.Load += new System.EventHandler(this.ExpManager_Load);
            this.panelSerial.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSerial;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ComboBox comboBoxSerials;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button buttonStart;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBoxTest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFanMotor;
    }
}