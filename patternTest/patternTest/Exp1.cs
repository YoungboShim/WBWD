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
    public partial class Exp1 : Form
    {
        enum patterns { up, down, left, right, none};
        int[] stimuliSample = new int[48];
        int[] stimuli = new int[48];
        int[] stimuliIdx = new int[48];
        int trialNum, currPattern;
        int onsetDelay = 500, duration = 1200, ISI = 1000;
        bool isFan = true;
        string ID, setting;
        TextWriter tw;

        public Exp1()
        {
            InitializeComponent();
        }

        private void Exp1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;

            tw = new StreamWriter("Exp1_" + ID + "_" + setting + ".csv", true);
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
                    stimuliSample[12 * i + j] = i;
                    stimuliIdx[12 * i + j] = -1;
                }
            }
            int idx = 0;
            while(idx < 48)
            {
                int tmp = random.Next(48);
                if (!stimuliIdx.Contains(tmp))
                {
                    stimuli[idx] = stimuliSample[tmp];
                    stimuliIdx[idx++] = tmp;
                }
            }
        }

        public void SetValues(SerialPort serialport, string ID, bool isFan)
        {
            this.serialPort1 = serialport;
            this.isFan = isFan;
            if (isFan)
                setting = "fan";
            else
                setting = "vib";

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

        private void scoreAnswer(int answer)
        {
            if(answer == currPattern)
            {
                tw.Write(answer + "," + "1\n");
            }
            else
            {
                tw.Write(answer + "," + "0\n");
            }

            if (trialNum < 48)
            {
                if (isFan)
                {
                    setAnswerButtonColor(Color.Black);
                    labelWait.Enabled = true;
                    Delay(ISI);
                }

                labelWait.Enabled = false;
                buttonPlay.Enabled = true;
                buttonPlay.ForeColor = Color.White;

                setAnswerButtonColor(Color.Black);
                setAnswerButtonEnable(false);

                labelTrial.Text = (trialNum + 1).ToString() + "/48";
            }
            else
            {
                setAnswerButtonColor(Color.Black);
                setAnswerButtonEnable(false);

                labelTrial.Text = "Finished!";
                buttonPlay.Text = "Finish";
            }
        }

        private void playPattern(int pattern)
        {
            string command = "";
            switch(pattern)
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

            if (isFan)
            {
                command = command + "n";
            }
            else
            {
                command = "n" + command;
            }

            tw.Write(++trialNum + "," + command + ",");
            serialPort1.WriteLine(command);
        }

        private int callPattern()
        {
            return stimuli[trialNum];
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

        private void buttonUp_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.up);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.down);
        }

        private void Exp1_FormClosing(object sender, FormClosingEventArgs e)
        {
            tw.Close();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.left);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            scoreAnswer((int)patterns.right);
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
