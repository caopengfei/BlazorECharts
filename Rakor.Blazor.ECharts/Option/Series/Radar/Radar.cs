using System.Collections.Generic;

namespace Rakor.Blazor.ECharts.Option.Series.Radar
{
    public class Radar : SeriesBase
    {
        public Radar() : base("radar") { }

        public List<object> Data { set; get; }

        public LineStyle LineStyle { set; get; }

        public object Symbol { set; get; }

        public ItemStyle ItemStyle { set; get; }

        public AreaStyle AreaStyle { set; get; }
    }
}
