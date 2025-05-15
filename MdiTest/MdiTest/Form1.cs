using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiTest
{
    public partial class Form1 : Form
    {
        private ViewData viewDataForm;
        private ViewGraph viewGraphForm;

        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();

            // PictureBox 클릭 이벤트 연결
            pictureBox1.Click += (s, e) => LoadChildForm(new ViewData());
            pictureBox2.Click += (s, e) => LoadChildForm(new ViewGraph());

            LoadSerialPorts();
        }
        private void LoadSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Text = "None";
            }
        }
        private void LoadChildForm(Form childForm)
        {
            // 기존 컨트롤 제거
            mainPanel.Controls.Clear();

            // ChildForm 설정
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Panel에 추가
            mainPanel.Controls.Add(childForm);
            childForm.Show();

            // 타입에 따라 인스턴스를 저장
            if (childForm is ViewData vd)
                viewDataForm = vd;
            else if (childForm is ViewGraph vg)
                viewGraphForm = vg;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedPort = comboBox1.SelectedItem.ToString();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string selectedPort = comboBox1.SelectedItem.ToString();
                if (string.IsNullOrEmpty(selectedPort) || selectedPort == "None")
                {
                    MessageBox.Show("Please select a valid Port.");
                    return;
                }
                try
                {
                    serialPort = new SerialPort(selectedPort)
                    {
                        BaudRate = 115200,
                        DataBits = 8,
                        Parity = Parity.None,
                        StopBits = StopBits.One,
                    };
                    serialPort.DataReceived += SerialPort_DataReceived;   //Event Handler
                    serialPort.Open();
                    MessageBox.Show("Serial Port Connected");
                    btnConnect.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fail to Connect : {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a valid Port.");
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string line = serialPort.ReadLine().Trim(); // 예: "23.5,45.2"
                string[] parts = line.Split(',');
                if (parts.Length == 2 &&
                         float.TryParse(parts[0], out float temp) &&
                         float.TryParse(parts[1], out float humi))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        viewDataForm?.UpdateValues(temp, humi);
                        viewGraphForm?.AddDataPoint(temp, humi);
                    });
                }
            }
            catch (Exception ex)
            {
                // 에러 무시하거나 로깅
            }
        }
    }
}
