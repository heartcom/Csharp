using System.Linq.Expressions;
using System.Net.Sockets;

namespace ClientProgram
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient = null;
        NetworkStream ns;
        BinaryReader br;
        BinaryWriter bw;
        int intValue;
        float floatValue;
        string stringValue;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient(txtServerIP.Text, 5000);
            if (tcpClient.Connected)
            {
                ns = tcpClient.GetStream();
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);
                MessageBox.Show("���� ���� ����");
            }
            else
                MessageBox.Show("���� ���� ����");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                bw.Write(int.Parse(txtInt.Text));
                bw.Write(float.Parse(txtFloat.Text));
                bw.Write(txtString.Text);

                intValue = br.ReadInt32();
                floatValue = br.ReadSingle();
                stringValue = br.ReadString();

                String str = intValue + "/" + floatValue + "/" + stringValue;
                MessageBox.Show(str);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(" �Է� ������ �ùٸ��� �ʽ��ϴ�. \n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" ����ġ ���� ���� : \n", ex.Message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bw.Write(-1);
            bw.Close();
            br.Close();
            ns.Close();
            tcpClient.Close();
        }
    }
}
