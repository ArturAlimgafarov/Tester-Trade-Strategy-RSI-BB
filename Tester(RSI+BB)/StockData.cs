using System.Drawing;

namespace Tester_RSI_BB_
{
    class StockData
    {
        public string Date;
        public string Time;
        public double Open;
        public double Close;
        public double High;
        public double Low;
        public int Volume;

        public Color InitColor;
        public Color CurrentColor;
        public Color SelectedColor;

        public StockData(string date, string time, double open, double close, double high, double low, int volume)
        {
            Date = date;
            Time = time;
            Open = open;
            Close = close;
            High = high;
            Low = low;
            Volume = volume;

            InitColor = open < close ? Color.FromArgb(130, 0, 255, 0) : Color.FromArgb(150, 255, 0, 0);
            SelectedColor = open < close ? Color.Lime : Color.Red;
            CurrentColor = InitColor;
        }
    }
}
