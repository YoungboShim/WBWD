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
    public partial class ExpManager : Form
    {
        Training train;
        Exp1 exp1;
        int testIdx = -1;
        bool isFan = true;
        public ExpManager()
        {
            InitializeComponent();
        }

        private void ExpManager_Load(object sender, EventArgs e)
        {
            panelSerial.Enabled = true;
            panelSetting.Enabled = false;
            buttonStart.Enabled = false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Get available ports
            String[] ports = SerialPort.GetPortNames();
            // Display ports in combobox
            comboBoxSerials.Items.Clear();
            comboBoxSerials.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxSerials.SelectedIndex = comboBoxSerials.Items.Count - 1;
                serialPort1.BaudRate = 115200;
                serialPort1.DtrEnable = true;
                serialPort1.RtsEnable = true;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            //Connect to combobox selected serial port
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = (String)comboBoxSerials.Items[comboBoxSerials.SelectedIndex];
                serialPort1.Open();
                string line = serialPort1.ReadExisting();
                Console.WriteLine("Start");
                if(line == "Ready for command...")
                    buttonConnect.BackColor = Color.Orange;

                panelSetting.Enabled = true;
            }
            else
            {
                serialPort1.Close();
                buttonConnect.BackColor = SystemColors.ButtonFace;
            }
        }

        private void comboBoxTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            testIdx = comboBoxTest.SelectedIndex;
            buttonStart.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            switch(testIdx)
            {
                case 0:
                    train = new Training();
                    train.SetValues(serialPort1);                    
                    train.Show();
                    break;
                case 1:
                    exp1 = new Exp1();
                    exp1.SetValues(serialPort1, textBoxID.Text, isFan);
                    exp1.Show();
                    break;
                default:
                    break;
            }
        }

        private void comboBoxFanMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFanMotor.SelectedIndex == 0)
            {
                isFan = true;
            }
            else
            {
                isFan = false;
            }
        }
    }
}
