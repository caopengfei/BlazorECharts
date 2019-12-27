using Blazor.ECharts.Option.Enum;

namespace Blazor.ECharts.Option
{
    public class HandleStyle:AreaStyle
    {
        /// <summary>
        /// 图形的描边颜色。支持的颜色格式同 color，不支持回调函数。
        /// <para>详细设置见：https://www.echartsjs.com/zh/option.html#dataZoom-slider.handleStyle.borderColor </para>
        /// </summary>
        public object BorderColor { set; get; }

        /// <summary>
        /// 描边线宽。为 0 时无描边。
        /// </summary>
        public int? BorderWidth { set; get; }

        /// <summary>
        /// 柱条的描边类型，默认为实线，支持 'solid', 'dashed', 'dotted'。
        /// </summary>
        public LineStyleType? BorderType { set; get; }


    }
}
