namespace SPC_Chart_Generator
{
    partial class SPCChart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            SPCPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            MainTab = new TabControl();
            DataPreparationTab = new TabPage();
            NonNumericStatTable = new DataGridView();
            NumericStatTable = new DataGridView();
            DataTable = new DataGridView();
            SPCTab = new TabPage();
            ((System.ComponentModel.ISupportInitialize)SPCPlot).BeginInit();
            MainTab.SuspendLayout();
            DataPreparationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NonNumericStatTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericStatTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataTable).BeginInit();
            SPCTab.SuspendLayout();
            SuspendLayout();
            // 
            // SPCPlot
            // 
            chartArea1.Name = "ChartArea1";
            SPCPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            SPCPlot.Legends.Add(legend1);
            SPCPlot.Location = new Point(3, 4);
            SPCPlot.Margin = new Padding(3, 4, 3, 4);
            SPCPlot.Name = "SPCPlot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            SPCPlot.Series.Add(series1);
            SPCPlot.Size = new Size(458, 296);
            SPCPlot.TabIndex = 0;
            SPCPlot.Text = "SPC Plot";
            // 
            // MainTab
            // 
            MainTab.Controls.Add(DataPreparationTab);
            MainTab.Controls.Add(SPCTab);
            MainTab.Dock = DockStyle.Fill;
            MainTab.Location = new Point(0, 0);
            MainTab.Name = "MainTab";
            MainTab.SelectedIndex = 0;
            MainTab.Size = new Size(1486, 711);
            MainTab.TabIndex = 1;
            // 
            // DataPreparationTab
            // 
            DataPreparationTab.Controls.Add(NonNumericStatTable);
            DataPreparationTab.Controls.Add(NumericStatTable);
            DataPreparationTab.Controls.Add(DataTable);
            DataPreparationTab.Location = new Point(4, 29);
            DataPreparationTab.Name = "DataPreparationTab";
            DataPreparationTab.Padding = new Padding(3);
            DataPreparationTab.Size = new Size(1478, 678);
            DataPreparationTab.TabIndex = 0;
            DataPreparationTab.Text = "Data Preparation";
            DataPreparationTab.UseVisualStyleBackColor = true;
            // 
            // NonNumericStatTable
            // 
            NonNumericStatTable.AllowUserToAddRows = false;
            NonNumericStatTable.AllowUserToDeleteRows = false;
            NonNumericStatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NonNumericStatTable.Location = new Point(688, 220);
            NonNumericStatTable.Name = "NonNumericStatTable";
            NonNumericStatTable.RowHeadersWidth = 51;
            NonNumericStatTable.ShowEditingIcon = false;
            NonNumericStatTable.Size = new Size(487, 188);
            NonNumericStatTable.TabIndex = 2;
            // 
            // NumericStatTable
            // 
            NumericStatTable.AllowUserToAddRows = false;
            NumericStatTable.AllowUserToDeleteRows = false;
            NumericStatTable.AllowUserToOrderColumns = true;
            NumericStatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NumericStatTable.Location = new Point(688, 6);
            NumericStatTable.Name = "NumericStatTable";
            NumericStatTable.RowHeadersWidth = 51;
            NumericStatTable.Size = new Size(762, 188);
            NumericStatTable.TabIndex = 1;
            // 
            // DataTable
            // 
            DataTable.AllowUserToOrderColumns = true;
            DataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataTable.Location = new Point(8, 6);
            DataTable.Name = "DataTable";
            DataTable.RowHeadersWidth = 51;
            DataTable.Size = new Size(665, 402);
            DataTable.TabIndex = 0;
            // 
            // SPCTab
            // 
            SPCTab.Controls.Add(SPCPlot);
            SPCTab.Location = new Point(4, 29);
            SPCTab.Name = "SPCTab";
            SPCTab.Padding = new Padding(3);
            SPCTab.Size = new Size(1478, 678);
            SPCTab.TabIndex = 1;
            SPCTab.Text = "SPC";
            SPCTab.UseVisualStyleBackColor = true;
            // 
            // SPCChart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1486, 711);
            Controls.Add(MainTab);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SPCChart";
            Text = "SPC Chart";
            ((System.ComponentModel.ISupportInitialize)SPCPlot).EndInit();
            MainTab.ResumeLayout(false);
            DataPreparationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NonNumericStatTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericStatTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataTable).EndInit();
            SPCTab.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.DataVisualization.Charting.Chart SPCPlot;
        private TabControl MainTab;
        private TabPage DataPreparationTab;
        private TabPage SPCTab;
        private DataGridView DataTable;
        private DataGridView dataGridView2;
        private DataGridView NumericStatTable;
        private DataGridView NonNumericStatTable;
    }
}
