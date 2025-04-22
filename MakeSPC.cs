using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Analysis;

namespace SPC_Chart_Generator
{
    public class MakeSPC
    {
        private List<List<float>>? UserData { get; set; }
        private List<string>? ColumnNames { get; set; }
        public Dictionary<string,Dictionary<string,float>>? StatsData;
        public int InitializeSPC(List<string>HeaderData,List<List<float>> InputData) { 
            UserData = InputData;
            ColumnNames = HeaderData;
            GetColumnStatistic();
            List<float> column1 = UserData
                    .Where(row => row.Count > 1)
                    .Select(row => row[1])
                    .ToList();
            GetSPCColors(StatsData[ColumnNames[1]], column1);
            return 0;
        }
        private int GetColumnStatistic() {
            float ColumnCount = UserData[0].Count;
            float RowCount = UserData.Count;
            float sum, min, max, mean, std;
            List<string> StatHeaders = new List<string> { "ColumnName", "Mean", "Min", "Max", "Std" };
            StatsData = new Dictionary<string, Dictionary<string, float>>();
            /*
             * Create a stat table as such
             * Column|Mean|STD|Min|Max|
             * Col1   | -- |--|--|--|
             */
            for (int i = 0; i < ColumnCount; i++)
            {
                sum = 0;
                min = UserData[0][i];
                max = UserData[0][i];

                float variance = 0;
                for (int j = 0; j < RowCount; j++) 
                { 
                    sum += UserData[j][i];
                    if (min > UserData[j][i]) { min =  UserData[j][i]; }
                    if (max < UserData[j][i]) { max = UserData[j][i]; }

                }
                mean = sum/ RowCount;
                for (int k = 0; k < RowCount; k++)
                {
                    variance += (float)Math.Pow(UserData[k][i] - mean, 2);
                }
                std = (float)Math.Sqrt(variance / RowCount);
                if (!StatsData.ContainsKey(ColumnNames[i]))
                {
                    StatsData[ColumnNames[i]] = new Dictionary<string, float>();
                    StatsData[ColumnNames[i]]["Mean"] = mean;
                    StatsData[ColumnNames[i]]["STD"] = std;
                    StatsData[ColumnNames[i]]["Max"] = max;
                    StatsData[ColumnNames[i]]["Min"] = min;
                }
            }
            //foreach (var columnEntry in StatsData)
            //{
            //    string columnName = columnEntry.Key;
            //    System.Diagnostics.Debug.WriteLine($"Column: {columnName}");

            //    Dictionary<string, float> stats = columnEntry.Value;
            //    foreach (var stat in stats)
            //    {
            //        System.Diagnostics.Debug.WriteLine($"  {stat.Key}: {stat.Value}");
            //    }

            //    System.Diagnostics.Debug.WriteLine(""); // blank line between columns
            //}
            return 0;
        }

        private List<int>?GetSPCColors(Dictionary<string,float> ColumnStat, List<float> ColumnData)
        {
            float mean = ColumnStat["Mean"];
            float std = ColumnStat["STD"];
            float zone1_lower = -1 * std;
            float zone1_upper =  std;
            float zone2_lower = -2 * std;
            float zone2_upper = 2*std;
            float zone3_lower = -3 * std;
            float zone3_upper = 3*std;
            float LCL = mean+zone3_lower;
            float UCL = mean+zone3_upper;
            List<int> ColorList = new List<int>();
            for (int i = 0; i < ColumnData.Count; i++)
            {
                int count = 0;
                //Rule 1: 
                if (ColumnData[i] < zone3_lower || ColumnData[i] > zone3_upper || ColumnData[i] > UCL || ColumnData[i] < LCL)
                {
                    ColorList.Add(1);
                    continue;
                }
                //Rule 2:
                if (i < ColumnData.Count - 2)
                {
                    if (ColumnData[i] < zone2_lower || ColumnData[i] > zone2_upper) count++;
                    if (ColumnData[i + 1] < zone2_lower || ColumnData[i + 1] > zone2_upper) count++;
                    if (ColumnData[i + 2] < zone2_lower || ColumnData[i + 2] > zone2_upper) count++;
                    if (count <= 2)
                    {
                        if ((ColumnData[i] >= mean && ColumnData[i + 1] >= mean && ColumnData[i + 2] >= mean) ||
                            (ColumnData[i] <= mean && ColumnData[i + 1] <= mean && ColumnData[i + 2] <= mean))
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                ColorList.Add(0);
                            }
                            ColorList.Add(2);
                            i += 2;
                            continue;
                        }
                    }
                }
                ColorList.Add(0);

                ////Rule 3:
                count = 0;
                if (i < ColumnData.Count - 4)
                {
                    if (ColumnData[i] < zone1_lower || ColumnData[i] > zone1_upper) count++;
                    if (ColumnData[i + 1] < zone1_lower || ColumnData[i + 1] > zone1_upper) count++;
                    if (ColumnData[i + 2] < zone1_lower || ColumnData[i + 2] > zone1_upper) count++;
                    if (ColumnData[i + 3] < zone1_lower || ColumnData[i + 3] > zone1_upper) count++;
                    if (ColumnData[i + 4] < zone1_lower || ColumnData[i + 4] > zone1_upper) count++;
                    if (count <= 4)
                    {
                        if ((ColumnData[i] >= mean && ColumnData[i + 1] >= mean && ColumnData[i + 2] >= mean && ColumnData[i + 3] >= mean && ColumnData[i + 4] >= mean) ||
                           (ColumnData[i] <= mean && ColumnData[i + 1] <= mean && ColumnData[i + 2] <= mean && ColumnData[i + 3] <= mean && ColumnData[i + 4] <= mean))
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                ColorList.Add(0);
                            }
                            ColorList.Add(3);
                            i += 4;
                            continue;
                        }
                    }

                }
            }

            for (int i = 0; i < ColumnData.Count; i++)
            {
                PrintItem(ColumnData[i]);
                PrintItem(ColorList[i]);
                PrintItem(zone3_lower);
                PrintItem(zone3_upper);
                PrintItem(LCL);
                PrintItem(UCL);
                PrintItem("---------");
            }
            return null;

        }
        
        private void PrintItem<T>(T PrintValue)
        {
            System.Diagnostics.Debug.WriteLine(PrintValue);
        }
    };

}
