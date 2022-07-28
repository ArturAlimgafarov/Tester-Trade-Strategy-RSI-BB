using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Tester_RSI_BB_
{
    public partial class Chart : Form
    {
        List<StockData> stockData;
        List<StockData> visibleData;
        int cursorX;
        int cursorY;
        bool cursorOnTable;

        int topLevel = 20;
        int bottomLevel = 20;
        const int indent = 1;
        const int tableMarksCount = 11;
        const int minVisibleCandlesCount = 20;

        const string filename = "quotes_data.txt";

        float linesStepVolume = 10;
        int linesStepTime = 20;

        int leftIndex;
        int rightIndex;
        int selectedIndex;

        string timeFrame;

        public Chart(string info, string timeFrame)
        {
            InitializeComponent();

            this.Text = info;

            pictureBox_WorkTable.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_BottomChart.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_PriceScale.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_BottomChartScale.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_DateTime.BackColor = Color.FromArgb(20, 25, 30);
            pictureBox_TimeFrame.BackColor = Color.FromArgb(20, 25, 30);

            ParseStockData(filename);

            this.timeFrame = timeFrame;

            int initCount = minVisibleCandlesCount * 2;
            visibleData = stockData.Skip(stockData.Count - initCount).ToList();

            leftIndex = stockData.Count - initCount;
            rightIndex = stockData.Count - 1;

            pictureBox_WorkTable.MouseWheel += MouseWheelEvent;
            pictureBox_BottomChart.MouseWheel += MouseWheelEvent;
        }

        private void ParseStockData(string filepath)
        {
            stockData = new List<StockData>();
            StreamReader reader = new StreamReader(filepath);

            while (true)
            {
                string line = reader.ReadLine();

                if (line == null)
                    break;

                string[] data = line.Split(',');

                string date = data[0];
                string time = data[1];
                double open = double.Parse(data[2].Replace('.', ','));
                double high = double.Parse(data[3].Replace('.', ','));
                double low = double.Parse(data[4].Replace('.', ','));
                double close = double.Parse(data[5].Replace('.', ','));
                int volume = int.Parse(data[6]);

                stockData.Add(new StockData(date, time, open, close, high, low, volume));
            }

            //close the file
            reader.Close();
        }

        private void DrawCandleChart(PaintEventArgs e)
        {
            int boxHeight = pictureBox_WorkTable.Height;
            int windowHeight = boxHeight - topLevel - bottomLevel;
            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);
            float k = (float)(windowHeight / (maxPrice - minPrice));

            int x = 0;
            foreach (var stock in visibleData)
            {
                float bodyLength = (float)(k * Math.Abs(stock.Open - stock.Close));
                float upperShadowLength = (float)(k * Math.Abs(stock.High - Math.Max(stock.Open, stock.Close)));
                float lowerShadowLength = (float)(k * Math.Abs(stock.Low - Math.Min(stock.Open, stock.Close)));

                float top = (float)(k * (Math.Max(stock.Open, stock.Close) - minPrice));
                float high = (float)(k * (stock.High - minPrice));
                float bottom = (float)(k * (Math.Min(stock.Open, stock.Close) - minPrice));

                // draw upper shadow
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - high,
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - high + upperShadowLength);

                // draw lower shadow
                e.Graphics.DrawLine(new Pen(stock.CurrentColor),
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - bottom,
                    x + stockWidth / 2,
                    boxHeight - bottomLevel - bottom + lowerShadowLength);

                // draw candle body
                e.Graphics.FillRectangle(new SolidBrush(stock.CurrentColor),
                    x,
                    boxHeight - bottomLevel - top,
                    stockWidth,
                    bodyLength);

                x += stockWidth + indent;
            }
        }

        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0 && pictureBox_WorkTable.Width / visibleData.Count - 1 > 1)
            {
                if (stockData.Count >= visibleData.Count)
                {
                    if (leftIndex > 0)
                    {
                        leftIndex--;
                        visibleData.Insert(0, stockData[leftIndex]);
                    }

                    if (rightIndex < stockData.Count - 1 && rightIndex > 0)
                    {
                        rightIndex++;
                        visibleData.Add(stockData[rightIndex]);
                    }
                }
            }
            else
            {
                if (leftIndex < stockData.Count - 1 && rightIndex - leftIndex >= 20)
                {
                    leftIndex++;
                    if (visibleData.Count > minVisibleCandlesCount)
                        visibleData.RemoveAt(0);
                }
            }

            RefreshPictureBoxes();
        }

        public void RefreshPictureBoxes()
        {
            pictureBox_WorkTable.Refresh();
            pictureBox_BottomChart.Refresh();
            pictureBox_BottomChartScale.Refresh();
            pictureBox_DateTime.Refresh();
            pictureBox_PriceScale.Refresh();
        }

        private void pictureBox_WorkTable_Paint(object sender, PaintEventArgs e)
        {
            // draw cursor dotted lines
            Pen dotlinePen = new Pen(Color.Gray);
            int lineLength = 4;
            int boxWidth = pictureBox_WorkTable.Width;
            int boxHeight = pictureBox_WorkTable.Height;

            // horizontal
            float y = 0;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(dotlinePen, cursorX, y, cursorX, y + lineLength);
                y += 2 * lineLength;
            }

            // vertical
            float x = 0;
            if (cursorOnTable)
            {
                while (x <= boxWidth)
                {
                    e.Graphics.DrawLine(dotlinePen, x, cursorY, x + lineLength, cursorY);
                    x += 2 * lineLength;
                }
            }
            ////


            // draw division
            Pen divPen = new Pen(Color.FromArgb(25, 94, 102, 115));
            float step = boxHeight / tableMarksCount;
            y = step;
            for (int i = 0; i < tableMarksCount; i++)
            {
                e.Graphics.DrawLine(divPen, 0, y, boxWidth, y);
                y += step;
            }

            int stockWidth = boxWidth / visibleData.Count - 1;
            x = stockWidth / 2;
            for (int i = 0; i < visibleData.Count; i += linesStepTime, x += (stockWidth + 1) * linesStepTime)
            {
                e.Graphics.DrawLine(divPen, x, 0, x, pictureBox_WorkTable.Height);
            }
            ////

            // draw chart title for candles & bars
            if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
            {
                string date = stockData[selectedIndex].Date.Insert(4, "/").Insert(7, "/");
                string time = stockData[selectedIndex].Time.Substring(0, 4).Insert(2, ":");
                string open = stockData[selectedIndex].Open.ToString();
                string higH = stockData[selectedIndex].High.ToString();
                string low = stockData[selectedIndex].Low.ToString();
                string close = stockData[selectedIndex].Close.ToString();

                string row = date + " " + time + "    " + "ОТКРЫТИЕ: " + open + " МАКСИМУМ: " + higH + " МИНИМУМ: " +
                    low + " ЗАКРЫТИЕ: " + close + " ОБЪЕМ: " + stockData[selectedIndex].Volume.ToString();
                e.Graphics.DrawString(row, new Font("Arial", 8), new SolidBrush(Color.White), 5, 5);
            }
            ////

            DrawCandleChart(e);

            // draw indicators
            //DrawIndicatorsFromList(e);
            ////
        }

        private void pictureBox_WorkTable_MouseMove(object sender, MouseEventArgs e)
        {
            // dragging chart
            if (MouseButtons == MouseButtons.Left)
            {
                if (Math.Abs(cursorX - e.X) > 5)
                {
                    if (e.X > cursorX)
                    {
                        if (leftIndex > 0)
                        {
                            leftIndex--;
                            rightIndex--;

                            visibleData.Insert(0, stockData[leftIndex]);
                            visibleData.RemoveAt(visibleData.Count - 1);
                        }
                    }
                    else
                    {
                        if (rightIndex < stockData.Count - 1)
                        {
                            leftIndex++;
                            rightIndex++;

                            visibleData.Add(stockData[rightIndex]);
                            visibleData.RemoveAt(0);
                        }
                    }
                }
            }
            ////


            // stock highlight
            visibleData.ForEach(sd => sd.CurrentColor = sd.InitColor);

            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            int index = e.X / (stockWidth + indent);
            selectedIndex = index + leftIndex;

            if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
                stockData[selectedIndex].CurrentColor = stockData[selectedIndex].SelectedColor;
            ////


            cursorX = index * (stockWidth + indent) + stockWidth / 2;
            cursorY = e.Y;
            cursorOnTable = true;

            RefreshPictureBoxes();
        }

        private void pictureBox_WorkTable_MouseLeave(object sender, EventArgs e)
        {
            cursorX = -10;
            cursorY = -10;

            RefreshPictureBoxes();
        }

        private void pictureBox_BottomChart_Paint(object sender, PaintEventArgs e)
        {
            // draw cursor dotted lines
            Pen dotlinepen = new Pen(Color.Gray);
            int lineLength = 4;
            int boxWidth = pictureBox_BottomChart.Width;
            int boxHeight = pictureBox_BottomChart.Height;

            // horizontal
            float y = 0;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(dotlinepen, cursorX, y, cursorX, y + lineLength);
                y += 2 * lineLength;
            }

            // vertical
            float x = 0;
            if (!cursorOnTable)
            {
                while (x <= boxWidth)
                {
                    e.Graphics.DrawLine(dotlinepen, x, cursorY, x + lineLength, cursorY);
                    x += 2 * lineLength;
                }
            }
            ////


            // draw division
            Pen divPen = new Pen(Color.FromArgb(25, 94, 102, 115));
            y = 0;
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(divPen, 0, y, boxWidth, y);
                y += linesStepVolume;
            }

            int stockWidth = boxWidth / visibleData.Count - 1;
            x = stockWidth / 2;
            for (int i = 0; i < visibleData.Count; i += linesStepTime, x += (stockWidth + 1) * linesStepTime)
                e.Graphics.DrawLine(divPen, x, 0, x, boxHeight);
            ////
        }

        private void pictureBox_BottomChart_MouseMove(object sender, MouseEventArgs e)
        {
            // stock highlight
            visibleData.ForEach(sd => sd.CurrentColor = sd.InitColor);

            int stockWidth = pictureBox_WorkTable.Width / visibleData.Count - 1;
            int index = e.X / (stockWidth + indent);
            selectedIndex = index + leftIndex;

            if (selectedIndex <= rightIndex && selectedIndex >= leftIndex)
                stockData[selectedIndex].CurrentColor = stockData[selectedIndex].SelectedColor;
            ////

            cursorX = index * (stockWidth + indent) + stockWidth / 2;
            cursorY = e.Y;
            cursorOnTable = false;

            RefreshPictureBoxes();
        }

        private void pictureBox_BottomChart_MouseLeave(object sender, EventArgs e)
        {
            cursorX = -10;
            cursorY = -10;

            RefreshPictureBoxes();
        }

        private void pictureBox_PriceScale_Paint(object sender, PaintEventArgs e)
        {
            // draw marks
            int boxWidth = pictureBox_PriceScale.Width;
            int boxHeight = pictureBox_PriceScale.Height;
            double maxPrice = visibleData.Max(sd => sd.High);
            double minPrice = visibleData.Min(sd => sd.Low);

            float step = boxHeight / tableMarksCount;
            float y = step;
            Color markColor = Color.FromArgb(94, 102, 115);
            int windowHeight = boxHeight - topLevel - bottomLevel;
            float invRate = (float)((maxPrice - minPrice) / windowHeight);
            for (int i = 0; i < tableMarksCount; i++)
            {
                double markValue = invRate * (boxHeight - bottomLevel - y);
                int intLen = ((int)markValue).ToString().Length;
                int decimals = intLen > 9 ? 1 : 10 - intLen;
                markValue = Math.Round(markValue, decimals) + minPrice;

                e.Graphics.DrawLine(new Pen(markColor), 0, y, 5, y);
                e.Graphics.DrawString(markValue.ToString(), new Font("Arial", 8), new SolidBrush(markColor), 7, y - 6);
                y += step;
            }

            // draw cursor mark
            if (cursorOnTable)
            {
                double cursorMarkValue = invRate * (boxHeight - bottomLevel - cursorY);
                int intLen = ((int)cursorMarkValue).ToString().Length;
                int decimals = intLen > 9 ? 1 : 10 - intLen;
                cursorMarkValue = Math.Round(cursorMarkValue, decimals) + minPrice;

                Color textBackColor = Color.FromArgb(43, 49, 57);
                Color textColor = Color.White;

                // draw text background
                e.Graphics.FillRectangle(new SolidBrush(textBackColor), 0, cursorY - 8, boxWidth, 16);

                // draw text
                e.Graphics.DrawString(cursorMarkValue.ToString(), new Font("Arial", 8),
                    new SolidBrush(textColor), 12, cursorY - 8);
            }
            ////
        }

        private void pictureBox_PriceScale_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left == MouseButtons)
            {
                int step = 2;
                if (e.Y > cursorY && pictureBox_WorkTable.Height - bottomLevel - topLevel >= 50)
                {
                    topLevel += step;
                    bottomLevel += step;
                }
                else
                {
                    topLevel -= step;
                    bottomLevel -= step;
                }

                cursorY = e.Y;
            }

            RefreshPictureBoxes();
        }

        private void pictureBox_BottomChartScale_Paint(object sender, PaintEventArgs e)
        {
            // draw marks
            const int marksCount = 4;
            int boxWidth = pictureBox_BottomChartScale.Width;
            int boxHeight = pictureBox_BottomChartScale.Height;
            float step = boxHeight / marksCount;
            float y = step;
            linesStepVolume = step;
            Color markColor = Color.FromArgb(94, 102, 115);
            while (y <= boxHeight)
            {
                e.Graphics.DrawLine(new Pen(markColor), 0, y, 5, y);
                y += step;
            }
            ////


            // draw cursor mark
            if (!cursorOnTable)
            {
                int maxVolume = stockData.Max(sd => sd.Volume);
                int volumeMaxHeight = 50;
                float invRate = (float)(maxVolume / volumeMaxHeight);
                double cursorMarkValue = Math.Round(invRate * (boxHeight - cursorY), 3);

                Color textBackColor = Color.FromArgb(43, 49, 57);
                Color textColor = Color.White;

                // draw text background
                e.Graphics.FillRectangle(new SolidBrush(textBackColor), 0, cursorY - 8,
                    boxWidth, 16);

                // draw text
                e.Graphics.DrawString(cursorMarkValue.ToString(), new Font("Arial", 8),
                    new SolidBrush(textColor), 12, cursorY - 8);
            }
            ////
        }

        private void pictureBox_DateTime_Paint(object sender, PaintEventArgs e)
        {
            // draw marks
            int marksCount = 10;
            int step = visibleData.Count / marksCount;
            int stockWidth = pictureBox_DateTime.Width / visibleData.Count - 1;
            linesStepTime = step;

            int x = stockWidth / 2;
            Color markColor = Color.FromArgb(94, 102, 115);
            for (int i = 0; i < visibleData.Count; i += step, x += (stockWidth + indent) * step)
            {
                // draw mark
                e.Graphics.DrawLine(new Pen(markColor), x, 0, x, 5);

                string label;
                if (timeFrame == "M" || timeFrame == "W" || timeFrame == "D")
                {
                    label = visibleData[i].Date.Substring(4, 4).Insert(2, "/");
                }
                else
                {
                    label = visibleData[i].Time.Substring(0, 4).Insert(2, ":");
                }

                // draw text
                e.Graphics.DrawString(label, new Font("Arial", 7), new SolidBrush(markColor), x - 10, 5);
            }
            ////
        }

        private void pictureBox_TimeFrame_Paint(object sender, PaintEventArgs e)
        {
            Color textColor = Color.FromArgb(94, 102, 115);
            e.Graphics.DrawString(timeFrame, new Font("Arial", 10), new SolidBrush(textColor), 5, 5);
        }
    }
}
