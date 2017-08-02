using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace patternTest
{
    public partial class Training : Form
    {
        enum patterns { up, down, left, right, none, random };

        bool answerMode = false;
        int fanPatternIdx = (int)patterns.none, motorPatternIdx = (int)patterns.none;
        int onsetDelay = 500, duration = 1500;

        Random random;

        public Training()
        {
            InitializeComponent();
            random = new Random();
        }

        public void SetValues(SerialPort serialPort)
        {
            this.serialPort1 = serialPort;
        }

        private void logWrite(string s)
        {
            textBoxLog.Text += s + "\r\n";
            textBoxLog.Select(textBoxLog.TextLength, 0);
            textBoxLog.ScrollToCaret();
        }

        // Turn off fan's button
        private void fanBtnColor(int idx, Color color)
        {
            switch(idx)
            {
                case (int)patterns.up:
                    buttonUp.BackColor = color;
                    break;
                case (int)patterns.down:
                    buttonDown.BackColor = color;
                    break;
                case (int)patterns.left:
                    buttonLeft.BackColor = color;
                    break;
                case (int)patterns.right:
                    buttonRight.BackColor = color;
                    break;
                default:
                    break;
            }
        }

        // Turn off motor's button
        private void motorBtnColor(int idx, Color color)
        {
            switch (idx)
            {
                case (int)patterns.up:
                    buttonMotorUp.BackColor = color;
                    break;
                case (int)patterns.down:
                    buttonMotorDown.BackColor = color;
                    break;
                case (int)patterns.left:
                    buttonMotorLeft.BackColor = color;
                    break;
                case (int)patterns.right:
                    buttonMotorRight.BackColor = color;
                    break;
                default:
                    break;
            }
        }

        private void clickFanBtn(int btnIdx)
        {
            if (answerMode)
            {
                if (fanPatternIdx == btnIdx)
                {
                    fanBtnColor(btnIdx, Color.Green);
                    Delay(200);
                }
                else
                {
                    fanBtnColor(btnIdx, Color.Red);
                    fanBtnColor(fanPatternIdx, Color.Green);
                    Delay(200);
                }
                setFanButtonColor(Color.Black);
                answerMode = false;
                buttonRandom.Enabled = true;
                buttonRandom.ForeColor = Color.White;
                setMotorButtonEnable(true);
                return;
            }
            else
            {
                playFan(btnIdx);
                return;
            }
        }

        private void clickMotorBtn(int btnIdx)
        {
            if (answerMode)
            {
                if (motorPatternIdx == btnIdx)
                {
                    motorBtnColor(btnIdx, Color.Green);
                    Delay(200);
                }
                else
                {
                    motorBtnColor(btnIdx, Color.Red);
                    motorBtnColor(motorPatternIdx, Color.Green);
                    Delay(200);
                }
                setMotorButtonColor(Color.Black);
                answerMode = false;
                buttonMotorRandom.Enabled = true;
                buttonMotorRandom.ForeColor = Color.White;
                setFanButtonEnable(true);
                return;
            }
            else
            {
                playMotor(btnIdx);
                return;
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            clickFanBtn((int)patterns.up);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            clickFanBtn((int)patterns.right);
        }

        private void buttonMotorUp_Click(object sender, EventArgs e)
        {
            clickMotorBtn((int)patterns.up);
        }

        private void buttonMotorDown_Click(object sender, EventArgs e)
        {
            clickMotorBtn((int)patterns.down);
        }

        private void buttonMotorLeft_Click(object sender, EventArgs e)
        {
            clickMotorBtn((int)patterns.left);
        }

        private void buttonMotorRight_Click(object sender, EventArgs e)
        {
            clickMotorBtn((int)patterns.right);
        }

        private void buttonMotorRandom_Click(object sender, EventArgs e)
        {
            motorPatternIdx = random.Next(4);
            playMotor((int)patterns.random);
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            fanPatternIdx = random.Next(4);
            playFan((int)patterns.random);
        }
        
        private void Training_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            clickFanBtn((int)patterns.left);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            clickFanBtn((int)patterns.down);
        }

        private void playFan(int pattern)
        {
            int[] tmpPattern = { pattern, (int)patterns.none };
            setFanButtonEnable(false);
            setMotorButtonEnable(false);
            buttonRandom.ForeColor = Color.Black;
            Delay(onsetDelay);
            buttonRandom.ForeColor = Color.White;
            buttonRandom.BackColor = Color.Gray;

            switch(pattern)
            {
                case (int)patterns.up:
                    buttonUp.BackColor = Color.Gray;
                    break;
                case (int)patterns.down:
                    buttonDown.BackColor = Color.Gray;
                    break;
                case (int)patterns.left:
                    buttonLeft.BackColor = Color.Gray;
                    break;
                case (int)patterns.right:
                    buttonRight.BackColor = Color.Gray;
                    break;
                case (int)patterns.random:
                    tmpPattern[0] = fanPatternIdx;
                    answerMode = true;
                    buttonRandom.Enabled = false;
                    buttonRandom.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }

            playPattern(tmpPattern);
            Delay(duration);
            if(answerMode)
                setFanButtonColor(Color.Gray);
            else
                setFanButtonColor(Color.Black);
            buttonRandom.BackColor = Color.Black;
            setFanButtonEnable(true);
        }

        private void playMotor(int pattern)
        {
            int[] tmpPattern = { (int)patterns.none, pattern };
            setFanButtonEnable(false);
            setMotorButtonEnable(false);
            buttonMotorRandom.ForeColor = Color.Black;
            Delay(onsetDelay);
            buttonMotorRandom.ForeColor = Color.White;
            buttonMotorRandom.BackColor = Color.Gray;

            switch (pattern)
            {
                case (int)patterns.up:
                    buttonMotorUp.BackColor = Color.Gray;
                    break;
                case (int)patterns.down:
                    buttonMotorDown.BackColor = Color.Gray;
                    break;
                case (int)patterns.left:
                    buttonMotorLeft.BackColor = Color.Gray;
                    break;
                case (int)patterns.right:
                    buttonMotorRight.BackColor = Color.Gray;
                    break;
                case (int)patterns.random:
                    tmpPattern[1] = motorPatternIdx;
                    answerMode = true;
                    buttonMotorRandom.Enabled = false;
                    buttonMotorRandom.ForeColor = Color.Black;
                    break;
                default:
                    break;
            }

            playPattern(tmpPattern);
            Delay(duration);
            if (answerMode)
                setMotorButtonColor(Color.Gray);
            else
                setMotorButtonColor(Color.Black);
            buttonMotorRandom.BackColor = Color.Black;
            setMotorButtonEnable(true);
        }

        private void setFanButtonColor(Color color)
        {
            buttonUp.BackColor = color;
            buttonDown.BackColor = color;
            buttonLeft.BackColor = color;
            buttonRight.BackColor = color;
        }

        private void setFanButtonEnable(bool enable)
        {
            buttonUp.Enabled = enable;
            buttonDown.Enabled = enable;
            buttonLeft.Enabled = enable;
            buttonRight.Enabled = enable;
        }

        private void setMotorButtonColor(Color color)
        {
            buttonMotorUp.BackColor = color;
            buttonMotorDown.BackColor = color;
            buttonMotorLeft.BackColor = color;
            buttonMotorRight.BackColor = color;
        }

        private void setMotorButtonEnable(bool enable)
        {
            buttonMotorUp.Enabled = enable;
            buttonMotorDown.Enabled = enable;
            buttonMotorLeft.Enabled = enable;
            buttonMotorRight.Enabled = enable;
        }

        private void playPattern(int[] pattern)
        {
            string command = "";
            switch (pattern[0])
            {
                case (int)patterns.left:
                    command += "l";
                    break;
                case (int)patterns.right:
                    command += "r";
                    break;
                case (int)patterns.up:
                    command += "u";
                    break;
                case (int)patterns.down:
                    command += "d";
                    break;
                default:
                    command += "n";
                    break;
            }
            switch (pattern[1])
            {
                case (int)patterns.left:
                    command += "l";
                    break;
                case (int)patterns.right:
                    command += "r";
                    break;
                case (int)patterns.up:
                    command += "u";
                    break;
                case (int)patterns.down:
                    command += "d";
                    break;
                default:
                    command += "n";
                    break;
            }

            serialPort1.WriteLine(command);
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
    }
}
