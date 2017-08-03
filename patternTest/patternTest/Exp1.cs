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
        int onsetDelay = 500, duration = 1500, ISI = 1000;
        int tStart = 0, tEnd = 0;
        long tAsk = 0, tAnswer = 0;
        bool isFan = true, answerMode = false;
        string ID, setting;
        TextWriter tw, twT;

        public Exp1()
        {
            InitializeComponent();

            buttonLeft.MouseEnter += buttonPlay_MouseEnter;
            buttonRight.MouseEnter += buttonPlay_MouseEnter;
            buttonUp.MouseEnter += buttonPlay_MouseEnter;
            buttonDown.MouseEnter += buttonPlay_MouseEnter;

            buttonLeft.MouseLeave += buttonPlay_MouseLeave;
            buttonRight.MouseLeave += buttonPlay_MouseLeave;
            buttonUp.MouseLeave += buttonPlay_MouseLeave;
            buttonDown.MouseLeave += buttonPlay_MouseLeave;
        }

        private void Exp1_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;

            tw = new StreamWriter("Exp1_" + ID + "_" + setting + ".csv", true);
            tw.WriteLine("Name,Mode,Trial#,Stimuli,Fan,Motor,RT,Answer,Correct");
            tw.Flush();

            twT = new StreamWriter("Exp1_condition.csv", true);

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
            tAnswer = DateTime.Now.Ticks;
            long RT = (tAnswer - tAsk) / 10000;

            if(answer == currPattern)
            {
                tw.Write(RT + "," + answer + "," + "1\n");
                tw.Flush();
            }
            else
            {
                tw.Write(RT + "," + answer + "," + "0\n");
                tw.Flush();
            }

            if (trialNum < 48)
            {
                setAnswerButtonColor(Color.Black);
                labelWait.Enabled = true;
                setAnswerButtonEnable(false);
                Delay(ISI);

                labelWait.Enabled = false;
                buttonPlay.Enabled = true;
                buttonPlay.ForeColor = Color.White;

                setAnswerButtonColor(Color.Black);
                setAnswerButtonEnable(false);

                labelTrial.Text = (trialNum + 1).ToString() + "/48";
            }
            else
            {
                tEnd = DateTime.Now.Minute;
                int tExp = tEnd - tStart;
                if(tExp < 0)
                {
                    tExp += 60;
                }
                twT.WriteLine(ID + "," + setting + "," + tExp.ToString());
                twT.Flush();

                setAnswerButtonColor(Color.Black);
                setAnswerButtonEnable(false);

                labelTrial.Text = "Finished!";
                buttonPlay.Enabled = false;
                labelWait.Text = "Finished!";
                labelWait.Enabled = true;
            }
            answerMode = false;
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

            tw.Write(ID + "," + setting + "," + ++trialNum + "," + command + "," + command[0] + "," + command[1] + ",");
            tw.Flush();
            serialPort1.WriteLine(command);
            answerMode = true;
        }

        private int callPattern()
        {
            return stimuli[trialNum];
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DarkBlue;
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (answerMode)
                btn.BackColor = Color.Gray;
            else
                btn.BackColor = Color.Black;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if(trialNum == 0)
            {
                tStart = DateTime.Now.Minute;
            }
            buttonPlay.ForeColor = Color.Black;
            buttonPlay.Enabled = false;

            Delay(onsetDelay);
            
            buttonPlay.ForeColor = Color.White;
            buttonPlay.BackColor = Color.Gray;
            currPattern = callPattern();
            playPattern(currPattern);
            tAsk = DateTime.Now.Ticks;
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
            twT.Close();
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
