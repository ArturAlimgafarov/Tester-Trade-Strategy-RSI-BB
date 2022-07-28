
namespace Tester_RSI_BB_
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.domainUpDown_TimeFrame = new System.Windows.Forms.DomainUpDown();
            this.comboBox_Symbol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Analysis = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox_Analysis = new System.Windows.Forms.ListBox();
            this.button_Top = new System.Windows.Forms.Button();
            this.button_OpenChart = new System.Windows.Forms.Button();
            this.button_ShowAnalysis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Start.Location = new System.Drawing.Point(53, 29);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_Start.TabIndex = 0;
            this.dateTimePicker_Start.Value = new System.DateTime(2022, 3, 14, 2, 38, 58, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "__";
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_End.Location = new System.Drawing.Point(180, 29);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_End.TabIndex = 2;
            this.dateTimePicker_End.Value = new System.DateTime(2022, 3, 14, 2, 38, 58, 0);
            // 
            // domainUpDown_TimeFrame
            // 
            this.domainUpDown_TimeFrame.Items.Add("1 мин.");
            this.domainUpDown_TimeFrame.Items.Add("5 мин.");
            this.domainUpDown_TimeFrame.Items.Add("10 мин.");
            this.domainUpDown_TimeFrame.Items.Add("15 мин.");
            this.domainUpDown_TimeFrame.Items.Add("30 мин.");
            this.domainUpDown_TimeFrame.Items.Add("1 час");
            this.domainUpDown_TimeFrame.Items.Add("1 день");
            this.domainUpDown_TimeFrame.Items.Add("1 неделя");
            this.domainUpDown_TimeFrame.Items.Add("1 месяц");
            this.domainUpDown_TimeFrame.Location = new System.Drawing.Point(103, 83);
            this.domainUpDown_TimeFrame.Name = "domainUpDown_TimeFrame";
            this.domainUpDown_TimeFrame.Size = new System.Drawing.Size(120, 20);
            this.domainUpDown_TimeFrame.TabIndex = 3;
            this.domainUpDown_TimeFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // comboBox_Symbol
            // 
            this.comboBox_Symbol.FormattingEnabled = true;
            this.comboBox_Symbol.Location = new System.Drawing.Point(12, 134);
            this.comboBox_Symbol.Name = "comboBox_Symbol";
            this.comboBox_Symbol.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Symbol.TabIndex = 4;
            this.comboBox_Symbol.TextChanged += new System.EventHandler(this.comboBox_Symbol_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Валютная пара";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(117, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Интервал времени";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Таймфрейм";
            // 
            // button_Analysis
            // 
            this.button_Analysis.Location = new System.Drawing.Point(148, 132);
            this.button_Analysis.Name = "button_Analysis";
            this.button_Analysis.Size = new System.Drawing.Size(75, 23);
            this.button_Analysis.TabIndex = 8;
            this.button_Analysis.Text = "Анализ";
            this.button_Analysis.UseVisualStyleBackColor = true;
            this.button_Analysis.Click += new System.EventHandler(this.button_Analysis_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "АНАЛИЗ";
            // 
            // listBox_Analysis
            // 
            this.listBox_Analysis.FormattingEnabled = true;
            this.listBox_Analysis.Location = new System.Drawing.Point(12, 195);
            this.listBox_Analysis.Name = "listBox_Analysis";
            this.listBox_Analysis.Size = new System.Drawing.Size(307, 251);
            this.listBox_Analysis.TabIndex = 11;
            // 
            // button_Top
            // 
            this.button_Top.Location = new System.Drawing.Point(244, 132);
            this.button_Top.Name = "button_Top";
            this.button_Top.Size = new System.Drawing.Size(75, 23);
            this.button_Top.TabIndex = 12;
            this.button_Top.Text = "Список";
            this.button_Top.UseVisualStyleBackColor = true;
            this.button_Top.Click += new System.EventHandler(this.button_Top_Click);
            // 
            // button_OpenChart
            // 
            this.button_OpenChart.Location = new System.Drawing.Point(103, 452);
            this.button_OpenChart.Name = "button_OpenChart";
            this.button_OpenChart.Size = new System.Drawing.Size(120, 23);
            this.button_OpenChart.TabIndex = 13;
            this.button_OpenChart.Text = "Открыть график";
            this.button_OpenChart.UseVisualStyleBackColor = true;
            this.button_OpenChart.Click += new System.EventHandler(this.button_OpenChart_Click);
            // 
            // button_ShowAnalysis
            // 
            this.button_ShowAnalysis.Location = new System.Drawing.Point(244, 169);
            this.button_ShowAnalysis.Name = "button_ShowAnalysis";
            this.button_ShowAnalysis.Size = new System.Drawing.Size(75, 23);
            this.button_ShowAnalysis.TabIndex = 14;
            this.button_ShowAnalysis.Text = "Показать";
            this.button_ShowAnalysis.UseVisualStyleBackColor = true;
            this.button_ShowAnalysis.Click += new System.EventHandler(this.button_ShowAnalysis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 487);
            this.Controls.Add(this.button_ShowAnalysis);
            this.Controls.Add(this.button_OpenChart);
            this.Controls.Add(this.button_Top);
            this.Controls.Add(this.listBox_Analysis);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Analysis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_Symbol);
            this.Controls.Add(this.domainUpDown_TimeFrame);
            this.Controls.Add(this.dateTimePicker_End);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_End;
        private System.Windows.Forms.DomainUpDown domainUpDown_TimeFrame;
        private System.Windows.Forms.ComboBox comboBox_Symbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Analysis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox_Analysis;
        private System.Windows.Forms.Button button_Top;
        private System.Windows.Forms.Button button_OpenChart;
        private System.Windows.Forms.Button button_ShowAnalysis;
    }
}

