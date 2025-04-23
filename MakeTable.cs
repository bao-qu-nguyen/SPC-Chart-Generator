using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SPC_Chart_Generator
{
    public class MakeTable
    {
        List<List<string>> UserData = new List<List<string>>();
        DataGridView DataTable;
        List<List<string>> Data;
        public MakeTable(DataGridView dataTable, List<List<string>> data) {
            dataTable.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            DataTable = dataTable;
            Data = data;      
            UpdateTable(Data);
        }
        public void UpdateTable(List<List<string>> data)
        {
            Data = data;
            DataTable.Columns.Clear();
            DataTable.Rows.Clear();
            if (DataTable.Columns.Count == 0)
            {
                foreach (string ColName in Data[0])
                {
                    DataTable.Columns.Add(ColName, ColName);
                }
            }
            foreach (var item in Data.Skip(1))
            {
                DataTable.Rows.Add(item.ToArray());
            }
        }
    }
}
