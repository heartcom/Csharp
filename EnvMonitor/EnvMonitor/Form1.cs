using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace EnvMonitor
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private Thread listenerThread;
        private List<SensorData> sensorDataList = new List<SensorData>();
        private string connectionString = "Server=localhost;Database=SensorDB;uid=sa;pwd=12345678;TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Temperature (°C)";
            dataGridView1.Columns[1].Name = "Humidity (%)";
            dataGridView1.Columns[2].Name = "Receive Time";
            dataGridView1.Columns[3].Name = "MAC Address";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;

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
                var client = tcpListener.AcceptTcpClient();
                var thread = new Thread(() => HandleClient(client));
                thread.IsBackground = true;
                thread.Start();
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

                            lock (sensorDataList)
                            {
                                sensorDataList.Add(data);
                            }
                            SaveToDatabase(data);
                            this.Invoke(() =>
                            {
                                if (!listBox1.Items.Contains(data.Mac))
                                    listBox1.Items.Add(data.Mac);

                                if (listBox1.SelectedItem?.ToString() == data.Mac)
                                    AddDataToGrid(data);
                            });
                        }
                    }
                    catch (JsonException) { }
                }
            }

            client.Close();
        }

        private void AddDataToGrid(SensorData data)
        {
            dataGridView1.Rows.Add(
                data.Temp.ToString("0.0"),
                data.Humi.ToString("0.0"),
                data.ReceiveTime.ToString("yyyy-MM-dd HH:mm:ss"),
                data.Mac
            );
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMac = listBox1.SelectedItem.ToString();
            dataGridView1.Rows.Clear();

            lock (sensorDataList)
            {
                foreach (var data in sensorDataList.Where(d => d.Mac == selectedMac))
                {
                    AddDataToGrid(data);
                }
            }
        }

        private void SaveToDatabase(SensorData data)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // tblDevices에서 MAC 주소 확인 (MacAddress에 해당하는 DeviceID를 가져옵니다)
                    SqlCommand checkMacCmd = new SqlCommand("SELECT DeviceID FROM tblDevices WHERE MacAddress = @mac", conn);
                    checkMacCmd.Parameters.AddWithValue("@mac", data.Mac);
                    object result = checkMacCmd.ExecuteScalar();

                    // MAC 주소가 없으면 데이터를 무시하고 종료
                    if (result == null)
                    {
                        MessageBox.Show("Not registered in DB.");
                        Debug.WriteLine($"MAC address {data.Mac} not found. Data will be ignored.");
                        return;
                    }

                    // tblDevices에 존재하는 MAC 주소의 DeviceID 가져오기
                    int deviceId = (int)result;

                    // tblSensorData에 센서 데이터 삽입
                    SqlCommand insertSensorCmd = new SqlCommand(
                        "INSERT INTO tblSensorData (MacAddress, Temperature, Humidity, ReceivedTime) VALUES (@mac, @temp, @humi, @time)", conn);
                    insertSensorCmd.Parameters.AddWithValue("@mac", data.Mac);  // MacAddress 삽입
                    insertSensorCmd.Parameters.AddWithValue("@temp", data.Temp);
                    insertSensorCmd.Parameters.AddWithValue("@humi", data.Humi);
                    insertSensorCmd.Parameters.AddWithValue("@time", data.ReceiveTime);

                    int rowsAffected = insertSensorCmd.ExecuteNonQuery();
                    Debug.WriteLine($"Inserted {rowsAffected} rows for MAC {data.Mac}");
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine($"SQL error: {ex.Number} - {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error during database operation: {ex.Message}");
            }
        }

        public class SensorData
        {
            [JsonProperty("mac")]
            public string Mac { get; set; }

            [JsonProperty("temp")]
            public double Temp { get; set; }

            [JsonProperty("humi")]
            public double Humi { get; set; }

            [JsonIgnore]
            public DateTime ReceiveTime { get; set; }
        }
    }
}