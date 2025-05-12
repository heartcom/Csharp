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
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChartTempHumi
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            SetupChart();
            LoadSerialPorts();
        }
        private void SetupChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");
            chart1.ChartAreas.Add(area);

            // 온도 시리즈
            Series tempSeries = new Series("온도");
            tempSeries.ChartType = SeriesChartType.Line;
            tempSeries.Color = Color.Red;
            tempSeries.MarkerStyle = MarkerStyle.Circle;  // 도형: 원
            tempSeries.MarkerSize = 8;                    // 크기
            tempSeries.MarkerColor = Color.Red;           // 마커 색상
            tempSeries.ChartArea = "MainArea";
            chart1.Series.Add(tempSeries);

            // 습도 시리즈
            Series humidSeries = new Series("습도");
            humidSeries.ChartType = SeriesChartType.Line;
            humidSeries.Color = Color.Blue;
            humidSeries.MarkerStyle = MarkerStyle.Diamond;  // 도형: 다이아몬드
            humidSeries.MarkerSize = 8;                     // 크기
            humidSeries.MarkerColor = Color.Blue;           // 마커 색상
            humidSeries.ChartArea = "MainArea";
            chart1.Series.Add(humidSeries);
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
        private void Form1_Load(object sender, EventArgs e)
        {

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
                         float.TryParse(parts[1], out float humid))
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtTemp.Text = temp.ToString("0.0");
                        txtHumi.Text = humid.ToString("0.0");

                        // Chart에 데이터 추가
                        chart1.Series["온도"].Points.AddY(temp);
                        chart1.Series["습도"].Points.AddY(humid);

                        // 포인트 수 제한 (최근 50개)
                        if (chart1.Series["온도"].Points.Count > 50)
                        {
                          chart1.Series["온도"].Points.RemoveAt(0);
                          chart1.Series["습도"].Points.RemoveAt(0);
                        }
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

