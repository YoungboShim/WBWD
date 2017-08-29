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
    public partial class Training3 : Form
    {
        enum tactors { a, b, c, d, n };
        string[] stimuliAll = { "ndnb", "nanc", "ndnc", "nanb", "ndbn", "nacn", "ndcn", "nabn", "dnnb", "annc", "dnnc", "annb", "dnbn", "ancn", "dncn", "anbn" };
        int onsetDelay = 500, duration = 1500, ISI = 1000;
        string currPattern = "";
        bool answerMode = false;
        public Training3()
        {
            InitializeComponent();

            button1.Click += buttonTactor_Click;
            button2.Click += buttonTactor_Click;
            button3.Click += buttonTactor_Click;
            button4.Click += buttonTactor_Click;
            button5.Click += buttonTactor_Click;
            button6.Click += buttonTactor_Click;
            button7.Click += buttonTactor_Click;
            button8.Click += buttonTactor_Click;
            button9.Click += buttonTactor_Click;
            button10.Click += buttonTactor_Click;
            button11.Click += buttonTactor_Click;
            button12.Click += buttonTactor_Click;
            button13.Click += buttonTactor_Click;
            button14.Click += buttonTactor_Click;
            button15.Click += buttonTactor_Click;
            button16.Click += buttonTactor_Click;

            button1.MouseEnter += buttonTactor_MouseEnter;
            button2.MouseEnter += buttonTactor_MouseEnter;
            button3.MouseEnter += buttonTactor_MouseEnter;
            button4.MouseEnter += buttonTactor_MouseEnter;
            button5.MouseEnter += buttonTactor_MouseEnter;
            button6.MouseEnter += buttonTactor_MouseEnter;
            button7.MouseEnter += buttonTactor_MouseEnter;
            button8.MouseEnter += buttonTactor_MouseEnter;
            button9.MouseEnter += buttonTactor_MouseEnter;
            button10.MouseEnter += buttonTactor_MouseEnter;
            button11.MouseEnter += buttonTactor_MouseEnter;
            button12.MouseEnter += buttonTactor_MouseEnter;
            button13.MouseEnter += buttonTactor_MouseEnter;
            button14.MouseEnter += buttonTactor_MouseEnter;
            button15.MouseEnter += buttonTactor_MouseEnter;
            button16.MouseEnter += buttonTactor_MouseEnter;
            buttonPlay.MouseEnter += buttonTactor_MouseEnter;

            button1.MouseLeave += buttonTactor_MouseLeave;
            button2.MouseLeave += buttonTactor_MouseLeave;
            button3.MouseLeave += buttonTactor_MouseLeave;
            button4.MouseLeave += buttonTactor_MouseLeave;
            button5.MouseLeave += buttonTactor_MouseLeave;
            button6.MouseLeave += buttonTactor_MouseLeave;
            button7.MouseLeave += buttonTactor_MouseLeave;
            button8.MouseLeave += buttonTactor_MouseLeave;
            button9.MouseLeave += buttonTactor_MouseLeave;
            button10.MouseLeave += buttonTactor_MouseLeave;
            button11.MouseLeave += buttonTactor_MouseLeave;
            button12.MouseLeave += buttonTactor_MouseLeave;
            button13.MouseLeave += buttonTactor_MouseLeave;
            button14.MouseLeave += buttonTactor_MouseLeave;
            button15.MouseLeave += buttonTactor_MouseLeave;
            button16.MouseLeave += buttonTactor_MouseLeave;
            buttonPlay.MouseLeave += buttonTactor_MouseLeave;
        }

        private void Training3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void buttonTactor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (answerMode)
            {
                buttonPlay.Visible = false;
                if (currPattern == button.Tag.ToString())
                {
                    button.FlatAppearance.BorderColor = Color.Lime;
                    Delay(100);
                    button.FlatAppearance.BorderColor = Color.Black;
                    Delay(100);
                    button.FlatAppearance.BorderColor = Color.Lime;
                    Delay(700);
                    button.FlatAppearance.BorderColor = Color.Black;
                }
                else
                {
                    Button buttonAnswer = findButton(currPattern);
                    if(buttonAnswer != null)
                    {
                        button.FlatAppearance.BorderColor = Color.Red;
                        buttonAnswer.FlatAppearance.BorderColor = Color.Lime;
                        Delay(100);
                        button.FlatAppearance.BorderColor = Color.Black;
                        buttonAnswer.FlatAppearance.BorderColor = Color.Black;
                        Delay(100);
                        button.FlatAppearance.BorderColor = Color.Red;
                        buttonAnswer.FlatAppearance.BorderColor = Color.Lime;
                        Delay(700);
                        button.FlatAppearance.BorderColor = Color.Black;
                        buttonAnswer.FlatAppearance.BorderColor = Color.Black;
                    }
                }
                buttonPlay.Visible = true;
                buttonPlay.Enabled = true;
                answerMode = false;
            }
            else
            {
                playPattern(button.Tag.ToString());
            }
        }

        private Button findButton(string pattern)
        {
            if (button1.Tag.ToString() == pattern)
                return button1;
            if (button2.Tag.ToString() == pattern)
                return button2;
            if (button3.Tag.ToString() == pattern)
                return button3;
            if (button4.Tag.ToString() == pattern)
                return button4;
            if (button5.Tag.ToString() == pattern)
                return button5;
            if (button6.Tag.ToString() == pattern)
                return button6;
            if (button7.Tag.ToString() == pattern)
                return button7;
            if (button8.Tag.ToString() == pattern)
                return button8;
            if (button9.Tag.ToString() == pattern)
                return button9;
            if (button10.Tag.ToString() == pattern)
                return button10;
            if (button11.Tag.ToString() == pattern)
                return button11;
            if (button12.Tag.ToString() == pattern)
                return button12;
            if (button13.Tag.ToString() == pattern)
                return button13;
            if (button14.Tag.ToString() == pattern)
                return button14;
            if (button15.Tag.ToString() == pattern)
                return button15;
            if (button16.Tag.ToString() == pattern)
                return button16;
            return null;
        }


        private void playPattern(string pattern)
        {
            buttonPlay.Visible = false;
            Delay(onsetDelay);
            serialPort1.WriteLine(pattern);
            buttonPlay.Visible = true;
            buttonPlay.BackColor = Color.Blue;
            Delay(duration);
            buttonPlay.BackColor = Color.Gray;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int randIdx = random.Next(16);
            currPattern = stimuliAll[randIdx];
            buttonPlay.Enabled = false;
            playPattern(currPattern);
            answerMode = true;
            buttonPlay.Enabled = false;
        }

        public void SetValues(SerialPort serialport)
        {
            this.serialPort1 = serialport;
        }

        private void buttonTactor_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.White;
        }

        private void buttonTactor_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.FlatAppearance.BorderColor = Color.Black;
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
