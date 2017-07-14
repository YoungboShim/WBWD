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
            this.panelSetting = new System.Windows.Forms.Panel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.comboBoxSerials = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxTest = new System.Windows.Forms.ComboBox();
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
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.comboBoxTest);
            this.panelSetting.Location = new System.Drawing.Point(0, 72);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(391, 66);
            this.panelSetting.TabIndex = 1;
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
            // comboBoxSerials
            // 
            this.comboBoxSerials.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSerials.FormattingEnabled = true;
            this.comboBoxSerials.Location = new System.Drawing.Point(119, 12);
            this.comboBoxSerials.Name = "comboBoxSerials";
            this.comboBoxSerials.Size = new System.Drawing.Size(123, 32);
            this.comboBoxSerials.TabIndex = 3;
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
            // comboBoxTest
            // 
            this.comboBoxTest.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTest.FormattingEnabled = true;
            this.comboBoxTest.Items.AddRange(new object[] {
            "Training"});
            this.comboBoxTest.Location = new System.Drawing.Point(121, 17);
            this.comboBoxTest.Name = "comboBoxTest";
            this.comboBoxTest.Size = new System.Drawing.Size(121, 32);
            this.comboBoxTest.TabIndex = 5;
            this.comboBoxTest.SelectedIndexChanged += new System.EventHandler(this.comboBoxTest_SelectedIndexChanged);
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
    }
}