using Rakor.Blazor.ECharts.Option.Enum;

namespace Rakor.Blazor.ECharts.Option.Series.Pie
{
    public class Label
    {
        /// <summary>
        /// 
        /// </summary>
        public bool? Show { set; get; }

        /// <summary>
        /// 标签的位置。
        /// </summary>
        public PieLabelPosition? Position { set; get; }

        /// <summary>
        /// 高亮的扇区和标签样式。
        /// </summary>
        public Emphasis Emphasis { set; get; }
    }
}
