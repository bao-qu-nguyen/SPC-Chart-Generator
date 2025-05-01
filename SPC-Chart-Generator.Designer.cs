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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            SPCPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            MainTab = new TabControl();
            DataPreparationTab = new TabPage();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox2 = new GroupBox();
            btnGetData = new Button();
            DataPrepColSelection = new ComboBox();
            NullComboBox = new ComboBox();
            groupBox1 = new GroupBox();
            radioBtnOriginal = new RadioButton();
            RadioBtnNullMin = new RadioButton();
            RadioBtnNullDelete = new RadioButton();
            RadioBtnNullMax = new RadioButton();
            RadioBtnNullMean = new RadioButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            groupBox4 = new GroupBox();
            NumericStatTable = new DataGridView();
            groupBox3 = new GroupBox();
            NonNumericStatTable = new DataGridView();
            DataPrepChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            tableLayoutPanel1 = new TableLayoutPanel();
            DataTable = new DataGridView();
            tableLayoutPanel7 = new TableLayoutPanel();
            tableLayoutPanel8 = new TableLayoutPanel();
            UserChatBox = new TextBox();
            btnChatEnter = new Button();
            MainChatBox = new RichTextBox();
            SPCTab = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            groupBox5 = new GroupBox();
            SPCColumnComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)SPCPlot).BeginInit();
            MainTab.SuspendLayout();
            DataPreparationTab.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericStatTable).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NonNumericStatTable).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DataPrepChart).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataTable).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            SPCTab.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // SPCPlot
            // 
            chartArea1.Name = "ChartArea1";
            SPCPlot.ChartAreas.Add(chartArea1);
            SPCPlot.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            SPCPlot.Legends.Add(legend1);
            SPCPlot.Location = new Point(302, 4);
            SPCPlot.Margin = new Padding(3, 4, 3, 4);
            SPCPlot.Name = "SPCPlot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            SPCPlot.Series.Add(series1);
            SPCPlot.Size = new Size(1054, 796);
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
            MainTab.Size = new Size(1373, 843);
            MainTab.TabIndex = 1;
            // 
            // DataPreparationTab
            // 
            DataPreparationTab.Controls.Add(tableLayoutPanel3);
            DataPreparationTab.Controls.Add(tableLayoutPanel1);
            DataPreparationTab.Location = new Point(4, 29);
            DataPreparationTab.Name = "DataPreparationTab";
            DataPreparationTab.Padding = new Padding(3);
            DataPreparationTab.Size = new Size(1365, 810);
            DataPreparationTab.TabIndex = 0;
            DataPreparationTab.Text = "Data Preparation";
            DataPreparationTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.337738F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.58884F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel3.Controls.Add(DataPrepChart, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1359, 549);
            tableLayoutPanel3.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(groupBox2, 0, 0);
            tableLayoutPanel4.Controls.Add(groupBox1, 0, 1);
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(270, 543);
            tableLayoutPanel4.TabIndex = 15;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnGetData);
            groupBox2.Controls.Add(DataPrepColSelection);
            groupBox2.Controls.Add(NullComboBox);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(264, 177);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data and Graph Settings";
            // 
            // btnGetData
            // 
            btnGetData.Location = new Point(6, 71);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(151, 37);
            btnGetData.TabIndex = 6;
            btnGetData.Text = "GetData";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += btnGetData_Click;
            // 
            // DataPrepColSelection
            // 
            DataPrepColSelection.FormattingEnabled = true;
            DataPrepColSelection.Location = new Point(6, 26);
            DataPrepColSelection.Name = "DataPrepColSelection";
            DataPrepColSelection.Size = new Size(151, 28);
            DataPrepColSelection.TabIndex = 4;
            DataPrepColSelection.SelectedIndexChanged += DataPrepColSelection_SelectedIndexChanged;
            // 
            // NullComboBox
            // 
            NullComboBox.DropDownWidth = 230;
            NullComboBox.FormattingEnabled = true;
            NullComboBox.Location = new Point(6, 128);
            NullComboBox.Name = "NullComboBox";
            NullComboBox.Size = new Size(151, 28);
            NullComboBox.TabIndex = 5;
            NullComboBox.SelectedIndexChanged += NullComboBox_SelectedIndexChanged;
            NullComboBox.ValueMemberChanged += DataPrepColSelection_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioBtnOriginal);
            groupBox1.Controls.Add(RadioBtnNullMin);
            groupBox1.Controls.Add(RadioBtnNullDelete);
            groupBox1.Controls.Add(RadioBtnNullMax);
            groupBox1.Controls.Add(RadioBtnNullMean);
            groupBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 274);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(259, 183);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Null Value Handling Options";
            // 
            // radioBtnOriginal
            // 
            radioBtnOriginal.AutoSize = true;
            radioBtnOriginal.Location = new Point(6, 26);
            radioBtnOriginal.Name = "radioBtnOriginal";
            radioBtnOriginal.Size = new Size(85, 24);
            radioBtnOriginal.TabIndex = 8;
            radioBtnOriginal.TabStop = true;
            radioBtnOriginal.Text = "Original";
            radioBtnOriginal.UseVisualStyleBackColor = true;
            // 
            // RadioBtnNullMin
            // 
            RadioBtnNullMin.AutoSize = true;
            RadioBtnNullMin.Location = new Point(6, 146);
            RadioBtnNullMin.Name = "RadioBtnNullMin";
            RadioBtnNullMin.Size = new Size(207, 24);
            RadioBtnNullMin.TabIndex = 12;
            RadioBtnNullMin.TabStop = true;
            RadioBtnNullMin.Text = "Replace With Column Min";
            RadioBtnNullMin.UseVisualStyleBackColor = true;
            // 
            // RadioBtnNullDelete
            // 
            RadioBtnNullDelete.AutoSize = true;
            RadioBtnNullDelete.Location = new Point(6, 56);
            RadioBtnNullDelete.Name = "RadioBtnNullDelete";
            RadioBtnNullDelete.Size = new Size(231, 24);
            RadioBtnNullDelete.TabIndex = 9;
            RadioBtnNullDelete.TabStop = true;
            RadioBtnNullDelete.Text = "Delete Row with Null Value(s)";
            RadioBtnNullDelete.UseVisualStyleBackColor = true;
            // 
            // RadioBtnNullMax
            // 
            RadioBtnNullMax.AutoSize = true;
            RadioBtnNullMax.Location = new Point(6, 116);
            RadioBtnNullMax.Name = "RadioBtnNullMax";
            RadioBtnNullMax.Size = new Size(210, 24);
            RadioBtnNullMax.TabIndex = 11;
            RadioBtnNullMax.TabStop = true;
            RadioBtnNullMax.Text = "Replace With Column Max";
            RadioBtnNullMax.UseVisualStyleBackColor = true;
            // 
            // RadioBtnNullMean
            // 
            RadioBtnNullMean.AutoSize = true;
            RadioBtnNullMean.Location = new Point(6, 86);
            RadioBtnNullMean.Name = "RadioBtnNullMean";
            RadioBtnNullMean.Size = new Size(219, 24);
            RadioBtnNullMean.TabIndex = 10;
            RadioBtnNullMean.TabStop = true;
            RadioBtnNullMean.Text = "Replace With Column Mean";
            RadioBtnNullMean.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.None;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(groupBox4, 0, 0);
            tableLayoutPanel2.Controls.Add(groupBox3, 0, 1);
            tableLayoutPanel2.Location = new Point(279, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(396, 543);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(NumericStatTable);
            groupBox4.Dock = DockStyle.Fill;
            groupBox4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(3, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(390, 265);
            groupBox4.TabIndex = 4;
            groupBox4.TabStop = false;
            groupBox4.Text = "Numerical Column Statistics";
            // 
            // NumericStatTable
            // 
            NumericStatTable.AllowUserToAddRows = false;
            NumericStatTable.AllowUserToDeleteRows = false;
            NumericStatTable.AllowUserToOrderColumns = true;
            NumericStatTable.BackgroundColor = SystemColors.ControlLightLight;
            NumericStatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NumericStatTable.Dock = DockStyle.Fill;
            NumericStatTable.Location = new Point(3, 23);
            NumericStatTable.Name = "NumericStatTable";
            NumericStatTable.RowHeadersWidth = 51;
            NumericStatTable.Size = new Size(384, 239);
            NumericStatTable.TabIndex = 1;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(NonNumericStatTable);
            groupBox3.Dock = DockStyle.Fill;
            groupBox3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(3, 274);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(390, 266);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Categorical Column Statistics";
            // 
            // NonNumericStatTable
            // 
            NonNumericStatTable.AllowUserToAddRows = false;
            NonNumericStatTable.AllowUserToDeleteRows = false;
            NonNumericStatTable.BackgroundColor = SystemColors.ControlLightLight;
            NonNumericStatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            NonNumericStatTable.Dock = DockStyle.Fill;
            NonNumericStatTable.Location = new Point(3, 23);
            NonNumericStatTable.Name = "NonNumericStatTable";
            NonNumericStatTable.RowHeadersWidth = 51;
            NonNumericStatTable.ShowEditingIcon = false;
            NonNumericStatTable.Size = new Size(384, 240);
            NonNumericStatTable.TabIndex = 2;
            // 
            // DataPrepChart
            // 
            DataPrepChart.BorderlineColor = Color.Black;
            DataPrepChart.BorderlineWidth = 5;
            chartArea2.Name = "ChartArea1";
            DataPrepChart.ChartAreas.Add(chartArea2);
            DataPrepChart.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            DataPrepChart.Legends.Add(legend2);
            DataPrepChart.Location = new Point(681, 3);
            DataPrepChart.Name = "DataPrepChart";
            DataPrepChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            DataPrepChart.Series.Add(series2);
            DataPrepChart.Size = new Size(675, 543);
            DataPrepChart.TabIndex = 3;
            DataPrepChart.Text = "RawData";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.18396F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.81604F));
            tableLayoutPanel1.Controls.Add(DataTable, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel7, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(3, 552);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1359, 255);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // DataTable
            // 
            DataTable.AllowUserToOrderColumns = true;
            DataTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataTable.BackgroundColor = SystemColors.ControlLightLight;
            DataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataTable.Location = new Point(3, 3);
            DataTable.Name = "DataTable";
            DataTable.RowHeadersWidth = 51;
            DataTable.Size = new Size(676, 249);
            DataTable.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(tableLayoutPanel8, 0, 1);
            tableLayoutPanel7.Controls.Add(MainChatBox, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(685, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 83.9357452F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 16.0642567F));
            tableLayoutPanel7.Size = new Size(671, 249);
            tableLayoutPanel7.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.86466F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1353388F));
            tableLayoutPanel8.Controls.Add(UserChatBox, 0, 0);
            tableLayoutPanel8.Controls.Add(btnChatEnter, 1, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 212);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(665, 34);
            tableLayoutPanel8.TabIndex = 0;
            // 
            // UserChatBox
            // 
            UserChatBox.Dock = DockStyle.Fill;
            UserChatBox.Location = new Point(3, 3);
            UserChatBox.Name = "UserChatBox";
            UserChatBox.Size = new Size(565, 27);
            UserChatBox.TabIndex = 0;
            // 
            // btnChatEnter
            // 
            btnChatEnter.Location = new Point(574, 3);
            btnChatEnter.Name = "btnChatEnter";
            btnChatEnter.Size = new Size(88, 28);
            btnChatEnter.TabIndex = 1;
            btnChatEnter.Text = "Enter";
            btnChatEnter.UseVisualStyleBackColor = true;
            btnChatEnter.Click += btnChatEnter_Click;
            // 
            // MainChatBox
            // 
            MainChatBox.Dock = DockStyle.Fill;
            MainChatBox.Location = new Point(3, 3);
            MainChatBox.Name = "MainChatBox";
            MainChatBox.Size = new Size(665, 203);
            MainChatBox.TabIndex = 1;
            MainChatBox.Text = "";
            // 
            // SPCTab
            // 
            SPCTab.Controls.Add(tableLayoutPanel5);
            SPCTab.Location = new Point(4, 29);
            SPCTab.Name = "SPCTab";
            SPCTab.Padding = new Padding(3);
            SPCTab.Size = new Size(1365, 810);
            SPCTab.TabIndex = 1;
            SPCTab.Text = "SPC";
            SPCTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.0103989F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.9896F));
            tableLayoutPanel5.Controls.Add(SPCPlot, 1, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel6, 0, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(1359, 804);
            tableLayoutPanel5.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(groupBox5, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 3);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 22.1095333F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 77.8904648F));
            tableLayoutPanel6.Size = new Size(293, 798);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(SPCColumnComboBox);
            groupBox5.Dock = DockStyle.Fill;
            groupBox5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox5.Location = new Point(3, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(287, 170);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "SPC Column Selection";
            // 
            // SPCColumnComboBox
            // 
            SPCColumnComboBox.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SPCColumnComboBox.FormattingEnabled = true;
            SPCColumnComboBox.Location = new Point(6, 39);
            SPCColumnComboBox.Name = "SPCColumnComboBox";
            SPCColumnComboBox.Size = new Size(209, 28);
            SPCColumnComboBox.TabIndex = 1;
            SPCColumnComboBox.SelectedIndexChanged += SPCColumnComboBox_SelectedIndexChanged;
            // 
            // SPCChart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1373, 843);
            Controls.Add(MainTab);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SPCChart";
            Text = "SPC Chart";
            ((System.ComponentModel.ISupportInitialize)SPCPlot).EndInit();
            MainTab.ResumeLayout(false);
            DataPreparationTab.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NumericStatTable).EndInit();
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NonNumericStatTable).EndInit();
            ((System.ComponentModel.ISupportInitialize)DataPrepChart).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DataTable).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            SPCTab.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
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
        private System.Windows.Forms.DataVisualization.Charting.Chart DataPrepChart;
        private ComboBox DataPrepColSelection;
        private ComboBox NullComboBox;
        private ComboBox SPCColumnComboBox;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private RadioButton radioBtnOriginal;
        private RadioButton RadioBtnNullMin;
        private RadioButton RadioBtnNullMax;
        private RadioButton RadioBtnNullMean;
        private RadioButton RadioBtnNullDelete;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox2;
        private Button btnGetData;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private GroupBox groupBox5;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private TextBox UserChatBox;
        private Button btnChatEnter;
        private RichTextBox MainChatBox;
    }
}
