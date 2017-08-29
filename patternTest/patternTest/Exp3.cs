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
    public partial class Exp3 : Form
    {
        enum tactors { a, b, c, d, n};
        string[] stimuliAll = { "ndnb", "nanc", "ndnc", "nanb", "ndbn", "nacn", "ndcn", "nabn", "dnnb", "annc", "dnnc", "annb", "dnbn", "ancn", "dncn", "anbn" };
        string[] stimuliSample = new string[48];
        string[] stimuli = new string[48];
        int[] stimuliIdx = new int[48];
        int trialNum;
        string currPattern = "";
        int onsetDelay = 500, duration = 1500, ISI = 1000;
        int tStart = 0, tEnd = 0;
        long tAsk = 0, tAnswer = 0;
        bool answerMode = false;
        string ID;
        TextWriter tw, twT;

        public Exp3()
        {
            InitializeComponent();

            button1.Click += buttonAnswer_Click;
            button2.Click += buttonAnswer_Click;
            button3.Click += buttonAnswer_Click;
            button4.Click += buttonAnswer_Click;
            button5.Click += buttonAnswer_Click;
            button6.Click += buttonAnswer_Click;
            button7.Click += buttonAnswer_Click;
            button8.Click += buttonAnswer_Click;
            button9.Click += buttonAnswer_Click;
            button10.Click += buttonAnswer_Click;
            button11.Click += buttonAnswer_Click;
            button12.Click += buttonAnswer_Click;
            button13.Click += buttonAnswer_Click;
            button14.Click += buttonAnswer_Click;
            button15.Click += buttonAnswer_Click;
            button16.Click += buttonAnswer_Click;
        }

        private void Exp3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            tw = new StreamWriter("Exp3_" + ID + ".csv", true);
            tw.WriteLine("Name,Trial#,Stimuli,RT,Answer,Correct");
            tw.Flush();

            twT = new StreamWriter("Exp3_condition.csv", true);

            shuffleStimuli();

            panelAnswer.Enabled = false;
        }

        private void shuffleStimuli()
        {
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    stimuliSample[16 * i + j] = stimuliAll[j];
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

            panelAnswer.Enabled = true;
        }

        private void Exp3_FormClosing(object sender, FormClosingEventArgs e)
        {
            tw.Close();
            twT.Close();
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            scoreAnswer(((Button)sender).Tag.ToString());
        }

        private void playPattern(string pattern)
        {
            tw.Write(ID + "," + ++trialNum + "," + pattern + ",");
            tw.Flush();
            serialPort1.WriteLine(pattern);
            answerMode = true;
        }

        public void SetValues(SerialPort serialport, string ID)
        {
            this.serialPort1 = serialport;
            labelTrial.Text = "1/48";

            this.ID = ID;
            this.trialNum = 0;
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
                labelWait.Enabled = true;
                panelAnswer.Enabled = false;
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

                panelAnswer.Enabled = false;

                labelTrial.Text = "Finished!";
                buttonPlay.Enabled = false;
                labelWait.Text = "Finished!";
                labelWait.Enabled = true;
            }
            answerMode = false;
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
