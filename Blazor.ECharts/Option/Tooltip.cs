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
        public AxisPointer AxisPointer { set; get; }
    }
}
