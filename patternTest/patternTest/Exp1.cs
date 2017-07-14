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

namespace patternTest
{
    public partial class Exp1 : Form
    {
        int onsetDelay = 500, duration = 500;
        bool answered = true;

        public Exp1()
        {
            InitializeComponent();
        }

        private void Exp1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;

            setAnswerButtonEnable(false);
        }

        public void SetValues(SerialPort serialport)
        {
            serialPort1 = serialport;
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

        private void setAnswered()
        {
            answered = true;
            buttonPlay.Enabled = true;
            buttonPlay.ForeColor = Color.White;

            setAnswerButtonColor(Color.Black);
            setAnswerButtonEnable(false);
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.ForeColor = Color.Black;
            buttonPlay.Enabled = false;

            Delay(onsetDelay);
            
            buttonPlay.ForeColor = Color.White;
            buttonPlay.BackColor = Color.Gray;
            serialPort1.WriteLine("un");
            Delay(duration);

            answered = false;
            buttonPlay.ForeColor = Color.Black;
            buttonPlay.BackColor = Color.Black;

            setAnswerButtonColor(Color.Gray);
            setAnswerButtonEnable(true);
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            setAnswered();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            setAnswered();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            setAnswered();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            setAnswered();
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
