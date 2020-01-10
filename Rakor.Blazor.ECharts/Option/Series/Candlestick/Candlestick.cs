using System.Collections.Generic;

namespace Rakor.Blazor.ECharts.Option.Series.Candlestick
{
    public class Candlestick : SeriesBase
    {
        public Candlestick() : base("candlestick") { }

        public ItemStyle ItemStyle { set; get; }

        public Tooltip Tooltip { set; get; }

        public MarkLine MarkLine { set; get; }

        public MarkPoint MarkPoint { set; get; }

        public object Data { set; get; }
    }
}
