
namespace Tester_RSI_BB_
{
    partial class Chart
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_Indicators = new System.Windows.Forms.CheckBox();
            this.checkBox_Signals = new System.Windows.Forms.CheckBox();
            this.pictureBox_TimeFrame = new System.Windows.Forms.PictureBox();
            this.pictureBox_DateTime = new System.Windows.Forms.PictureBox();
            this.pictureBox_BottomChartScale = new System.Windows.Forms.PictureBox();
            this.pictureBox_BottomChart = new System.Windows.Forms.PictureBox();
            this.pictureBox_PriceScale = new System.Windows.Forms.PictureBox();
            this.pictureBox_WorkTable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TimeFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DateTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomChartScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PriceScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WorkTable)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_Indicators
            // 
            this.checkBox_Indicators.AutoSize = true;
            this.checkBox_Indicators.Checked = true;
            this.checkBox_Indicators.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Indicators.Location = new System.Drawing.Point(147, 8);
            this.checkBox_Indicators.Name = "checkBox_Indicators";
            this.checkBox_Indicators.Size = new System.Drawing.Size(89, 17);
            this.checkBox_Indicators.TabIndex = 33;
            this.checkBox_Indicators.Text = "Индикаторы";
            this.checkBox_Indicators.UseVisualStyleBackColor = true;
            // 
            // checkBox_Signals
            // 
            this.checkBox_Signals.AutoSize = true;
            this.checkBox_Signals.Checked = true;
            this.checkBox_Signals.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Signals.Location = new System.Drawing.Point(12, 8);
            this.checkBox_Signals.Name = "checkBox_Signals";
            this.checkBox_Signals.Size = new System.Drawing.Size(70, 17);
            this.checkBox_Signals.TabIndex = 32;
            this.checkBox_Signals.Text = "Сигналы";
            this.checkBox_Signals.UseVisualStyleBackColor = true;
            // 
            // pictureBox_TimeFrame
            // 
            this.pictureBox_TimeFrame.BackColor = System.Drawing.Color.White;
            this.pictureBox_TimeFrame.Location = new System.Drawing.Point(713, 533);
            this.pictureBox_TimeFrame.Name = "pictureBox_TimeFrame";
            this.pictureBox_TimeFrame.Size = new System.Drawing.Size(90, 27);
            this.pictureBox_TimeFrame.TabIndex = 31;
            this.pictureBox_TimeFrame.TabStop = false;
            this.pictureBox_TimeFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_TimeFrame_Paint);
            // 
            // pictureBox_DateTime
            // 
            this.pictureBox_DateTime.BackColor = System.Drawing.Color.White;
            this.pictureBox_DateTime.Location = new System.Drawing.Point(12, 533);
            this.pictureBox_DateTime.Name = "pictureBox_DateTime";
            this.pictureBox_DateTime.Size = new System.Drawing.Size(700, 27);
            this.pictureBox_DateTime.TabIndex = 30;
            this.pictureBox_DateTime.TabStop = false;
            this.pictureBox_DateTime.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_DateTime_Paint);
            // 
            // pictureBox_BottomChartScale
            // 
            this.pictureBox_BottomChartScale.BackColor = System.Drawing.Color.White;
            this.pictureBox_BottomChartScale.Location = new System.Drawing.Point(713, 432);
            this.pictureBox_BottomChartScale.Name = "pictureBox_BottomChartScale";
            this.pictureBox_BottomChartScale.Size = new System.Drawing.Size(90, 100);
            this.pictureBox_BottomChartScale.TabIndex = 29;
            this.pictureBox_BottomChartScale.TabStop = false;
            this.pictureBox_BottomChartScale.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_BottomChartScale_Paint);
            // 
            // pictureBox_BottomChart
            // 
            this.pictureBox_BottomChart.BackColor = System.Drawing.Color.White;
            this.pictureBox_BottomChart.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox_BottomChart.Location = new System.Drawing.Point(12, 432);
            this.pictureBox_BottomChart.Name = "pictureBox_BottomChart";
            this.pictureBox_BottomChart.Size = new System.Drawing.Size(700, 100);
            this.pictureBox_BottomChart.TabIndex = 28;
            this.pictureBox_BottomChart.TabStop = false;
            this.pictureBox_BottomChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_BottomChart_Paint);
            this.pictureBox_BottomChart.MouseLeave += new System.EventHandler(this.pictureBox_BottomChart_MouseLeave);
            this.pictureBox_BottomChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_BottomChart_MouseMove);
            // 
            // pictureBox_PriceScale
            // 
            this.pictureBox_PriceScale.BackColor = System.Drawing.Color.White;
            this.pictureBox_PriceScale.Location = new System.Drawing.Point(713, 31);
            this.pictureBox_PriceScale.Name = "pictureBox_PriceScale";
            this.pictureBox_PriceScale.Size = new System.Drawing.Size(90, 400);
            this.pictureBox_PriceScale.TabIndex = 27;
            this.pictureBox_PriceScale.TabStop = false;
            this.pictureBox_PriceScale.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_PriceScale_Paint);
            this.pictureBox_PriceScale.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_PriceScale_MouseMove);
            // 
            // pictureBox_WorkTable
            // 
            this.pictureBox_WorkTable.BackColor = System.Drawing.Color.White;
            this.pictureBox_WorkTable.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox_WorkTable.Location = new System.Drawing.Point(12, 31);
            this.pictureBox_WorkTable.Name = "pictureBox_WorkTable";
            this.pictureBox_WorkTable.Size = new System.Drawing.Size(700, 400);
            this.pictureBox_WorkTable.TabIndex = 26;
            this.pictureBox_WorkTable.TabStop = false;
            this.pictureBox_WorkTable.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_WorkTable_Paint);
            this.pictureBox_WorkTable.MouseLeave += new System.EventHandler(this.pictureBox_WorkTable_MouseLeave);
            this.pictureBox_WorkTable.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_WorkTable_MouseMove);
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 569);
            this.Controls.Add(this.checkBox_Indicators);
            this.Controls.Add(this.checkBox_Signals);
            this.Controls.Add(this.pictureBox_TimeFrame);
            this.Controls.Add(this.pictureBox_DateTime);
            this.Controls.Add(this.pictureBox_BottomChartScale);
            this.Controls.Add(this.pictureBox_BottomChart);
            this.Controls.Add(this.pictureBox_PriceScale);
            this.Controls.Add(this.pictureBox_WorkTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Chart";
            this.ShowIcon = false;
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TimeFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DateTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomChartScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BottomChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_PriceScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_WorkTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Indicators;
        private System.Windows.Forms.CheckBox checkBox_Signals;
        private System.Windows.Forms.PictureBox pictureBox_TimeFrame;
        private System.Windows.Forms.PictureBox pictureBox_DateTime;
        private System.Windows.Forms.PictureBox pictureBox_BottomChartScale;
        private System.Windows.Forms.PictureBox pictureBox_BottomChart;
        private System.Windows.Forms.PictureBox pictureBox_PriceScale;
        private System.Windows.Forms.PictureBox pictureBox_WorkTable;
    }
}