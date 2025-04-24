using System.Xml.Linq;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Drawing;

using System.IO;
namespace SPC_Chart_Generator
{
    public partial class SPCChart : Form
    {
        public List<List<string>> UserData { get; set; }
        DataPreparation data;
        public SPCChart()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            //var UserData = new DataPreparation(@"C:\Users\darkm\OneDrive\Desktop\test_data\random_data.csv");
            data = new DataPreparation();
            UserData = data.GetData(@"C:\Users\darkm\OneDrive\Desktop\test_data\random_data.csv");
            var ColumnHeader = data.ColumnHeader.Skip(1);
            DataPrepColSelection.Items.Clear();
            DataPrepColSelection.Items.AddRange(ColumnHeader.ToArray());
            
            var Table = new MakeTable(DataTable, data.UserData);
            var NumericalData = data.NumericDataSummary;
            var NumericStatTabl = new MakeTable(NumericStatTable, NumericalData);
            var NonNumericalData = data.NonNumericDataSummary;
            var NonNumericStatTabl = new MakeTable(NonNumericStatTable, NonNumericalData);
            data.SortData();
            Table.UpdateTable(data.UserData);

            //List<string> header = new List<string> { "id", "col1", "col2", "col3", "col4", "col5" };
            //var spc = new MakeSPC();
            //UserData = GenerateUserData();
            //var result = spc.InitializeSPC(header, UserData); //Return  Key: Column Name, Value: list of value and list of color
            //var ColumnStatistic  = spc.GetStatistics();
            //var Statistics = ColumnStatistic["col2"];
            //var XData = result["id"].Item1;
            //var YData = result["col2"].Item1;
            //var ColorData = result["col2"].Item2;
            //var chart = new PlotSPC(SPCPlot, Statistics, XData,YData,ColorData);
            #region PLOT
            //string SeriesName = "col1";
            //ChartArea chartArea = SPCPlot.ChartAreas[0];
            //SPCPlot.Series["Series1"].ChartType = SeriesChartType.Point;
            //SPCPlot.Series["Series1"].Name = SeriesName;
            //chartArea.AxisX.Minimum = 0;

            //for (int i = 0; i < result["id"].Item1.Count; i++) 
            //{
            //    SPCPlot.Series[SeriesName].Points.AddXY(Convert.ToSingle(result["id"].Item1[i]), result[SeriesName].Item1[i]);
            //    if (result[SeriesName].Item2[i] == 0)
            //    {
            //        SPCPlot.Series[SeriesName].Points[i].Color = Color.Green;
            //    }
            //    if (result[SeriesName].Item2[i] == 1)                                        
            //    {
            //        SPCPlot.Series[SeriesName].Points[i].Color = Color.Red;
            //    }
            //    if (result[SeriesName].Item2[i] == 2)
            //    {
            //        SPCPlot.Series[SeriesName].Points[i].Color = Color.Orange;
            //    }
            //    if (result[SeriesName].Item2[i] == 3)
            //    {
            //        SPCPlot.Series[SeriesName].Points[i].Color = Color.Yellow;
            //    }
            //}

            //foreach (var point in SPCPlot.Series[SeriesName].Points)
            //{
            //    point.ToolTip = $"X: {point.XValue}, Y: {point.YValues[0]}";
            //}
            //Series dataSeries = new Series("Data Points");

            ///*
            // * Line to connect the points
            // */
            //dataSeries.ChartType = SeriesChartType.Line;  
            //dataSeries.Color = Color.Black;  
            //for (int i = 0; i < UserData.Count - 1; i++)
            //{
            //    dataSeries.Points.AddXY(i, UserData[i][1]);  // Replace with appropriate X and Y
            //}
            //SPCPlot.Series.Add(dataSeries);
            ///*
            // * Remove grid lines
            // */

