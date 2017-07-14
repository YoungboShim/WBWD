namespace patternTest
{
    partial class Training
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Training));
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonRandom = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.comboBoxSerials = new System.Windows.Forms.ComboBox();
            this.buttonSerialConnect = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonMotorRandom = new System.Windows.Forms.Button();
            this.buttonMotorDown = new System.Windows.Forms.Button();
            this.buttonMotorRight = new System.Windows.Forms.Button();
            this.buttonMotorLeft = new System.Windows.Forms.Button();
            this.buttonMotorUp = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonUp
            // 
            this.buttonUp.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonUp.Image")));
            this.buttonUp.Location = new System.Drawing.Point(394, 67);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(180, 180);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonLeft.Image")));
            this.buttonLeft.Location = new System.Drawing.Point(214, 247);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(180, 180);
            this.buttonLeft.TabIndex = 1;
            this.buttonLeft.UseVisualStyleBackColor = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonRight.Image")));
            this.buttonRight.Location = new System.Drawing.Point(574, 247);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(180, 180);
            this.buttonRight.TabIndex = 2;
            this.buttonRight.UseVisualStyleBackColor = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonDown.Image")));
            this.buttonDown.Location = new System.Drawing.Point(394, 427);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(180, 180);
            this.buttonDown.TabIndex = 3;
            this.buttonDown.UseVisualStyleBackColor = false;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonRandom
            // 
            this.buttonRandom.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonRandom.Font = new System.Drawing.Font("돋움", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonRandom.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonRandom.Location = new System.Drawing.Point(394, 247);
            this.buttonRandom.Name = "buttonRandom";
            this.buttonRandom.Size = new System.Drawing.Size(180, 180);
            this.buttonRandom.TabIndex = 4;
            this.buttonRandom.Text = "FAN";
            this.buttonRandom.UseVisualStyleBackColor = false;
            this.buttonRandom.Click += new System.EventHandler(this.buttonRandom_Click);
            // 
            // comboBoxSerials
            // 
            this.comboBoxSerials.FormattingEnabled = true;
            this.comboBoxSerials.Location = new System.Drawing.Point(0, 0);
            this.comboBoxSerials.Name = "comboBoxSerials";
            this.comboBoxSerials.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSerials.TabIndex = 5;
            // 
            // buttonSerialConnect
            // 
            this.buttonSerialConnect.Location = new System.Drawing.Point(127, 0);
            this.buttonSerialConnect.Name = "buttonSerialConnect";
            this.buttonSerialConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonSerialConnect.TabIndex = 6;
            this.buttonSerialConnect.Text = "Connect";
            this.buttonSerialConnect.UseVisualStyleBackColor = true;
            this.buttonSerialConnect.Click += new System.EventHandler(this.buttonSerialConnect_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(0, 38);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(202, 107);
            this.textBoxLog.TabIndex = 7;
            // 
            // buttonMotorRandom
            // 
            this.buttonMotorRandom.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonMotorRandom.Font = new System.Drawing.Font("돋움", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonMotorRandom.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonMotorRandom.Location = new System.Drawing.Point(1058, 247);
            this.buttonMotorRandom.Name = "buttonMotorRandom";
            this.buttonMotorRandom.Size = new System.Drawing.Size(180, 180);
            this.buttonMotorRandom.TabIndex = 12;
            this.buttonMotorRandom.Text = "MOT";
            this.buttonMotorRandom.UseVisualStyleBackColor = false;
            this.buttonMotorRandom.Click += new System.EventHandler(this.buttonMotorRandom_Click);
            // 
            // buttonMotorDown
            // 
            this.buttonMotorDown.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonMotorDown.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMotorDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonMotorDown.Image")));
            this.buttonMotorDown.Location = new System.Drawing.Point(1058, 427);
            this.buttonMotorDown.Name = "buttonMotorDown";
            this.buttonMotorDown.Size = new System.Drawing.Size(180, 180);
            this.buttonMotorDown.TabIndex = 11;
            this.buttonMotorDown.UseVisualStyleBackColor = false;
            this.buttonMotorDown.Click += new System.EventHandler(this.buttonMotorDown_Click);
            // 
            // buttonMotorRight
            // 
            this.buttonMotorRight.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonMotorRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMotorRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonMotorRight.Image")));
            this.buttonMotorRight.Location = new System.Drawing.Point(1238, 247);
            this.buttonMotorRight.Name = "buttonMotorRight";
            this.buttonMotorRight.Size = new System.Drawing.Size(180, 180);
            this.buttonMotorRight.TabIndex = 10;
            this.buttonMotorRight.UseVisualStyleBackColor = false;
            this.buttonMotorRight.Click += new System.EventHandler(this.buttonMotorRight_Click);
            // 
            // buttonMotorLeft
            // 
            this.buttonMotorLeft.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonMotorLeft.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMotorLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonMotorLeft.Image")));
            this.buttonMotorLeft.Location = new System.Drawing.Point(878, 247);
            this.buttonMotorLeft.Name = "buttonMotorLeft";
            this.buttonMotorLeft.Size = new System.Drawing.Size(180, 180);
            this.buttonMotorLeft.TabIndex = 9;
            this.buttonMotorLeft.UseVisualStyleBackColor = false;
            this.buttonMotorLeft.Click += new System.EventHandler(this.buttonMotorLeft_Click);
            // 
            // buttonMotorUp
            // 
            this.buttonMotorUp.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonMotorUp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMotorUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonMotorUp.Image")));
            this.buttonMotorUp.Location = new System.Drawing.Point(1058, 67);
            this.buttonMotorUp.Name = "buttonMotorUp";
            this.buttonMotorUp.Size = new System.Drawing.Size(180, 180);
            this.buttonMotorUp.TabIndex = 8;
            this.buttonMotorUp.UseVisualStyleBackColor = false;
            this.buttonMotorUp.Click += new System.EventHandler(this.buttonMotorUp_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.SystemColors.WindowText;
            this.buttonPlay.Font = new System.Drawing.Font("돋움", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonPlay.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonPlay.Location = new System.Drawing.Point(730, 671);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(176, 113);
            this.buttonPlay.TabIndex = 13;
            this.buttonPlay.Text = "PLAY";
            this.buttonPlay.UseVisualStyleBackColor = false;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1582, 913);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonMotorRandom);
            this.Controls.Add(this.buttonMotorDown);
            this.Controls.Add(this.buttonMotorRight);
            this.Controls.Add(this.buttonMotorLeft);
            this.Controls.Add(this.buttonMotorUp);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonSerialConnect);
            this.Controls.Add(this.comboBoxSerials);
            this.Controls.Add(this.buttonRandom);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonUp);
            this.Name = "Training";
            this.Text = "Training";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonRandom;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox comboBoxSerials;
        private System.Windows.Forms.Button buttonSerialConnect;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Button buttonMotorRandom;
        private System.Windows.Forms.Button buttonMotorDown;
        private System.Windows.Forms.Button buttonMotorRight;
        private System.Windows.Forms.Button buttonMotorLeft;
        private System.Windows.Forms.Button buttonMotorUp;
        private System.Windows.Forms.Button buttonPlay;
    }
}

