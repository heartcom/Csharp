using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;

namespace TcpServer
{
    public partial class Form1 : Form
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private BinaryReader br;
        private BinaryWriter bw;
        private NetworkStream ns;

        int intValue;
        float floatValue;
        string strValue;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    txtServerIP.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            tcpClient = tcpListener.AcceptTcpClient();
            if (tcpClient.Connected)
            {
                txtClientIP.Text = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
            }
            ns = tcpClient.GetStream();
            bw = new BinaryWriter(ns);
            br = new BinaryReader(ns);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (tcpClient.Connected)
                    {
                        if (DataReceived() == -1)
                            break;
                        DataSend();
                    }
                    else
                    {
                        AllClose();
                        break;
                    }
                }
                AllClose();
            });
        }
        private int DataReceived()
        {
            try
            {
                intValue = br.ReadInt32();
                if (intValue == -1)
                    return -1;
                floatValue = br.ReadSingle();
                strValue = br.ReadString();
                string str = intValue + "/" + floatValue + "/" + strValue;
                this.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(str);
                });
                return 0;
            }
            catch
            { 
                return -1;
            }
        }
        private void DataSend()
        {
            bw.Write(intValue);
            bw.Write(floatValue);
            bw.Write(strValue);
            bw.Flush();
            this.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show("Data Send.");
            });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            tcpListener.Stop();
        }
        private void AllClose()
        {
            if (bw != null) bw.Close();
            if (br != null) br.Close();
            if (ns != null) ns.Close();
            if (tcpClient != null) tcpClient.Close();
        }
    }
}