            //chartArea.AxisX.MajorGrid.Enabled = false;
            //chartArea.AxisX.MinorGrid.Enabled = false;
            //chartArea.AxisY.MajorGrid.Enabled = false;
            //chartArea.AxisY.MinorGrid.Enabled = false;

            ///*
            // * Add Statistic Lines
            // */
            //float mean, std, zone1_lower, zone1_upper, zone2_lower, zone2_upper, zone3_lower, zone3_upper;
            //chartArea.RecalculateAxesScale();
            //float xStart = 0;
            //float xEnd = (float)chartArea.AxisX.Maximum;
            //if (ColumnStatistic.TryGetValue(SeriesName, out Dictionary<string, float> StatDictionary))
            //{
            //     mean = StatDictionary["Mean"];
            //     std = StatDictionary["STD"];
            //     zone1_lower = mean - 1 * std;
            //     zone1_upper = mean + std;
            //     zone2_lower = mean + -2 * std;
            //     zone2_upper = mean + 2 * std;
            //     zone3_lower = mean + -3 * std;
            //     zone3_upper = mean + 3 * std;

            //    //Draw Mean Line
            //    Series MeanLine = new Series("Mean");
            //    MeanLine.ChartType = SeriesChartType.Line;
            //    MeanLine.Color = Color.DarkGreen;
            //    float yMean = mean;
            //    MeanLine.Points.AddXY(xStart, yMean);
            //    MeanLine.Points.AddXY(xEnd, yMean);
            //    SPCPlot.Series.Add(MeanLine);

            //    //Draw Zone 3 Lines
            //    Series Zone3LineUpper = new Series("Zone 3 Upper");
            //    Zone3LineUpper.ChartType = SeriesChartType.Line;
            //    Zone3LineUpper.Color = Color.Red;
            //    float yUpperZone3 = zone3_upper;

            //    Zone3LineUpper.Points.AddXY(xStart, yUpperZone3);
            //    Zone3LineUpper.Points.AddXY(xEnd, yUpperZone3);
            //    SPCPlot.Series.Add(Zone3LineUpper);
            //    Series Zone3LineLower = new Series("Zone 3 Lower");
            //    Zone3LineLower.ChartType = SeriesChartType.Line;
            //    Zone3LineLower.Color = Color.Red;
            //    float yLowerZone3 = zone3_lower;
            //    Zone3LineLower.Points.AddXY(xStart, yLowerZone3);
            //    Zone3LineLower.Points.AddXY(xEnd, yLowerZone3);
            //    SPCPlot.Series.Add(Zone3LineLower);

            //    //Draw Zone2 Lines
            //    Series Zone2LineUpper = new Series("Zone 2 Upper");
            //    Zone2LineUpper.ChartType = SeriesChartType.Line;
            //    Zone2LineUpper.Color = Color.Orange;
            //    float yUpperZone2 = zone2_upper;

            //    Zone2LineUpper.Points.AddXY(xStart, yUpperZone2);
            //    Zone2LineUpper.Points.AddXY(xEnd, yUpperZone2);
            //    SPCPlot.Series.Add(Zone2LineUpper);

            //    Series Zone2LineLower = new Series("Zone 2 Lower");
            //    Zone2LineLower.ChartType = SeriesChartType.Line;
            //    Zone2LineLower.Color = Color.Orange;
            //    float yLowerZone2 = zone2_lower;

            //    Zone2LineLower.Points.AddXY(xStart, yLowerZone2);
            //    Zone2LineLower.Points.AddXY(xEnd, yLowerZone2);
            //    SPCPlot.Series.Add(Zone2LineLower);

            //    // Draw Zone 1 Lines
            //    Series Zone1LineUpper = new Series("Zone 1 Upper");
            //    Zone1LineUpper.ChartType = SeriesChartType.Line;
            //    Zone1LineUpper.Color = Color.Yellow;
            //    float yUpperZone1 = zone1_upper;

            //    Zone1LineUpper.Points.AddXY(xStart, yUpperZone1);
            //    Zone1LineUpper.Points.AddXY(xEnd, yUpperZone1);
            //    SPCPlot.Series.Add(Zone1LineUpper);

