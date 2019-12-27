using Blazor.ECharts.Option.Enum;

namespace Blazor.ECharts.Option
{
    public class TextStyle
    {
        /// <summary>
        /// 主标题文字的颜色。
        /// </summary>
        public string Color { set; get; }

        /// <summary>
        /// 主标题文字字体的风格
        /// </summary>
        public FontStyle? FontStyle { set; get; }

        /// <summary>
        /// 主标题文字字体的粗细
        /// <para>使用  FontWeight 枚举或者数字，如100、200、300、400...</para>
        /// </summary>
        public object FontWeight { set; get; }

        /// <summary>
        /// 主标题文字的字体系列
        /// </summary>
        public string FontFamily { set; get; }

        /// <summary>
        /// 主标题文字的字体大小
        /// </summary>
        public int? FontSize { set; get; }

        /// <summary>
        /// 行高。
        /// <para>rich 中如果没有设置 lineHeight，则会取父层级的 lineHeight</para>
        /// </summary>
        public int? LineHeight { set; get; }

        /// <summary>
        /// 文字块的宽度。一般不用指定，不指定则自动是文字的宽度。在想做表格项或者使用图片（参见 backgroundColor）时，可能会使用它。
        /// <para>详细设置见：https://www.echartsjs.com/zh/option.html#title.textStyle.width </para>
        /// </summary>
        public object Width { set; get; }

        /// <summary>
        /// 文字块的高度。一般不用指定，不指定则自动是文字的高度。在使用图片（参见 backgroundColor）时，可能会使用它。
        /// <para>详细设置见：https://www.echartsjs.com/zh/option.html#title.textStyle.height </para>
        /// </summary>
        public object Height { set; get; }

        /// <summary>
        /// 文字本身的描边颜色。
        /// </summary>
        public string TextBorderColor { set; get; }

        /// <summary>
        /// 文字本身的描边宽度。
        /// </summary>
        public int? TextBorderWidth { set; get; }

        /// <summary>
        /// 文字本身的阴影颜色。
        /// </summary>
        public string TextShadowColor { set; get; }

        /// <summary>
        /// 文字本身的阴影长度。
        /// </summary>
        public int? TextShadowBlur { set; get; }

        /// <summary>
        /// 文字本身的阴影 X 偏移。
        /// </summary>
        public int? TextShadowOffsetX { set; get; }

        /// <summary>
        /// 文字本身的阴影 Y 偏移。
        /// </summary>
        public int? TextShadowOffsetY { set; get; }

        /// <summary>
        /// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
        /// <para>详细设置见：https://www.echartsjs.com/zh/option.html#title.textStyle.rich </para>
        /// </summary>
        public object Rich { set; get; }
    }
}
