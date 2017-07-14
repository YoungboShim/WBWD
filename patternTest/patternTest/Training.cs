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
        enum patterns {up, down, left, right, none, random};

        bool fanPatternSelected = false, motorPatternSelected = false;
        int fanPatternIdx = (int)patterns.none, motorPatternIdx = (int)patterns.none;

        public Training()
        {
            InitializeComponent();
            Training_Load();
        }

        private void Training_Load()
        {
            // Get available ports
            String[] ports = SerialPort.GetPortNames();
            // Display ports in combobox
            comboBoxSerials.Items.Clear();
            comboBoxSerials.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxSerials.SelectedIndex = comboBoxSerials.Items.Count - 1;
                serialPort1.BaudRate = 9600;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
            }
        }

        private void buttonSerialConnect_Click(object sender, EventArgs e)
        {
            //Connect to combobox selected serial port
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = (String)comboBoxSerials.Items[comboBoxSerials.SelectedIndex];
                serialPort1.Open();
                serialPort1.ReadExisting();
                buttonSerialConnect.BackColor = Color.Orange;
                logWrite("Connected to " + serialPort1.PortName);
            }
            else
            {
                serialPort1.Close();
                buttonSerialConnect.BackColor = SystemColors.ButtonFace;
                logWrite("Disconnected from " + serialPort1.PortName);
            }
        }

        private void logWrite(string s)
        {
            textBoxLog.Text += s + "\r\n";
            textBoxLog.Select(textBoxLog.TextLength, 0);
            textBoxLog.ScrollToCaret();
        }

        // Turn off fan's button
        private void fanBtnTurnOff(int idx)
        {
            switch(idx)
            {
                case (int)patterns.up:
                    buttonUp.BackColor = Color.Black;
                    break;
                case (int)patterns.down:
                    buttonDown.BackColor = Color.Black;
                    break;
                case (int)patterns.left:
                    buttonLeft.BackColor = Color.Black;
                    break;
                case (int)patterns.right:
                    buttonRight.BackColor = Color.Black;
                    break;
                case (int)patterns.random:
                    buttonRandom.BackColor = Color.Black;
                    break;
                default:
                    break;
            }
        }

        // Turn off motor's button
        private void motorBtnTurnOff(int idx)
        {
            switch (idx)
            {
                case (int)patterns.up:
                    buttonMotorUp.BackColor = Color.Black;
                    break;
                case (int)patterns.down:
                    buttonMotorDown.BackColor = Color.Black;
                    break;
                case (int)patterns.left:
                    buttonMotorLeft.BackColor = Color.Black;
                    break;
                case (int)patterns.right:
                    buttonMotorRight.BackColor = Color.Black;
                    break;
                case (int)patterns.random:
                    buttonMotorRandom.BackColor = Color.Black;
                    break;
                default:
                    break;
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if(buttonUp.BackColor != Color.Navy)
            {
                logWrite("Fan Up");
                if(fanPatternSelected)
                {
                    fanBtnTurnOff(fanPatternIdx);
                }
                fanPatternSelected = true;
                fanPatternIdx = (int)patterns.up;
                buttonUp.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Fan No Pattern");
                fanPatternSelected = false;
                fanPatternIdx = (int)patterns.none;
                buttonUp.BackColor = Color.Black;
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (buttonRight.BackColor != Color.Navy)
            {
                logWrite("Fan Right");
                if (fanPatternSelected)
                {
                    fanBtnTurnOff(fanPatternIdx);
                }
                fanPatternSelected = true;
                fanPatternIdx = (int)patterns.right;
                buttonRight.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Fan No Pattern");
                fanPatternSelected = false;
                fanPatternIdx = (int)patterns.none;
                buttonRight.BackColor = Color.Black;
            }
        }

        private void buttonMotorUp_Click(object sender, EventArgs e)
        {
            if (buttonMotorUp.BackColor != Color.Navy)
            {
                logWrite("Motor Up");
                if (motorPatternSelected)
                {
                    motorBtnTurnOff(motorPatternIdx);
                }
                motorPatternSelected = true;
                motorPatternIdx = (int)patterns.up;
                buttonMotorUp.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Motor No Pattern");
                motorPatternSelected = false;
                motorPatternIdx = (int)patterns.none;
                buttonMotorUp.BackColor = Color.Black;
            }
        }

        private void buttonMotorDown_Click(object sender, EventArgs e)
        {
            if (buttonMotorDown.BackColor != Color.Navy)
            {
                logWrite("Motor Down");
                if (motorPatternSelected)
                {
                    motorBtnTurnOff(motorPatternIdx);
                }
                motorPatternSelected = true;
                motorPatternIdx = (int)patterns.down;
                buttonMotorDown.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Motor No Pattern");
                motorPatternSelected = false;
                motorPatternIdx = (int)patterns.none;
                buttonMotorDown.BackColor = Color.Black;
            }
        }

        private void buttonMotorLeft_Click(object sender, EventArgs e)
        {
            if (buttonMotorLeft.BackColor != Color.Navy)
            {
                logWrite("Motor Left");
                if (motorPatternSelected)
                {
                    motorBtnTurnOff(motorPatternIdx);
                }
                motorPatternSelected = true;
                motorPatternIdx = (int)patterns.left;
                buttonMotorLeft.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Motor No Pattern");
                motorPatternSelected = false;
                motorPatternIdx = (int)patterns.none;
                buttonMotorLeft.BackColor = Color.Black;
            }
        }

        private void buttonMotorRight_Click(object sender, EventArgs e)
        {
            if (buttonMotorRight.BackColor != Color.Navy)
            {
                logWrite("Motor Right");
                if (motorPatternSelected)
                {
                    motorBtnTurnOff(motorPatternIdx);
                }
                motorPatternSelected = true;
                motorPatternIdx = (int)patterns.right;
                buttonMotorRight.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Motor No Pattern");
                motorPatternSelected = false;
                motorPatternIdx = (int)patterns.none;
                buttonMotorRight.BackColor = Color.Black;
            }
        }

        private void buttonMotorRandom_Click(object sender, EventArgs e)
        {
            if (buttonMotorRandom.BackColor != Color.Navy)
            {
                logWrite("Motor Rnadom");
                if (motorPatternSelected)
                {
                    motorBtnTurnOff(motorPatternIdx);
                }
                motorPatternSelected = true;
                motorPatternIdx = (int)patterns.random;
                buttonMotorRandom.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Motor No Pattern");
                motorPatternSelected = false;
                motorPatternIdx = (int)patterns.none;
                buttonMotorRandom.BackColor = Color.Black;
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            if (buttonRandom.BackColor != Color.Navy)
            {
                logWrite("Fan Random");
                if (fanPatternSelected)
                {
                    fanBtnTurnOff(fanPatternIdx);
                }
                fanPatternSelected = true;
                fanPatternIdx = (int)patterns.random;
                buttonRandom.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Fan No Pattern");
                fanPatternSelected = false;
                fanPatternIdx = (int)patterns.none;
                buttonRandom.BackColor = Color.Black;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string command = "";
                int tmpFanIdx = fanPatternIdx, tmpMotorIdx = motorPatternIdx;
                if (fanPatternIdx == (int)patterns.random)
                {
                    Random rand1 = new Random();
                    tmpFanIdx = rand1.Next(5);
                }
                if (motorPatternIdx == (int)patterns.random)
                {
                    Random rand2 = new Random();
                    tmpMotorIdx = rand2.Next(5);
                }
                switch (tmpFanIdx)
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
                    case (int)patterns.none:
                        command += "n";
                        break;
                    default:
                        break;
                }
                switch (tmpMotorIdx)
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
                    case (int)patterns.none:
                        command += "n";
                        break;
                    default:
                        break;
                }
                serialPort1.WriteLine(command);
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (buttonLeft.BackColor != Color.Navy)
            {
                logWrite("Fan Left");
                if (fanPatternSelected)
                {
                    fanBtnTurnOff(fanPatternIdx);
                }
                fanPatternSelected = true;
                fanPatternIdx = (int)patterns.left;
                buttonLeft.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Fan No Pattern");
                fanPatternSelected = false;
                fanPatternIdx = (int)patterns.none;
                buttonLeft.BackColor = Color.Black;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (buttonDown.BackColor != Color.Navy)
            {
                logWrite("Fan Down");
                if (fanPatternSelected)
                {
                    fanBtnTurnOff(fanPatternIdx);
                }
                fanPatternSelected = true;
                fanPatternIdx = (int)patterns.down;
                buttonDown.BackColor = Color.Navy;
            }
            else
            {
                logWrite("Fan No Pattern");
                fanPatternSelected = false;
                fanPatternIdx = (int)patterns.none;
                buttonDown.BackColor = Color.Black;
            }
        }
    }
}
