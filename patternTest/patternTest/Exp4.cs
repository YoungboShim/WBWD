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
    public partial class Exp4 : Form
    {
        enum tactors { a, b, c, d, n };
        string[] stimuliSample = new string[48];
        string[] stimuli = new string[48];
        int[] stimuliIdx = new int[48];
        int trialNum;
        string currPattern = "";
        int onsetDelay = 500, duration = 750, ISI = 1000;
        int tStart = 0, tEnd = 0;
        long tAsk = 0, tAnswer = 0;
        bool isFan = true;
        int answerMode = 0; //0: playmode, 1: first answer, 2: second answer
        string ID, setting, answerString = "";
        TextWriter tw, twT;

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (trialNum == 0)
            {
                tStart = DateTime.Now.Minute;
            }

            buttonPlay.ForeColor = Color.Black;
            buttonPlay.Enabled = false;

            Delay(onsetDelay);

            buttonPlay.ForeColor = Color.White;
            buttonPlay.BackColor = Color.Gray;
            currPattern = stimuli[trialNum];
            playPattern(currPattern);
            tAsk = DateTime.Now.Ticks;
            Delay(duration);

            buttonPlay.ForeColor = Color.Black;
            buttonPlay.BackColor = Color.Black;

            setAnswerButtonColor(Color.DarkOrange);
            setAnswerButtonEnable(true);

            if (isFan)
                labelWait.Text = "Wind";
            else
                labelWait.Text = "Vib";
            labelWait.Enabled = true;
        }

        private void playPattern(string pattern)
        {
            tw.Write(ID + "," + ++trialNum + "," + pattern + ",");
            tw.Flush();
            serialPort1.WriteLine(pattern);
            answerMode = 1;
        }

        public Exp4()
        {
            InitializeComponent();
            buttonA.Click += buttonAnswer_Click;
            buttonB.Click += buttonAnswer_Click;
            buttonC.Click += buttonAnswer_Click;
            buttonD.Click += buttonAnswer_Click;

            buttonA.MouseEnter += buttonPlay_MouseEnter;
            buttonB.MouseEnter += buttonPlay_MouseEnter;
            buttonC.MouseEnter += buttonPlay_MouseEnter;
            buttonD.MouseEnter += buttonPlay_MouseEnter;

            buttonA.MouseLeave += buttonPlay_MouseLeave;
            buttonB.MouseLeave += buttonPlay_MouseLeave;
            buttonC.MouseLeave += buttonPlay_MouseLeave;
            buttonD.MouseLeave += buttonPlay_MouseLeave;
        }

        private void Exp4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            tw = new StreamWriter("Exp4_" + ID + "_" + setting + ".csv", true);
            tw.WriteLine("Name,Mode,Trial#,Stimuli,Fan,Motor,RT,Answer,Correct");
            tw.Flush();

            twT = new StreamWriter("Exp4_condition.csv", true);

            shuffleStimuli();

            setAnswerButtonColor(Color.Black);
            setAnswerButtonEnable(false);
        }

        private void shuffleStimuli()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (j % 4 == 0)
                    {
                        stimuliSample[16 * i + j] = "a";
                    }
                    else if (j % 4 == 1)
                    {
                        stimuliSample[16 * i + j] = "b";
                    }
                    else if (j % 4 == 2)
                    {
                        stimuliSample[16 * i + j] = "c";
                    }
                    else if (j % 4 == 3)
                    {
                        stimuliSample[16 * i + j] = "d";
                    }
                    if (j >= 0 && j < 4)
                    {
                        stimuliSample[16 * i + j] += "a";
                    }
                    else if (j >= 4 && j < 8)
                    {
                        stimuliSample[16 * i + j] += "b";
                    }
                    else if (j >= 8 && j < 12)
                    {
                        stimuliSample[16 * i + j] += "c";
                    }
                    else if (j >= 12 && j < 16)
                    {
                        stimuliSample[16 * i + j] += "d";
                    }
                    stimuliIdx[16 * i + j] = -1;
                }
            }
            int idx = 0;
            while (idx < 48)
            {
                int tmp = random.Next(48);
                if (!stimuliIdx.Contains(tmp))
                {
                    stimuli[idx] = stimuliSample[tmp];
                    stimuliIdx[idx++] = tmp;
                }
            }
        }

        private void buttonPlay_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (answerMode == 1)
                btn.BackColor = Color.DarkOrange;
            else if (answerMode == 2)
                btn.BackColor = Color.DarkCyan;
            else
                btn.BackColor = Color.Black;
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DarkBlue;
        }

        public void SetValues(SerialPort serialport, string ID, bool isFan)
        {
            this.serialPort1 = serialport;
            this.isFan = isFan;
            if (isFan)
            {
                setting = "fan";
                labelTrial.Text = "1/48";
            }
            else
            {
                setting = "vib";
                labelTrial.Text = "1/48";
            }

            this.ID = ID;
            this.trialNum = 0;
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            if (isFan)
                answerString += ((Button)sender).Text;
            else
                answerString = ((Button)sender).Text + answerString;
            if (answerMode == 2)
            {
                answerMode = 0;
                setAnswerButtonColor(Color.Black);
                scoreAnswer(answerString);
                answerString = "";
            }
            else
            {
                answerMode = 2;
                setAnswerButtonColor(Color.DarkCyan);
                if (isFan)
                    labelWait.Text = "Vib";
                else
                    labelWait.Text = "Wind";
            }
        }

        private void scoreAnswer(string answer)
        {
            tAnswer = DateTime.Now.Ticks;
            long RT = (tAnswer - tAsk) / 10000;

            if (answer == currPattern)
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
                labelWait.Text = "Wait!";
                labelWait.Enabled = true;
                setAnswerButtonEnable(false);
                Delay(ISI);

                labelWait.Enabled = false;
                buttonPlay.Enabled = true;
                buttonPlay.ForeColor = Color.White;

                labelTrial.Text = (trialNum + 1).ToString() + "/48";
            }
            else
            {
                tEnd = DateTime.Now.Minute;
                int tExp = tEnd - tStart;
                if (tExp < 0)
                {
                    tExp += 60;
                }
                twT.WriteLine(ID + "," + tExp.ToString());
                twT.Flush();

                setAnswerButtonEnable(false);

                labelTrial.Text = "Finished!";
                buttonPlay.Enabled = false;
                labelWait.Text = "Finished!";
                labelWait.Enabled = true;
            }
        }

        private void setAnswerButtonColor(Color color)
        {
            buttonA.BackColor = color;
            buttonB.BackColor = color;
            buttonC.BackColor = color;
            buttonD.BackColor = color;
        }

        private void setAnswerButtonEnable(bool enable)
        {
            buttonA.Enabled = enable;
            buttonB.Enabled = enable;
            buttonC.Enabled = enable;
            buttonD.Enabled = enable;
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
