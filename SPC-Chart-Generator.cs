using System.Xml.Linq;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Drawing;

using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection.Emit;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
namespace SPC_Chart_Generator
{
    public partial class SPCChart : Form
    {
        public List<List<string>> UserData { get; set; }
        DataPreparation data;
        MakeTable Table, NumericStatTabl, NonNumericStatTabl;
        MakeSPC SPC;
        LLMInterface ModelChat;
        List<string> SPCHeader;
        string FilePath;
        string FilePathDefault = @"C:\Users\darkm\source\repos\SPC-Chart-Generator\data\random_data.csv";
        string ModelURL = "http://10.0.0.237:1234/v1/chat/completions";
        public SPCChart()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            data = new DataPreparation();
            FilePath = FilePathDefault;
            UserData = data.GetData(FilePath);
            var ColumnHeader = data.ColumnHeader.Skip(1);
            DataPrepColSelection.Items.Clear();
            DataPrepColSelection.Items.AddRange(ColumnHeader.ToArray());
            NullComboBox.Items.Clear();
            List<string> NullComboBoxItems = new List<string> {
                "Remove Row with Null",
                "Fill Null with Column Mean",
                "Fill Null with Column Max",
                "Fill Null with Column Min",
                "Reload Data"
            };
            NullComboBox.Items.AddRange(NullComboBoxItems.ToArray());

            Table = new MakeTable(DataTable, data.UserData);
            var NumericalData = data.NumericDataSummary;
            NumericStatTabl = new MakeTable(NumericStatTable, NumericalData);
            var NonNumericalData = data.NonNumericDataSummary;
            NonNumericStatTabl = new MakeTable(NonNumericStatTable, NonNumericalData);
            data.SortData();
            Table.UpdateTable(data.UserData);

            SPCHeader = new List<string>(data.NumericalColumnHeader);
            SPCColumnComboBox.Items.Clear();
            SPCColumnComboBox.Items.AddRange(SPCHeader.ToArray());
            SPC = new MakeSPC();
            Debug.WriteLine(string.Join(", ", data.UserData.SelectMany(innerList => innerList)));

