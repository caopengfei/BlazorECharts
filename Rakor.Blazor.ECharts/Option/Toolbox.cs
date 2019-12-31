namespace Rakor.Blazor.ECharts.Option
{
    /// <summary>
    /// 工具栏。内置有导出图片，数据视图，动态类型切换，数据区域缩放，重置五个工具。
    /// </summary>
    public class Toolbox
    {
        /// <summary>
        /// 各工具配置项。
        /// </summary>
        public Feature Feature { set; get; }
        
        /// <summary>
        /// 工具栏组件离容器左侧的距离。
        /// <para>点击<see href="https://www.echartsjs.com/zh/option.html#toolbox.left">此处</see>查看详细设置</para>
        /// </summary>
        public object Left { set; get; }
    }

    /// <summary>
    /// 各工具配置项。
    /// </summary>
    public class Feature
    {
        /// <summary>
        /// 保存为图片。
        /// </summary>
        public SaveAsImage SaveAsImage { set; get; }

        /// <summary>
        /// 配置项还原。
        /// </summary>
        public Restore Restore { set; get; }

        /// <summary>
        /// 数据区域缩放。目前只支持直角坐标系的缩放。
        /// </summary>
        public FeatureDataZoom DataZoom { set; get; }
    }

    /// <summary>
    /// 保存为图片
    /// </summary>
    public class SaveAsImage
    {
        /// <summary>
        /// 保存的文件名称，默认使用 title.text 作为名称。
        /// </summary>
        public string Name { set; get; }
    }

    /// <summary>
    /// 配置项还原。
    /// </summary>
    public class Restore
    {

    }

    /// <summary>
    /// 数据区域缩放。目前只支持直角坐标系的缩放。
    /// </summary>
    public class FeatureDataZoom
    {
        /// <summary>
        /// 指定哪些 yAxis 被控制。如果缺省则控制所有的y轴。如果设置为 false 则不控制任何y轴。如果设置成 3 则控制 axisIndex 为 3 的y轴。如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的y轴。
        /// </summary>
        public object YAxisIndex { set; get; }
    }
}
