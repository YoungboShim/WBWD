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
    public partial class Exp2 : Form
    {
        enum patterns { up, down, left, right, none };
        int[,] stimuliSample = new int[48, 2];
        int[,] stimuli = new int[48, 2];
        int[] stimuliIdx = new int[48];
        int trialNum;
        int[] currPattern = new int[2];
        int onsetDelay = 500, duration = 1000;
        bool isFan = true;
        string ID, setting;
        TextWriter tw;

        public Exp2()
        {
            InitializeComponent();
        }

        private void Exp2_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;

            tw = new StreamWriter("Exp2_" + ID + "_" + setting + ".csv", true);
            tw.WriteLine("Trial#,Stimuli,Answer,Correct");

            shuffleStimuli();

            setAnswerButtonColor(Color.Black);
            setAnswerButtonEnable(false);
        }

        private void shuffleStimuli()
        {
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    stimuliSample[12 * i + j, 0] = i;
                    stimuliSample[12 * i + j, 1] = j % 4;
                    stimuliIdx[12 * i + j] = -1;
                }
            }
            int idx = 0;
            while (idx < 48)
            {
                int tmp = random.Next(48);
                if (!stimuliIdx.Contains(tmp))
                {
                    stimuli[idx, 0] = stimuliSample[tmp, 0];
                    stimuli[idx, 1] = stimuliSample[tmp, 1];
                    stimuliIdx[idx++] = tmp;
                }
            }
        }

        public void SetValues(SerialPort serialport, string ID, bool isFan)
        {
            this.serialPort1 = serialport;
            this.isFan = isFan;
            if (isFan)
            {
                setting = "fan";
                labelTrial.Text = "1/48 FAN";
            }
            else
            {
                setting = "vib";
                labelTrial.Text = "1/48 MOTOR";
            }

            this.ID = ID;
            this.trialNum = 0;
        }

        private void setAnswerButtonColor(Color color)
        {
            buttonUp.BackColor = color;
            buttonDown.BackColor = color;
            buttonLeft.BackColor = color;
            buttonRight.BackColor = color;
        }

        private void setAnswerButtonEnable(bool enable)
        {
            buttonUp.Enabled = enable;
            buttonDown.Enabled = enable;
            buttonLeft.Enabled = enable;
            buttonRight.Enabled = enable;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.ForeColor = Color.Black;
            buttonPlay.Enabled = false;

            Delay(onsetDelay);

            buttonPlay.ForeColor = Color.White;
            buttonPlay.BackColor = Color.Gray;
            currPattern = callPattern();
            playPattern(currPattern);
            Delay(duration);

            buttonPlay.ForeColor = Color.Black;
            buttonPlay.BackColor = Color.Black;

            setAnswerButtonColor(Color.Gray);
            setAnswerButtonEnable(true);
        }

        private void scoreAnswer(int answer)
        {
            if ((answer == currPattern[0] && isFan) || (answer == currPattern[1] && !isFan))
            {
                tw.Write(answer + "," + "1\n");
            }
            else
            {
                tw.Write(answer + "," + "0\n");
            }

            if (trialNum < 48)
            {
                buttonPlay.Enabled = true;
                buttonPlay.ForeColor = Color.White;

                setAnswerButtonColor(Color.Black);
                setAnswerButtonEnable(false);

                if(isFan)
                    labelTrial.Text = (trialNum + 1).ToString() + "/48 FAN";
                else
                    labelTrial.Text = (trialNum + 1).ToString() + "/48 MOTOR";
            }
            else
            {
                setAnswerButtonColor(Color.Black);
                setAnswerButtonEnable(false);

                labelTrial.Text = "Finished!";
            }
        }

        private void Exp2_FormClosing(object sender, FormClosingEventArgs e)
        {
            tw.Close();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.up);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.down);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.left);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.right);
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

            tw.Write(++trialNum + "," + command + ",");
            serialPort1.WriteLine(command);
        }

        private int[] callPattern()
        {
            int[] pattern = new int[2];
            pattern[0] = stimuli[trialNum, 0];
            pattern[1] = stimuli[trialNum, 1];
            return pattern;
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
