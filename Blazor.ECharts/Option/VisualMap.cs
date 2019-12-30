using Blazor.ECharts.Option.Enum;
using System.Collections.Generic;

namespace Blazor.ECharts.Option
{
    public class VisualMapPiecewise
    {
        /// <summary>
        /// visualMap 组件离容器上侧的距离。top 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比，也可以是 'top', 'middle', 'bottom'。
        /// </summary>
        public object Top { set; get; }

        /// <summary>
        /// visualMap 组件离容器右侧的距离。。right 的值可以是像 20 这样的具体像素值，可以是像 '20%' 这样相对于容器高宽的百分比。
        /// </summary>
        public object Right { set; get; }

        /// <summary>
        /// 自定义『分段式视觉映射组件（visualMapPiecewise）』的每一段的范围，以及每一段的文字，以及每一段的特别的样式。
        /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#visualMap-piecewise.pieces">此处</see>查看详细设置</para>
        /// </summary>
        public List<object> Pieces { set; get; }

        /// <summary>
        /// 定义 在选中范围外 的视觉元素。（用户可以和 visualMap 组件交互，用鼠标或触摸选择范围）
        /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#visualMap-piecewise.outOfRange">此处</see>查看详细设置</para>
        /// </summary>
        public OutOfRange OutOfRange { set; get; }
    }
    public class OutOfRange
    {
        /// <summary>
        /// 图元的颜色。
        /// </summary>
        public object Color { set; get; }
    }
}
