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
        enum modes { fan, vib, fan_noise, vib_noise}

        bool answerMode = false;
        int fanPatternIdx = (int)patterns.none, motorPatternIdx = (int)patterns.none;
        int onsetDelay = 500, duration = 1500;
        int trainMode = (int)modes.fan;

        Random random;

        public Training()
        {
            InitializeComponent();
            random = new Random();

            buttonLeft.MouseEnter += buttonRandom_MouseEnter;
            buttonRight.MouseEnter += buttonRandom_MouseEnter;
            buttonUp.MouseEnter += buttonRandom_MouseEnter;
            buttonDown.MouseEnter += buttonRandom_MouseEnter;

            buttonLeft.MouseLeave += buttonRandom_MouseLeave;
            buttonRight.MouseLeave += buttonRandom_MouseLeave;
            buttonUp.MouseLeave += buttonRandom_MouseLeave;
            buttonDown.MouseLeave += buttonRandom_MouseLeave;
        }

        public void SetValues(SerialPort serialPort)
        {
            this.serialPort1 = serialPort;
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
                return;
            }
            else
            {
                playFan(btnIdx);
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
            int[] tmpPattern = { (int)patterns.none, (int)patterns.none };
            switch (trainMode)
            {
                case (int)modes.fan:
                    tmpPattern[0] = pattern;
                    break;
                case (int)modes.vib:
                    tmpPattern[1] = pattern;
                    break;
                case (int)modes.fan_noise:
                    tmpPattern[0] = pattern;
                    tmpPattern[1] = random.Next(4);
                    break;
                case (int)modes.vib_noise:
                    tmpPattern[1] = pattern;
                    tmpPattern[0] = random.Next(4);
                    break;
                default:
                    break;
            }
            setFanButtonEnable(false);
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
                    if(trainMode == (int)modes.fan || trainMode == (int)modes.fan_noise)
                    {
                        tmpPattern[0] = fanPatternIdx;
                    }
                    else
                    {
                        tmpPattern[1] = fanPatternIdx;
                    }
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

        private void buttonRandom_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DarkBlue;
        }

        private void buttonRandom_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(answerMode)
                btn.BackColor = Color.Gray;
            else
                btn.BackColor = Color.Black;
        }

        private void comboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            trainMode = comboBoxMode.SelectedIndex;
            switch(trainMode)
            {
                case (int)modes.fan:
                    buttonRandom.Text = "FAN";
                    break;
                case (int)modes.vib:
                    buttonRandom.Text = "VIB";
                    break;
                case (int)modes.fan_noise:
                    buttonRandom.Text = "FAN+";
                    break;
                case (int)modes.vib_noise:
                    buttonRandom.Text = "VIB";
                    break;
                default:
                    break;
            }
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
