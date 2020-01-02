using Rakor.Blazor.ECharts.Option.Enum;
using System.Collections.Generic;

namespace Rakor.Blazor.ECharts.Option.Series
{
    /// <summary>
    /// 图表标注。
    /// </summary>
    public class MarkPoint
    {

        /// <summary>
        /// 标注的数据数组。每个数组项是一个对象，有下面几种方式指定标注的位置。
        /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#series-line.markPoint.data">此处</see>查看详细设置</para>
        /// </summary>
        public List<MarkPointData> Data { set; get; }
    }
    /// <summary>
    /// 标注的数据数组。每个数组项是一个对象，有下面几种方式指定标注的位置。
    /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#series-line.markPoint.data">此处</see>查看详细设置</para>
    /// </summary>
    public class MarkPointData
    {
        /// <summary>
        /// 标注名称。
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 特殊的标注类型，用于标注最大值最小值等。
        /// </summary>
        public MarkPointDataType? Type { set; get; }

        /// <summary>
        /// 标注值，可以不设。
        /// </summary>
        public int? Value { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int? XAxis { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int? YAxis { set; get; }
    }
}
