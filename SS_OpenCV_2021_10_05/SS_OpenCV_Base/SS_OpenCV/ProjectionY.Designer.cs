using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace SS_OpenCV
{
    partial class ProjectionY
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        public ProjectionY(int[] array, int height)
        {
            InitializeComponent();

            DataPointCollection list0 = chart1.Series[0].Points;
            DataPointCollection list1 = chart1.Series[1].Points;

            int avg = (int)array.Average();

            for (int i = 0; i < height; i++)
            {
                list0.AddXY(array[i], i);
                list1.AddXY(avg, i);
            }

            chart1.Series[0].Color = Color.Red;
            chart1.Series[1].Color = Color.Blue;
            chart1.ChartAreas[0].AxisY.Maximum = height;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Title = "Contagem";
            chart1.ChartAreas[0].AxisY.Title = "Intensidade";
            chart1.ResumeLayout();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series0 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            // isReversed vai servir para a direçao dos valores positivos do axis Y ( Ou seja para baixo termos valores positivos)
            chartArea1.AxisY.IsReversed = true;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series0.ChartArea = "ChartArea1";
            series1.ChartArea = "ChartArea1";
            series0.Name = "Series0";
            series1.Name = "Series1";
            series0.ChartType = SeriesChartType.Line;
            series1.ChartType = SeriesChartType.Line;
            this.chart1.Series.Add(series0);
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(800, 450);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // ProjectionY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Name = "ProjectionY";
            this.Text = "ProjectionY";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}