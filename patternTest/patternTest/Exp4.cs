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
        bool answerMode = false;
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
            buttonPlay.Visible = false;

            setAnswerButtonEnable(true);
        }

        private void playPattern(string pattern)
        {
            tw.Write(ID + "," + ++trialNum + "," + pattern + ",");
            tw.Flush();
            serialPort1.WriteLine(pattern);
            answerMode = true;
        }

        public Exp4()
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

            button1.MouseEnter += buttonPlay_MouseEnter;
            button2.MouseEnter += buttonPlay_MouseEnter;
            button3.MouseEnter += buttonPlay_MouseEnter;
            button4.MouseEnter += buttonPlay_MouseEnter;
            button5.MouseEnter += buttonPlay_MouseEnter;
            button6.MouseEnter += buttonPlay_MouseEnter;
            button7.MouseEnter += buttonPlay_MouseEnter;
            button8.MouseEnter += buttonPlay_MouseEnter;
            button9.MouseEnter += buttonPlay_MouseEnter;
            button10.MouseEnter += buttonPlay_MouseEnter;
            button11.MouseEnter += buttonPlay_MouseEnter;
            button12.MouseEnter += buttonPlay_MouseEnter;
            button13.MouseEnter += buttonPlay_MouseEnter;
            button14.MouseEnter += buttonPlay_MouseEnter;
            button15.MouseEnter += buttonPlay_MouseEnter;
            button16.MouseEnter += buttonPlay_MouseEnter;

            button1.MouseLeave += buttonPlay_MouseLeave;
            button2.MouseLeave += buttonPlay_MouseLeave;
            button3.MouseLeave += buttonPlay_MouseLeave;
            button4.MouseLeave += buttonPlay_MouseLeave;
            button5.MouseLeave += buttonPlay_MouseLeave;
            button6.MouseLeave += buttonPlay_MouseLeave;
            button7.MouseLeave += buttonPlay_MouseLeave;
            button8.MouseLeave += buttonPlay_MouseLeave;
            button9.MouseLeave += buttonPlay_MouseLeave;
            button10.MouseLeave += buttonPlay_MouseLeave;
            button11.MouseLeave += buttonPlay_MouseLeave;
            button12.MouseLeave += buttonPlay_MouseLeave;
            button13.MouseLeave += buttonPlay_MouseLeave;
            button14.MouseLeave += buttonPlay_MouseLeave;
            button15.MouseLeave += buttonPlay_MouseLeave;
            button16.MouseLeave += buttonPlay_MouseLeave;
        }

        private void Exp4_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            tw = new StreamWriter("Exp4_" + ID + "_" + setting + ".csv", true);
            tw.WriteLine("Name,Mode,Trial#,Stimuli,Fan,Motor,RT,Answer,Correct");
            tw.Flush();

            twT = new StreamWriter("Exp4_condition.csv", true);

            shuffleStimuli();

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
            if (answerMode)
            {
                btn.FlatAppearance.BorderColor = Color.White;
                btn.FlatAppearance.BorderSize = 1;
            }
        }

        private void buttonPlay_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.Blue;
            btn.FlatAppearance.BorderSize = 5;
        }

        public void SetValues(SerialPort serialport, string ID)
        {
            this.serialPort1 = serialport;
            labelTrial.Text = "1/48";

            this.ID = ID;
            this.trialNum = 0;
        }

        private void buttonAnswer_Click(object sender, EventArgs e)
        {
            answerString = ((Button)sender).Tag.ToString();
            answerMode = false;
            setAnswerButtonEnable(false);
            scoreAnswer(answerString);
            answerString = "";
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
                labelWait.Visible = true;
                setAnswerButtonEnable(false);
                Delay(ISI);

                labelWait.Visible = false;
                labelWait.Enabled = false;
                buttonPlay.Enabled = true;
                buttonPlay.Visible = true;
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
                buttonPlay.Visible = false;
                labelWait.Text = "Finished!";
                labelWait.Enabled = true;
                labelWait.Visible = true;
            }
        }

        private void setAnswerButtonEnable(bool enable)
        {
            button1.Enabled = enable;
            button2.Enabled = enable;
            button3.Enabled = enable;
            button4.Enabled = enable;
            button5.Enabled = enable;
            button6.Enabled = enable;
            button7.Enabled = enable;
            button8.Enabled = enable;
            button9.Enabled = enable;
            button10.Enabled = enable;
            button11.Enabled = enable;
            button12.Enabled = enable;
            button13.Enabled = enable;
            button14.Enabled = enable;
            button15.Enabled = enable;
            button16.Enabled = enable;

            button1.Visible = enable;
            button2.Visible = enable;
            button3.Visible = enable;
            button4.Visible = enable;
            button5.Visible = enable;
            button6.Visible = enable;
            button7.Visible = enable;
            button8.Visible = enable;
            button9.Visible = enable;
            button10.Visible = enable;
            button11.Visible = enable;
            button12.Visible = enable;
            button13.Visible = enable;
            button14.Visible = enable;
            button15.Visible = enable;
            button16.Visible = enable;
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
