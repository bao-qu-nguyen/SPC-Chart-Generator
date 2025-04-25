using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.Analysis;

namespace SPC_Chart_Generator
{
    public class MakeSPC
    {
        private List<List<float>>? UserData { get; set; }
        private List<string>? ColumnNames { get; set; }
        public Dictionary<string,Dictionary<string,float>>? StatsData;
        private Dictionary<string, Tuple<List<float>, List<int>>> ReturnDictionary = new Dictionary<string, Tuple<List<float>, List<int>>>();
        public Dictionary<string, Tuple<List<float>, List<int>>> InitializeSPC(List<string>HeaderData,List<List<float>> InputData) 
        { 
            /*
             * Return structure will be a dictionary Key: Column Name, Value: list of value and list of color
             */
            UserData = InputData;
            ColumnNames = HeaderData;
            GetColumnStatistic();
            for (int i = 0; i < ColumnNames.Count; i++)
            {
                var column = ColumnNames[i];
                List<float> SingleColumnData = new List<float>();
                for (int j = 0; j < UserData.Count -1; j++)
                {
                    SingleColumnData.Add(UserData[j][i]);
                    
                }
                var ColorList = GetSPCColors(StatsData[ColumnNames[i]], SingleColumnData);
                ReturnDictionary[ColumnNames[i]] = new Tuple<List<float>, List<int>>(SingleColumnData,ColorList);
            }

            return ReturnDictionary;
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
            return 0;
        }
        public Dictionary<string, Dictionary<string, float>> GetStatistics()
        {
            if(StatsData == null ||  StatsData.Count == 0)
            {
                return null;
            }
            return StatsData;
        }
        private List<int>?GetSPCColors(Dictionary<string,float> ColumnStat, List<float> ColumnData)
        {
            float mean = ColumnStat["Mean"];
            float std = ColumnStat["STD"];
            float zone1_lower = mean -1 * std;
            float zone1_upper = mean + std;
            float zone2_lower = mean + -2 * std;
            float zone2_upper = mean + 2 *std;
            float zone3_lower = mean + -3 * std;
            float zone3_upper = mean + 3 *std;
            float LCL = zone3_lower;
            float UCL = zone3_upper;
            List<int> ColorList = new List<int>();
            for (int i = 0; i < ColumnData.Count; i++)
            {
                int count = 0;
                ////Rule 1: 
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
                    if (count >= 2)
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
                ////Rule 3:
                count = 0;
                if (i < ColumnData.Count - 4)
                {
                    if (ColumnData[i] < zone1_lower || ColumnData[i] > zone1_upper) count++;
                    if (ColumnData[i + 1] < zone1_lower || ColumnData[i + 1] > zone1_upper) count++;
                    if (ColumnData[i + 2] < zone1_lower || ColumnData[i + 2] > zone1_upper) count++;
                    if (ColumnData[i + 3] < zone1_lower || ColumnData[i + 3] > zone1_upper) count++;
                    if (ColumnData[i + 4] < zone1_lower || ColumnData[i + 4] > zone1_upper) count++;
                    if (count >= 4)
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
                ////Rule 4:
                count = 0;
                if (i < ColumnData.Count - 7)
                {
                    List<float> TempList = new List<float>();
                    for (int k = 0; k <= 7; k++)
                    {
                        TempList.Add(ColumnData[k]);
                    }
                    bool AllGreater = TempList.All(p => p > mean);
                    bool AllLesser = TempList.All(p => p < mean);
                    if (AllGreater || AllLesser)
                    {
                        for (int k = 0; k < ColumnData.Count - 7; k++)
                        {
                            ColorList.Add(0);
                        }
                        ColorList.Add(4);
                        i += 7;
                        continue;
                    }
                }
                //Add 1 entry if no rule broken
                ColorList.Add(0);
            }

            return ColorList;

        }
    };

}
