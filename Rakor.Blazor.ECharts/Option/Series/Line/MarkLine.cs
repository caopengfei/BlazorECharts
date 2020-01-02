using Rakor.Blazor.ECharts.Option.Enum;
using System.Collections.Generic;

namespace Rakor.Blazor.ECharts.Option.Series.Line
{
    /// <summary>
    /// 图表标线。
    /// </summary>
    public class MarkLine
    {
        /// <summary>
        /// 图形是否不响应和触发鼠标事件，默认为 false，即响应和触发鼠标事件。
        /// </summary>
        public bool? Silent { set; get; }

        /// <summary>
        /// 标线的数据数组。
        /// </summary>
        public List<object> Data { set; get; }
    }
    public class MarkLineData
    { 
        public string Name { set; get; }

        public object YAxis { set; get; }

        public object X { set; get; }

        public string Symbol { set; get; }

        public Sampling? Type { set; get; }

        public MarkLineDataLabel Label { set; get; }
    }

    public class MarkLineDataLabel
    {
        /// <summary>
        /// 标签位置
        /// </summary>
        public Location? Position { set; get; }

        /// <summary>
        /// 标签内容格式器，支持字符串模板和回调函数两种形式，字符串模板与回调函数返回的字符串均支持用 \n 换行。
        /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#series-line.markLine.data.1.label.formatter">此处</see>查看详细设置</para>
        /// </summary>
        public object Formatter { set; get; }
    }
}
