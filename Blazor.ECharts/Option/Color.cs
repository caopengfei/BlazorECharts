using Newtonsoft.Json;
using Blazor.ECharts.Option.Enum;

namespace Blazor.ECharts.Option
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

        public ColorStops[] ColorStops { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public bool? Global { set; get; }
    }

    /// <summary>
    /// 渐变类型
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum ColorType
    {
        /// <summary>
        /// 线性渐变，前四个参数分别是 x0, y0, x2, y2, 范围从 0 - 1，相当于在图形包围盒中的百分比，如果 globalCoord 为 `true`，则该四个值是绝对的像素位置
        /// </summary>
        Linear,
        /// <summary>
        /// 径向渐变，前三个参数分别是圆心 x, y 和半径，取值同线性渐变
        /// </summary>
        Radial
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