using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SPC_Chart_Generator
{
    public class DataPreparation
    {
        string FilePath;
        public List<List<string>> UserData = new List<List<string>>();
        //public Dictionary<string, Dictionary<string, float>> NumericDataSummary = new Dictionary<string, Dictionary<string, float>> ();
        public List<List<string>> NumericDataSummary;
        public List<List<string>> NonNumericDataSummary;
        //public Dictionary<string, Dictionary<string, float>> NonNumericDataSummary = new Dictionary<string, Dictionary<string, float>>();
        public DataPreparation(string path) {

            FilePath = path;
            GetData(path);

        }

        public List<List<string>> GetData(string path)
        {
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
            DataSummary();
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

        public void DataSummary()
        {
            var header = UserData[0];
            NumericDataSummary = new List<List<string>>();
            NumericDataSummary.Clear();
            NumericDataSummary.Add(new List<string> { "ColumnName", "NullCount", "Mean", "Max", "Min", "STD", "Q1", "Q2", "Q3" });
            NonNumericDataSummary = new List<List<string>>();
            NonNumericDataSummary.Clear();
            NonNumericDataSummary.Add(new List<string> { "ColumnName", "NullCount", "TotalCount", "UniqueCount"});
            foreach (var column in header)
            {
                int ColumnIndex = header.IndexOf(column);
                int NullCount;
                var ColumnData = UserData.Skip(1).Where(row => row.Count > ColumnIndex).Select(row => row[ColumnIndex]).ToList();
                var ColumnType = DetectColumnDataType(ColumnData);
                if (ColumnType == typeof(float) || ColumnType == typeof(double) || ColumnType == typeof(int))
                { 
                    NullCount = ColumnData.Count(row => row == null);
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

                    
                    foreach(var row in NumericDataSummary)
                    {
                        Debug.WriteLine(string.Join("|", row));
                    }

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

        }
        public void FillNullData()
        {

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
