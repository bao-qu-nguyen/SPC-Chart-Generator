using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace SPC_Chart_Generator
{
    public class PlotSPC
    {
        private Chart SPCPlot;
        private ChartArea chartArea;
        private Dictionary<string, float> ColumnStatistic;
        private List<float> XData;
        private List<float> YData;
        private List<int> ColorData;

        public PlotSPC(Chart plot, Dictionary<string,float> statistics, List<float>Xdata, List<float>Ydata,List<int>Colordata)
        {
            SPCPlot = plot;
            chartArea = SPCPlot.ChartAreas[0];
            ColumnStatistic = statistics;
            XData = Xdata;
            YData = Ydata;
            ColorData = Colordata;
            Clear();
            Draw("col1");
        }
        public void Clear()
        {
            SPCPlot.Series.Clear();
            SPCPlot.Legends.Clear();
            chartArea.AxisY.StripLines.Clear();
        }

        public void Draw(string SeriesName)
        {
            Series dataSeries = new Series(SeriesName);
            dataSeries.ChartType = SeriesChartType.Point;
            SPCPlot.Series.Add(dataSeries);
            chartArea.AxisX.Minimum = 0;

            for (int i = 0; i < XData.Count; i++)
            {
                SPCPlot.Series[SeriesName].Points.AddXY(XData[i], YData[i]);
                switch (ColorData[i])
                {
                    case 0:
                        SPCPlot.Series[SeriesName].Points[i].Color = Color.Green;
                        break;
                    case 1:
                        SPCPlot.Series[SeriesName].Points[i].Color = Color.Red;
                        break;
                    case 2:
                        SPCPlot.Series[SeriesName].Points[i].Color = Color.Orange;
                        break;
                    case 3:
                        SPCPlot.Series[SeriesName].Points[i].Color = Color.FromArgb(255, 204, 204, 0);
                        break;
                }
            }

            foreach (var point in SPCPlot.Series[SeriesName].Points)
            {
                point.MarkerSize = 10;
                point.MarkerStyle = MarkerStyle.Circle;
                point.ToolTip = $"X: {point.XValue}, Y: {point.YValues[0]}";
            }
            /* 
             * Connect the points
             */
            Series dataSeriesLine = new Series("Data Pointz")
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Black
            };

            for (int i = 0; i < YData.Count; i++)
            {
                dataSeriesLine.Points.AddXY(i, YData[i]);
            }
            SPCPlot.Series.Add(dataSeriesLine);

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.MinorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.MinorGrid.Enabled = false;

            chartArea.RecalculateAxesScale();
            float xStart = 0;
            float xEnd = (float)chartArea.AxisX.Maximum;
            float yMax = (float)chartArea.AxisY.Maximum;
            float yMin = (float)chartArea.AxisY.Minimum;

            float mean = ColumnStatistic["Mean"];
            float std = ColumnStatistic["STD"];
            float zone1_lower = mean - std;
            float zone1_upper = mean + std;
            float zone2_lower = mean - 2 * std;
            float zone2_upper = mean + 2 * std;
            float zone3_lower = mean - 3 * std;
            float zone3_upper = mean + 3 * std;

            AddLine("Mean", Color.DarkGreen, mean, xStart, xEnd);
            AddLine("Zone 3 Upper", Color.Red, zone3_upper, xStart, xEnd);
            AddLine("Zone 3 Lower", Color.Red, zone3_lower, xStart, xEnd);
            AddLine("Zone 2 Upper", Color.Orange, zone2_upper, xStart, xEnd);
            AddLine("Zone 2 Lower", Color.Orange, zone2_lower, xStart, xEnd);
            AddLine("Zone 1 Upper", Color.LightYellow, zone1_upper, xStart, xEnd);
            AddLine("Zone 1 Lower", Color.LightYellow, zone1_lower, xStart, xEnd);

            AddRegion(zone1_lower, zone1_upper, Color.LightGreen);
            AddRegion(zone1_upper, zone2_upper, Color.Yellow);
            AddRegion(zone2_lower, zone1_lower, Color.Yellow);
            AddRegion(zone2_upper, zone3_upper, Color.Orange);
            AddRegion(zone3_lower, zone2_lower, Color.Orange);

        }

        private void AddLine(string name, Color color, float yValue, float xStart, float xEnd)
        {
            Series line = new Series(name)
            {
                ChartType = SeriesChartType.Line,
                Color = color
            };
            line.Points.AddXY(xStart, yValue);
            line.Points.AddXY(xEnd, yValue);
            line.Name = name;
            SPCPlot.Series.Add(line);
        }

        private void AddRegion(float lower, float upper, Color color)
        {
            StripLine region = new StripLine
            {
                IntervalOffset = lower,
                StripWidth = Math.Abs(upper - lower),
                BackColor = Color.FromArgb(50, color)
            };
            chartArea.AxisY.StripLines.Add(region);
        }
    }

}
