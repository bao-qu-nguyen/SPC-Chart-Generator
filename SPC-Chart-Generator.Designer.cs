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
            SPC_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)SPC_Chart).BeginInit();
            SuspendLayout();
            // 
            // SPC_Chart
            // 
            chartArea1.Name = "ChartArea1";
            SPC_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            SPC_Chart.Legends.Add(legend1);
            SPC_Chart.Location = new Point(2, 12);
            SPC_Chart.Name = "SPC_Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            SPC_Chart.Series.Add(series1);
            SPC_Chart.Size = new Size(383, 210);
            SPC_Chart.TabIndex = 0;
            SPC_Chart.Text = "chart1";
            // 
            // SPCChart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SPC_Chart);
            Name = "SPCChart";
            Text = "SPC Chart";
            ((System.ComponentModel.ISupportInitialize)SPC_Chart).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.DataVisualization.Charting.Chart SPC_Chart;
    }
}