            ModelChat = new LLMInterface();
            InitializeApp();

        }
        private async void InitializeApp()
        {
            await ModelChat.PingServer(ModelURL);
        }
        public async Task<string> SendModelMessage(string message)
        {
            return await ModelChat.SendMessageToModel(message);
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

        private void NullComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NullComboBox.SelectedIndex != -1)
            {
                string selectedValue = NullComboBox.SelectedItem.ToString();
                if (selectedValue.Contains("Remove"))
                {
                    data.RemoveNullData();

                }
                if (selectedValue.Contains("Reload"))
                {
                    data.RevertData();

                }
                if (selectedValue.Contains("Mean"))
                {
                    data.FillNullData("Mean");
                }
                if (selectedValue.Contains("Max"))
                {
                    data.FillNullData("Max");
                }
                if (selectedValue.Contains("Min"))
                {
                    data.FillNullData("Min");
                }
                Table.UpdateTable(data.UserData);
                NumericStatTabl.UpdateTable(data.NumericDataSummary);
                NonNumericStatTabl.UpdateTable(data.NonNumericDataSummary);
            }
        }

        private void SPCColumnComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SPCColumnComboBox.SelectedIndex != -1)
            {
                foreach (var item in SPCHeader)
                {
                    Debug.WriteLine(item);
                }
                string selectedValue = SPCColumnComboBox.SelectedItem.ToString();
                List<List<float>> SPCData = new List<List<float>>();
                foreach (string columnName in SPCHeader)
                {
                    int ColumnIndex = data.ColumnHeader.IndexOf(columnName);
                    if (ColumnIndex == -1) continue;

                    List<float> tempList = UserData
                        .Skip(1)
                        .Where(row => row.Count > ColumnIndex && !string.IsNullOrWhiteSpace(row[ColumnIndex]))
                        .Select(row => float.Parse(row[ColumnIndex]))
                        .ToList();

                    SPCData.Add(tempList);
                }
                List<List<float>> rotatedSPCData = new List<List<float>>();
                int rowCount = SPCData.Count;
                int colCount = SPCData[0].Count;

                var result = new List<List<float>>();

                for (int col = 0; col < colCount; col++)
                {
                    var newRow = new List<float>();
                    for (int row = 0; row < rowCount; row++)
                    {
                        newRow.Add(SPCData[row][col]);
                    }
                    rotatedSPCData.Add(newRow);
                }

                var SPCResult = SPC.InitializeSPC(SPCHeader, rotatedSPCData);

                var ColumnStatistic = SPC.GetStatistics();
                var Statistics = ColumnStatistic[selectedValue];

                //var XData = UserData.Skip(1).Where(row => row.Count >0).Select(row => DateTime.Parse(row[0])).ToList();
                var YData = SPCResult[selectedValue].Item1;
                List<float> XData = new List<float>();
                for (int i = 0; i < YData.Count; i++)
                {
                    XData.Add(i);
                }


                var ColorData = SPCResult[selectedValue].Item2;
                var chart = new PlotSPC(SPCPlot, Statistics, XData, YData, ColorData);
            }
        }
        #region GetDataClick
        private void btnGetData_Click(object sender, EventArgs e)
        {
            OpenFileDialog File = new OpenFileDialog();
            File.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            File.Title = "Select a file";
            if (File.ShowDialog() == DialogResult.OK)
            {
                FilePath = File.FileName;
                Debug.WriteLine(FilePath);
                try
                {
                    UserData = data.GetData(@$"{FilePath}");

                }
                catch (Exception ex)
                {
                    UserData = data.GetData(FilePathDefault);
                }
                finally
                {
                    var ColumnHeader = data.ColumnHeader.Skip(1);
                    DataPrepColSelection.Items.Clear();
                    DataPrepColSelection.Items.AddRange(ColumnHeader.ToArray());
                    Table = new MakeTable(DataTable, data.UserData);
                    var NumericalData = data.NumericDataSummary;
                    NumericStatTabl = new MakeTable(NumericStatTable, NumericalData);
                    var NonNumericalData = data.NonNumericDataSummary;
                    NonNumericStatTabl = new MakeTable(NonNumericStatTable, NonNumericalData);
                    data.SortData();
                    Table.UpdateTable(data.UserData);
                    SPCHeader = new List<string>(data.NumericalColumnHeader);
                    SPCColumnComboBox.Items.Clear();
                    SPCColumnComboBox.Items.AddRange(SPCHeader.ToArray());
                }
            }

        }
        #endregion


        private async void btnChatEnter_Click(object sender, EventArgs e)
        {
            if (UserChatBox.Text.Length > 0) {
                string UserMessage = UserChatBox.Text.Substring(0, UserChatBox.Text.Length);
                MainChatBox.SelectionAlignment = HorizontalAlignment.Right;
                MainChatBox.SelectionFont = new Font(MainChatBox.Font, FontStyle.Bold);
                MainChatBox.AppendText("User: ");
                MainChatBox.SelectionFont = MainChatBox.Font;
                MainChatBox.AppendText( UserMessage + Environment.NewLine);
                MainChatBox.ScrollToCaret();
                if(ModelChat.ModelConnected == 1)
                {
                    string ModelMessage = await SendModelMessage(UserMessage);
                    if (ModelMessage.Length > 0)
                    {
                        ModelMessage = ModelMessage.Replace(@"\boxed{4}", "[4]");
                        ModelMessage = ModelMessage.Replace(@"$\boxed{4}$", "[4]");
                        MainChatBox.SelectionAlignment = HorizontalAlignment.Left;
                        MainChatBox.SelectionFont = new Font(MainChatBox.Font, FontStyle.Bold);
                        MainChatBox.AppendText("Model: ");
                        MainChatBox.SelectionFont = MainChatBox.Font;
                        MainChatBox.AppendText(ModelMessage + Environment.NewLine);
                        MainChatBox.ScrollToCaret();
                    }
                }
                else
                {
                    MainChatBox.SelectionAlignment = HorizontalAlignment.Left;
                    MainChatBox.AppendText("Model not connected" + Environment.NewLine);
                }

            }

        }
    }
}