            //    Series Zone1LineLower = new Series("Zone 1 Lower");
            //    Zone1LineLower.ChartType = SeriesChartType.Line;
            //    Zone1LineLower.Color = Color.Yellow;
            //    float yLowerZone1 = zone1_lower;

            //    Zone1LineLower.Points.AddXY(xStart, yLowerZone1);
            //    Zone1LineLower.Points.AddXY(xEnd, yLowerZone1);
            //    SPCPlot.Series.Add(Zone1LineLower);
            //     /*
            //     * Add shaded regions
            //     */
            //    StripLine Region_1 = new StripLine();
            //    Region_1.IntervalOffset = zone1_lower;
            //    Region_1.StripWidth = zone1_upper - zone1_lower;
            //    Region_1.BackColor = Color.FromArgb(50, Color.LightGreen);
            //    chartArea.AxisY.StripLines.Add(Region_1);

            //    StripLine Region_2_Upper = new StripLine();
            //    Region_2_Upper.IntervalOffset = zone1_upper;
            //    Region_2_Upper.StripWidth = zone2_upper - zone1_upper;
            //    Region_2_Upper.BackColor = Color.FromArgb(50, Color.Yellow);
            //    chartArea.AxisY.StripLines.Add(Region_2_Upper);

            //    StripLine Region_2_Lower = new StripLine();
            //    Region_2_Lower.IntervalOffset = zone2_lower;
            //    Region_2_Lower.StripWidth = Math.Abs(zone2_lower - zone1_lower);
            //    Region_2_Lower.BackColor = Color.FromArgb(50, Color.Yellow);
            //    chartArea.AxisY.StripLines.Add(Region_2_Lower);

            //    StripLine Region_3_Upper = new StripLine();
            //    Region_3_Upper.IntervalOffset = zone2_upper;
            //    Region_3_Upper.StripWidth = zone3_upper - zone2_upper;
            //    Region_3_Upper.BackColor = Color.FromArgb(50, Color.Orange);
            //    chartArea.AxisY.StripLines.Add(Region_3_Upper);

            //    StripLine Region_3_Lower = new StripLine();
            //    Region_3_Lower.IntervalOffset = zone3_lower;
            //    Region_3_Lower.StripWidth = Math.Abs(zone3_lower - zone2_lower);
            //    Region_3_Lower.BackColor = Color.FromArgb(50, Color.Orange);
            //    chartArea.AxisY.StripLines.Add(Region_3_Lower);

            //}
            #endregion
        }

        public static List<List<float>> GenerateUserData(int rowCount = 30, int columnCount = 5)
        {
            var rand = new Random(42);
            var userData = new List<List<float>>();

            for (int i = 0; i < rowCount; i++)
            {
                var row = new List<float> { i }; // First column as index

                for (int j = 0; j < columnCount; j++)
                {
                    row.Add((float)(rand.NextDouble() * 9.0 + 1.0)); // Random between 1 and 10
                }

                userData.Add(row);
            }

            // Add 2–3 values > 10 for each column (excluding index column)
            for (int col = 1; col <= columnCount; col++)
            {
                int numHigh = rand.Next(2, 4); // 2 to 3
                var indices = new HashSet<int>();

                while (indices.Count < numHigh)
                {
                    indices.Add(rand.Next(0, rowCount));
                }

                foreach (int rowIndex in indices)
                {
                    userData[rowIndex][col] = (float)(rand.NextDouble() * 5.0 + 10.0); // Random between 10 and 15
                }
            }

            return userData;
        }

        private void DataPrepColSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataPrepColSelection.SelectedIndex != -1)
            {
                string selectedValue = DataPrepColSelection.SelectedItem.ToString();
                Debug.WriteLine(selectedValue);
                data.PlotData(DataPrepChart, selectedValue);
            }
        }
    }
}
