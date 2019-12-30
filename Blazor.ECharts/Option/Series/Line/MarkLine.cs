using System.Collections.Generic;

namespace Blazor.ECharts.Option.Series.Line
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
        public List<MarkLineData> Data { set; get; }
    }
    public class MarkLineData
    { 
        public object YAxis { set; get; }
    }
}
