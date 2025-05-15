using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MdiTest
{
    public partial class ViewData : Form
    {
        public ViewData()
        {
            InitializeComponent();

        }
        public void UpdateValues(float temp, float humi)
        {
            txtTemp.Text = temp.ToString("F1");
            txtHumi.Text = humi.ToString("F1");
        }
    }
}
