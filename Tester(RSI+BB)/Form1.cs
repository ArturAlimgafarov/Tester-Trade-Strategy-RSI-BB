using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Tester_RSI_BB_
{
    public partial class Form1 : Form
    {
        Dictionary<string, int> tickers;
        bool chartOn;

        public Form1()
        {
            InitializeComponent();

            ParseTickers();

            foreach (var ticker in tickers.Keys)
            {
                comboBox_Symbol.Items.Add(ticker);
            }

            comboBox_Symbol.SelectedIndex = 0;

            domainUpDown_TimeFrame.SelectedIndex = 0;

            chartOn = false;
            button_OpenChart.Enabled = chartOn;

            dateTimePicker_End.Value = DateTime.Today;
            //dateTimePicker_Start.Value = DateTime.Today.AddMonths(-1);
            //dateTimePicker_Start.Value = DateTime.Today.AddDays(-7);
            dateTimePicker_Start.Value = DateTime.Today.AddDays(-14);
        }

        private void ParseTickers()
        {
            tickers = new Dictionary<string, int>();
            StreamReader reader = new StreamReader("tickers.txt");

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                    break;

                string[] data = line.Split(' ');

                string ticker = data[0];
                int code = int.Parse(data[1]);

                tickers.Add(ticker, code);
            }

            //close the file
            reader.Close();
        }

        private void comboBox_Symbol_TextChanged(object sender, EventArgs e)
        {
            comboBox_Symbol.Text = "";
        }

        private void button_Analysis_Click(object sender, EventArgs e)
        {
            if (comboBox_Symbol.SelectedIndex != -1)
            {
                chartOn = false;
                button_OpenChart.Enabled = chartOn;

                listBox_Analysis.Items.Clear();

                string ticker = comboBox_Symbol.SelectedItem.ToString();
                int code = tickers[ticker];
                AnalysisData ad = new AnalysisData()
                {
                    StartDate = dateTimePicker_Start.Value.GetDateTimeFormats()[0],
                    EndDate = dateTimePicker_End.Value.GetDateTimeFormats()[0],
                    TimeFrameCode = domainUpDown_TimeFrame.SelectedIndex + 2,
                    TickersData = new Dictionary<string, int>() { { ticker, code } }
                };


                string json = JsonConvert.SerializeObject(ad);
                File.WriteAllText(@"data.json", json);

                Process.Start("analysis.py");

                chartOn = true;
            }
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            chartOn = false;
            button_OpenChart.Enabled = chartOn;

            listBox_Analysis.Items.Clear();

            AnalysisData ad = new AnalysisData()
            {
                StartDate = dateTimePicker_Start.Value.GetDateTimeFormats()[0],
                EndDate = dateTimePicker_End.Value.GetDateTimeFormats()[0],
                TimeFrameCode = domainUpDown_TimeFrame.SelectedIndex + 2,
                TickersData = tickers
            };


            string json = JsonConvert.SerializeObject(ad);
            File.WriteAllText(@"data.json", json);

            Process.Start("analysis.py");
        }

        private void button_ShowAnalysis_Click(object sender, EventArgs e)
        {
            listBox_Analysis.Items.Clear();

            StreamReader sr = new StreamReader("analysis_data.txt", System.Text.Encoding.Default);

            while (true)
            {
                string line = sr.ReadLine();

                if (line == null)
                    break;

                listBox_Analysis.Items.Add(line);
            }

            sr.Close();

            button_OpenChart.Enabled = chartOn;
        }

        private void button_OpenChart_Click(object sender, EventArgs e)
        {
            new Chart(listBox_Analysis.Items[0].ToString(), domainUpDown_TimeFrame.Text).Show();
        }
    }
}