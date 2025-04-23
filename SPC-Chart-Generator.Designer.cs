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
            ((System.ComponentModel.ISupportInitialize)SPCPlot).BeginInit();
            SuspendLayout();
            // 
            // SPCPlot
            // 
            chartArea1.Name = "ChartArea1";
            SPCPlot.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            SPCPlot.Legends.Add(legend1);
            SPCPlot.Location = new Point(12, 13);
            SPCPlot.Margin = new Padding(3, 4, 3, 4);
            SPCPlot.Name = "SPCPlot";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            SPCPlot.Series.Add(series1);
            SPCPlot.Size = new Size(908, 591);
            SPCPlot.TabIndex = 0;
            SPCPlot.Text = "SPC Plot";
            // 
            // SPCChart
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(SPCPlot);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SPCChart";
            Text = "SPC Chart";
            ((System.ComponentModel.ISupportInitialize)SPCPlot).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private System.Windows.Forms.DataVisualization.Charting.Chart SPCPlot;
    }
}
