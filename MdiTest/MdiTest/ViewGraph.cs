using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MdiTest
{
    public partial class ViewGraph : Form
    {
        public ViewGraph()
        {
            InitializeComponent();
            chart1.Series.Clear();

            Series tempSeries = new Series("온도");
            tempSeries.ChartType = SeriesChartType.Line;
            tempSeries.Color = Color.Red;
            tempSeries.MarkerStyle = MarkerStyle.Circle;  // 도형: 원
            tempSeries.MarkerSize = 8;                    // 크기
            tempSeries.MarkerColor = Color.Red;           // 마커 색상
            //tempSeries.ChartArea = "MainArea";

            chart1.Series.Add(tempSeries);
            Series humidSeries = new Series("습도");
            humidSeries.ChartType = SeriesChartType.Line;
            humidSeries.Color = Color.Blue;
            humidSeries.MarkerStyle = MarkerStyle.Diamond;  // 도형: 다이아몬드
            humidSeries.MarkerSize = 8;                     // 크기
            humidSeries.MarkerColor = Color.Blue;           // 마커 색상
            //humidSeries.ChartArea = "MainArea";
            chart1.Series.Add(humidSeries);
        }
        private int timeIndex = 0;
        public void AddDataPoint(float temp, float humi)
        {
            // Chart에 데이터 추가
            chart1.Series["온도"].Points.AddY(temp);
            chart1.Series["습도"].Points.AddY(humi);
            // 포인트 수 제한 (최근 50개)
            if (chart1.Series["온도"].Points.Count > 50)
            {
                chart1.Series["온도"].Points.RemoveAt(0);
                chart1.Series["습도"].Points.RemoveAt(0);
            }

        }
    }
}
