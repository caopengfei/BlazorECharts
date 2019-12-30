using Newtonsoft.Json;

namespace Blazor.ECharts.Option.Enum
{
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Align
    {
        Auto,
        Left,
        Right,
        Center
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Align1
    {
        Auto,
        Left,
        Right
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Align2
    {
        Left,
        Right,
        Center
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum VerticalAlign
    {
        Top,
        Middle,
        Bottom
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum AxisType
    {
        /// <summary>
        /// 数值轴，适用于连续数据。
        /// </summary>
        Value,
        /// <summary>
        /// 类目轴，适用于离散的类目数据，为该类型时必须通过 data 设置类目数据
        /// </summary>
        Category,
        /// <summary>
        /// 时间轴，适用于连续的时序数据，与数值轴相比时间轴带有时间的格式化，在刻度计算上也有所不同，例如会根据跨度的范围来决定使用月，星期，日还是小时范围的刻度。
        /// </summary>
        Time,
        /// <summary>
        /// 对数轴。适用于对数数据。
        /// </summary>
        Log
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Location
    {
        Start,
        Middle,
        End
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum PositionY
    {
        Start,
        End
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum PositionX
    {
        Top,
        Bottom
    }

    /// <summary>
    /// 指示器的坐标轴。
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum AxisPointerAxis
    {
        X,
        Y,
        Radius,
        Angle
    }

    /// <summary>
    /// 指示器类型。
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum AxisPointerType
    {
        /// <summary>
        /// 直线指示器
        /// </summary>
        Line,
        /// <summary>
        /// 阴影指示器
        /// </summary>
        Shadow,
        /// <summary>
        /// 无指示器
        /// </summary>
        None,
        /// <summary>
        /// 十字准星指示器。其实是种简写，表示启用两个正交的轴的 axisPointer。
        /// </summary>
        Cross
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum TooltipTrigger
    {
        /// <summary>
        /// 数据项图形触发，主要在散点图，饼图等无类目轴的图表中使用。
        /// </summary>
        Item,
        /// <summary>
        /// 坐标轴触发，主要在柱状图，折线图等会使用类目轴的图表中使用。
        /// <para>支持在直角坐标系和极坐标系上的所有类型的轴。并且可以通过 axisPointer.axis 指定坐标轴。</para>
        /// </summary>
        Axis,
        /// <summary>
        /// 什么都不触发。
        /// </summary>
        None
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum CoordinateSystem
    {
        /// <summary>
        /// 使用二维的直角坐标系（也称笛卡尔坐标系），通过 xAxisIndex, yAxisIndex指定相应的坐标轴组件。
        /// </summary>
        Cartesian2d,
        /// <summary>
        /// 使用极坐标系，通过 polarIndex 指定相应的极坐标组件
        /// </summary>
        Polar
    }

    /// <summary>
    /// 图形区域的起始位置
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Origin
    {
        /// <summary>
        /// 填充坐标轴轴线到数据间的区域
        /// </summary>
        Auto,
        /// <summary>
        /// 填充坐标轴底部（非 inverse 情况是最小值）到数据间的区域
        /// </summary>
        Start,
        /// <summary>
        ///  填充坐标轴顶部（非 inverse 情况是最大值）到数据间的区域
        /// </summary>
        End
    }

    /// <summary>
    /// 平铺类型
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum FillColorRepeat
    {
        [JsonProperty("repeat-x")]
        RepeatX,
        [JsonProperty("repeat-y")]
        RepeatY,
        [JsonProperty("no-repeat")]
        NoRepeat
    }

    /// <summary>
    /// 指定窗口打开主标题超链接。
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Target
    {
        /// <summary>
        /// 当前窗口打开
        /// </summary>
        Self,
        /// <summary>
        ///  新窗口打开
        /// </summary>
        Blank
    }

    /// <summary>
    /// 主标题文字字体的风格
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum FontStyle
    {
        /// <summary>
        /// 
        /// </summary>
        Normal,
        Italic,
        Oblique
    }

    /// <summary>
    /// 主标题文字字体的粗细
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum FontWeight
    {
        Normal,
        Bold,
        Bolder,
        Lighter
    }

    /// <summary>
    /// 图例的类型
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum LegendType
    {
        /// <summary>
        /// 普通图例。缺省就是普通图例。
        /// </summary>
        plain,
        /// <summary>
        /// 可滚动翻页的图例。当图例数量较多时可以使用。
        /// </summary>
        scroll
    }

    /// <summary>
    /// 布局朝向。
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Orient
    {
        /// <summary>
        /// 
        /// </summary>
        Horizontal,
        /// <summary>
        /// 
        /// </summary>
        Vertical
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum SelectorPosition
    {
        /// <summary>
        /// 
        /// </summary>
        Start,
        End
    }

    /// <summary>
    /// dataZoom 的运行原理是通过 数据过滤 来达到 数据窗口缩放 的效果。数据过滤模式的设置不同，效果也不同。
    /// </summary>
    [JsonConverter(typeof(CustomEnumConverter))]
    public enum FilterMode 
    {
        Filter,
        WeakFilter,
        Empty,
        None
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum RangeMode
    {
        Value,
        Percent
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum LineStyleType
    {
        Solid,
        Dashed,
        Dotted
    }

    [JsonConverter(typeof(CustomEnumConverter))]
    public enum Sampling
    {
        /// <summary>
        /// 取过滤点的平均值
        /// </summary>
        Average,
        /// <summary>
        /// 取过滤点的最大值
        /// </summary>
        Max,
        /// <summary>
        /// 取过滤点的最小值
        /// </summary>
        Min,
        /// <summary>
        ///  取过滤点的和
        /// </summary>
        Sum
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
}
