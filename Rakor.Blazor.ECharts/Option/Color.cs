using Rakor.Blazor.ECharts.Option.Enum;
using System.Collections.Generic;

namespace Rakor.Blazor.ECharts.Option
{
    #region 渐变色
    /// <summary>
    /// 渐变色。
    /// </summary>
    public class GradationColor
    {
        /// <summary>
        /// 渐变类型
        /// </summary>
        public ColorType? Type { set; get; }

        /// <summary>
        /// 范围从 0 - 1
        /// </summary>
        public double? X { set; get; }

        /// <summary>
        /// 范围从 0 - 1
        /// </summary>
        public double? Y { set; get; }

        /// <summary>
        /// 范围从 0 - 1
        /// </summary>
        public double? X2 { set; get; }

        /// <summary>
        /// 范围从 0 - 1
        /// </summary>
        public double? Y2 { set; get; }

        public List<ColorStops> ColorStops { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Global { set; get; }
    }

    public class ColorStops
    {
        /// <summary>
        /// 颜色，例：red
        /// </summary>
        public string Color { set; get; }

        public double? Offset { set; get; }
    }
    #endregion

    #region 纹理填充
    public class FillColor
    {
        /// <summary>
        /// 支持为 HTMLImageElement, HTMLCanvasElement，不支持路径字符串
        /// </summary>
        public object Image { set; get; }

        /// <summary>
        /// 是否平铺, 可以是 'repeat-x', 'repeat-y', 'no-repeat'
        /// </summary>
        public FillColorRepeat? Repeat { set; get; }
    }
    #endregion
}