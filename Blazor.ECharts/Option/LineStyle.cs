using Blazor.ECharts.Option.Enum;

namespace Blazor.ECharts.Option
{
    public class LineStyle : AreaStyle
    {

        /// <summary>
        /// 线宽。
        /// </summary>
        public double? Width { set; get; }

        /// <summary>
        /// 线的类型。
        /// </summary>
        public LineStyleType? Type { set; get; }

    }
}
