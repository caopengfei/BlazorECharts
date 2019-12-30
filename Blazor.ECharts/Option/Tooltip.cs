using Blazor.ECharts.Option.Enum;

namespace Blazor.ECharts.Option
{
    /// <summary>
    /// 提示框组件。
    /// </summary>
    public class Tooltip
    {
        /// <summary>
        /// 是否显示提示框组件，包括提示框浮层和 axisPointer
        /// </summary>
        public bool? Show { set; get; }

        /// <summary>
        /// 触发类型。
        /// </summary>
        public TooltipTrigger? Trigger { set; get; }

        /// <summary>
        /// 坐标轴指示器配置项。
        /// </summary>
        public TooltipAxisPointer AxisPointer { set; get; }

        /// <summary>
        /// 提示框浮层的位置，默认不设置时位置会跟随鼠标的位置。
        /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#tooltip.position">此处</see>查看详细设置</para>
        /// </summary>
        public object Position { set; get; }
    }
}
