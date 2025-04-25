using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SPC_Chart_Generator
{
    public class DataPreparation
    {
        string FilePath;
        public List<List<string>> UserData;
        private List<List<string>> UserDataUnModified ;
        public List<List<string>> NumericDataSummary;
        public List<List<string>> NonNumericDataSummary;
        public List<string> ColumnHeader;
        public List<string> NumericalColumnHeader;

        public List<List<string>> GetData(string path)
        {
            UserData = new List<List<string>>();
            using (StreamReader sr = File.OpenText(path))
            {
                FilePath = path;
                List<string> TempList = new List<string>();
                string s;
                char[] delimiters = new char[] { ',', ';' };
                while ((s = sr.ReadLine()) != null)
                {
                    UserData.Add(s.Split(delimiters)
                        .Select(s => s.Trim())
                        .ToList()
                        );
                }
            }

            UserDataUnModified = UserData.Select(row => new List<string>(row)).ToList(); ;
            DataSummary();
            ColumnHeader = new List<string>(UserData[0]);
            return UserData;
        }
        public void SortData(string ByColumn = "")
        {
            //Default will sort by the first column
            var header = UserData[0];
            
            int columnIndex = header.IndexOf(ByColumn);
            if (columnIndex < 0) { 
                columnIndex  = 0;
            }
            var sortedData = UserData.Skip(1)
                            .OrderBy(row => row[0])
                            .ToList();
            UserData = new List<List<string>> { header };
            UserData.AddRange(sortedData);
        }

        public void PlotData(Chart DataChart, string ColumnSelection)
        {
            Series series = new Series(ColumnSelection);
            DataChart.Series.Clear();
            DataChart.ChartAreas.Clear();
            DataChart.Legends.Clear();
            ChartArea chartArea = new ChartArea("MainArea");
            Legend legend = new Legend();
            legend.Enabled = false;
            DataChart.Legends.Add(legend);

            DataChart.ChartAreas.Add(chartArea);

            var header = UserData[0].Skip(1).ToList();
            int ColumnIndex = header.IndexOf(ColumnSelection) + 1;

            if (ColumnIndex < 0)
            {
                Debug.WriteLine($"Column '{ColumnSelection}' not found.");
                return;
            }

            var ColumnData = UserData
                .Skip(1)
                .Where(row => row.Count > ColumnIndex)
                .Select(row => row[ColumnIndex])
                .Where(val => !string.IsNullOrWhiteSpace(val))
                .ToList();

            var ColumnType = DetectColumnDataType(ColumnData);

            if (ColumnType == typeof(float) || ColumnType == typeof(double) || ColumnType == typeof(int))
            {
                var numericData = ColumnData.Select(float.Parse).ToList();
                series.ChartType = SeriesChartType.Line;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 6;

                for (int i = 0; i < numericData.Count; i++)
                {
                    series.Points.AddXY(i, numericData[i]);
                }

                DataChart.ChartAreas[0].AxisX.Title = "Index";
                DataChart.ChartAreas[0].AxisY.Title = ColumnSelection;
                
            }
            else
            {
                var CategoryCounts = ColumnData
                        .Where(c => !string.IsNullOrWhiteSpace(c))
                        .GroupBy(c => c)
                        .ToDictionary(g => g.Key, g => g.Count());
                
                series.ChartType = SeriesChartType.Column;
                series["PointWidth"] = "0.5";
                series.XValueType = ChartValueType.String;
                int i = 1;
                foreach (var key in CategoryCounts)
                {
                    Debug.WriteLine(key.Key);
                    Debug.WriteLine(key.Value);
                    series.Points.AddXY(i, key.Value);
                    i++;
                }
                DataChart.ChartAreas[0].AxisX.Interval = 1; 
                DataChart.ChartAreas[0].AxisX.IsLabelAutoFit = true;
                DataChart.ChartAreas[0].AxisX.LabelStyle.Angle = 45; 
                DataChart.ChartAreas[0].AxisX.Title = "Category";
                DataChart.ChartAreas[0].AxisY.Title = "Count";
            }

            DataChart.Series.Add(series);
        }

        public void DataSummary()
        {
            var header = UserData[0];
            NumericDataSummary = new List<List<string>>();
            NumericDataSummary.Clear();
            NumericDataSummary.Add(new List<string> { "ColumnName", "NullCount", "Mean", "Max", "Min", "STD", "Q1", "Q2", "Q3" });
            NonNumericDataSummary = new List<List<string>>();
            NonNumericDataSummary.Clear();
            NonNumericDataSummary.Add(new List<string> { "ColumnName", "NullCount", "TotalCount", "UniqueCount"});
            NumericalColumnHeader = new List<string>();
            foreach (var column in header)
            {
                int ColumnIndex = header.IndexOf(column);
                int NullCount;
                var ColumnData = UserData.Skip(1).Where(row => row.Count > ColumnIndex).Select(row => row[ColumnIndex]).ToList();
                foreach (var row in ColumnData)
                {
                    string line = string.Join(", ", row);
                    Debug.WriteLine(line);
                }
                var ColumnType = DetectColumnDataType(ColumnData);
                if (ColumnType == typeof(float) || ColumnType == typeof(double) || ColumnType == typeof(int))
                { 
                    NullCount = ColumnData.Count(row => string.IsNullOrEmpty(row));
                    ColumnData = ColumnData.Where(value => !string.IsNullOrEmpty(value)).ToList();

                    List<float> ColumnDataConverted = ColumnData.ConvertAll(float.Parse);
                    float Mean = ColumnDataConverted.Average();
                    float Max = ColumnDataConverted.Max();
                    float Min = ColumnDataConverted.Min();
                    float StandardDeviation = (float)Math.Sqrt(ColumnDataConverted.Average(v => Math.Pow(v - Mean, 2)));
                    var (Q1, Q2, Q3) = CalculateQuartiles(ColumnDataConverted);
                    NumericDataSummary.Add(new List<string> {
                                                        column,
                                                        NullCount.ToString("F0"),
                                                        Mean.ToString("F2"),
                                                        Max.ToString("F2"),
                                                        Min.ToString("F2"),
                                                        StandardDeviation.ToString("F2"),
                                                        Q1.ToString("F2"),
                                                        Q2.ToString("F2"),
                                                        Q3.ToString("F2")
                                                    });
                    NumericalColumnHeader.Add(column);
                }
                if (ColumnType == typeof(string) || ColumnType == typeof(DateTime?))
                {

                    NullCount = ColumnData.Count(row => string.IsNullOrEmpty(row));
                    float TotalCount = ColumnData.Count - NullCount;
                    float UniqueCount = ColumnData.Distinct().Count();
                    NonNumericDataSummary.Add(new List<string> {column,NullCount.ToString("F0"),
                    TotalCount.ToString("F0"),UniqueCount.ToString("F0") });
                }
            }
                                              
        }
        public void RemoveNullData()
        {
            UserData = UserDataUnModified.Select(row => new List<string>(row)).ToList();
            UserData = UserData.Where(row => row.All(cell => !string.IsNullOrWhiteSpace(cell)))
                                .ToList();
            DataSummary();
        }
        public void RevertData()
        {
            UserData = UserDataUnModified.Select(row => new List<string>(row)).ToList();
            DataSummary();
            int userDataNullCount = CountNulls(UserData);
            int userDataUnmodifiedNullCount = CountNulls(UserDataUnModified);
        }
        int CountNulls(List<List<string>> data)
        {
            return data.Skip(1)  // skip header
                       .SelectMany(row => row)
                       .Count(cell => string.IsNullOrWhiteSpace(cell));
        }
        public void FillNullData(string FillColumnWith)
        {
            UserData = UserDataUnModified.Select(row => new List<string>(row)).ToList();
            var header = UserData[0];
            
            switch (FillColumnWith)
            {
                case "Mean":
                    for (int col = 0; col < header.Count; col++)
                    {
                        var ColumnData = UserData.Skip(1)
                            .Where(row => row.Count > col)
                            .Select(row => row[col])
                            .ToList();

                        var ColumnType = DetectColumnDataType(ColumnData);

                        if (ColumnType == typeof(float) || ColumnType == typeof(double) || ColumnType == typeof(int))
                        {
                            var validData = ColumnData
                                .Where(val => !string.IsNullOrWhiteSpace(val))
                                .Select(float.Parse)
                                .ToList();

                            if (validData.Count == 0) continue;

                            float mean = validData.Average();

                            foreach (var row in UserData.Skip(1))
                            {
                                if (row.Count > col && string.IsNullOrWhiteSpace(row[col]))
                                {
                                    row[col] = mean.ToString("F2");
                                }
                            }
                        }
                        else
                        {
                            var nonEmpty = ColumnData
                                .Where(val => !string.IsNullOrWhiteSpace(val));

                            if (!nonEmpty.Any()) continue;

                            var mode = nonEmpty
                                .GroupBy(val => val)
                                .OrderByDescending(g => g.Count())
                                .First()
                                .Key;

                            foreach (var row in UserData.Skip(1))
                            {
                                if (row.Count > col && string.IsNullOrWhiteSpace(row[col]))
                                {
                                    row[col] = mode;
                                }
                            }
                        }
                    }
                    break;
                case "Min":
                    for (int col = 0; col < header.Count; col++)
                    {
                        var ColumnData = UserData.Skip(1)
                            .Where(row => row.Count > col)
                            .Select(row => row[col])
                            .ToList();

                        var ColumnType = DetectColumnDataType(ColumnData);

                        if (ColumnType == typeof(float) || ColumnType == typeof(double) || ColumnType == typeof(int))
                        {
                            var validData = ColumnData
                                .Where(val => !string.IsNullOrWhiteSpace(val))
                                .Select(float.Parse)
                                .ToList();

                            if (validData.Count == 0) continue;

                            float min = validData.Min();

                            foreach (var row in UserData.Skip(1))
                            {
                                if (row.Count > col && string.IsNullOrWhiteSpace(row[col]))
                                {
                                    row[col] = min.ToString("F2");
                                }
                            }
                        }
                        else
                        {
                            var nonEmpty = ColumnData
                                .Where(val => !string.IsNullOrWhiteSpace(val));

                            if (!nonEmpty.Any()) continue;

                            var leastFrequent = nonEmpty
                                .GroupBy(val => val)
                                .OrderBy(g => g.Count())  
                                .ThenBy(g => g.Key)       
                                .First()
                                .Key;

                            foreach (var row in UserData.Skip(1))
                            {
                                if (row.Count > col && string.IsNullOrWhiteSpace(row[col]))
                                {
                                    row[col] = leastFrequent;
                                }
                            }
                        }
                    }

                    break;
                case "Max":
                    for (int col = 0; col < header.Count; col++)
                    {
                        var ColumnData = UserData.Skip(1)
                            .Where(row => row.Count > col)
                            .Select(row => row[col])
                            .ToList();

                        var ColumnType = DetectColumnDataType(ColumnData);

                        if (ColumnType == typeof(float) || ColumnType == typeof(double) || ColumnType == typeof(int))
                        {
                            var validData = ColumnData
                                .Where(val => !string.IsNullOrWhiteSpace(val))
                                .Select(float.Parse)
                                .ToList();

                            if (validData.Count == 0) continue;

                            float max = validData.Max();

                            foreach (var row in UserData.Skip(1))
                            {
                                if (row.Count > col && string.IsNullOrWhiteSpace(row[col]))
                                {
                                    row[col] = max.ToString("F2");
                                }
                            }
                        }
                        else
                        {
                            var nonEmpty = ColumnData
                                .Where(val => !string.IsNullOrWhiteSpace(val));

                            if (!nonEmpty.Any()) continue;

                            var mode = nonEmpty
                                .GroupBy(val => val)
                                .OrderByDescending(g => g.Count())
                                .First()
                                .Key;

                            foreach (var row in UserData.Skip(1))
                            {
                                if (row.Count > col && string.IsNullOrWhiteSpace(row[col]))
                                {
                                    row[col] = mode;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            DataSummary();
        }
        public static Type DetectColumnDataType(List<string> column, double threshold = 0.8)
        {
            //Check the whole column. 
            int total = 0, datetimeCount = 0, intCount = 0, floatCount = 0;

            foreach (var value in column)
            {
                var trimmed = value.Trim();

                if (string.IsNullOrWhiteSpace(trimmed))
                    continue;

                total++;

                if (DateTime.TryParse(trimmed, out _)) datetimeCount++;
                if (int.TryParse(trimmed, out _)) intCount++;
                if (float.TryParse(trimmed, out _)) floatCount++;
            }

            if (total == 0) return typeof(string); // fallback for empty column

            double datetimeRatio = (double)datetimeCount / total;
            double intRatio = (double)intCount / total;
            double floatRatio = (double)floatCount / total;

            if (datetimeRatio >= threshold) return typeof(DateTime);
            if (intRatio >= threshold) return typeof(int);
            if (floatRatio >= threshold) return typeof(float);

            return typeof(string);
        }
        public static (float Q1, float Q2, float Q3) CalculateQuartiles(List<float> data)
        {
            data.Sort();
            int Q1Index = (int)Math.Ceiling(25 / 100.0 * data.Count) - 1;
            int Q2Index = (int)Math.Ceiling(50 / 100.0 * data.Count) - 1;
            int Q3Index = (int)Math.Ceiling(75 / 100.0 * data.Count) - 1;
            float Q1 = data[Q1Index];
            float Q2 = data[Q2Index];
            float Q3 = data[Q3Index];

            return (Q1, Q2, Q3);
        }

    }
}
