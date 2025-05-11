using System.Net;
using System.Net.Sockets;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace tcpTempMonitor
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private Thread listenerThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false; // 새 행 추가 비활성화
            dataGridView1.RowHeadersVisible = false; //  행 번호 및 화살표 숨기기
            // DataGridView 설정
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "MAC Address";
            dataGridView1.Columns[1].Name = "Temperature (°C)";
            dataGridView1.Columns[2].Name = "Humidity (%)";
            dataGridView1.Columns[3].Name = "Receive Time";

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // TCP 서버 시작
            listenerThread = new Thread(StartTcpServer);
            listenerThread.IsBackground = true;
            listenerThread.Start();
        }
        private void StartTcpServer()
        {
            tcpListener = new TcpListener(IPAddress.Any, 5000);
            tcpListener.Start();

            while (true)
            {
                try
                {
                    var client = tcpListener.AcceptTcpClient();
                    Console.WriteLine("Client connected!");
                    var clientThread = new Thread(() => HandleClient(client));
                    clientThread.IsBackground = true;
                    clientThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Server error: {ex.Message}");
                }
            }
        }

        private void HandleClient(TcpClient client)
        {
            using (var stream = client.GetStream())
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        var data = JsonConvert.DeserializeObject<SensorData>(line);
                        if (data != null)
                        {
                            data.ReceiveTime = DateTime.Now;

                            this.Invoke(new Action(() =>
                            {
                                dataGridView1.Rows.Add(data.Mac, data.Temp, data.Humi, data.ReceiveTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            }));
                        }
                    }
                    catch (Newtonsoft.Json.JsonException ex)
                    {
                        Console.WriteLine($"JSON 파싱 오류: {ex.Message}");
                    }
                }
            }

            client.Close();
        }

        public class SensorData
        {
            [JsonProperty("mac")]
            public string Mac { get; set; }

            [JsonProperty("temp")]
            public double Temp { get; set; }

            [JsonProperty("humi")]
            public double Humi { get; set; }

            [Newtonsoft.Json.JsonIgnore]
            public DateTime ReceiveTime { get; set; }
        }
    }
}