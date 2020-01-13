using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading.Tasks;

namespace Rakor.Blazor.ECharts
{
    public static class JsInterop
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        /// <summary>
        /// 初始化Echarts
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <returns></returns>
        public static async Task InitChart(this IJSRuntime jsRuntime, string id)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.initChart", id);
        }
        /// <summary>
        /// 显示Echarts加载样式
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <returns></returns>
        public static async Task ShowLoadingChart(this IJSRuntime jsRuntime, string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.showLoading", id);
        }
        /// <summary>
        /// 隐藏Echarts加载样式
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <returns></returns>
        public static async Task HideLoadingChart(this IJSRuntime jsRuntime, string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.hideLoding", id);
        }
        /// <summary>
        /// 配置Echarts参数
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <param name="option">参数</param>
        /// <param name="notMerge">可选，是否不跟之前设置的 option 进行合并，默认为 false，即合并。</param>
        /// <returns></returns>
        public static async Task SetupChart(this IJSRuntime jsRuntime,string id, object option,bool notMerge=false)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (option == null) throw new ArgumentNullException("echarts参数不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings), notMerge);
        }
        /// <summary>
        /// 更新Echarts参数
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <param name="option">参数</param>
        /// <returns></returns>
        public static async Task UpdateChart(this IJSRuntime jsRuntime, string id, object option)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (option == null) throw new ArgumentNullException("echarts参数不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings));
        }
        /// <summary>
        /// 执行Echarts中的方法
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <param name="func">方法数据</param>
        /// <returns></returns>
        public static async Task ExecFuncAsync(this IJSRuntime jsRuntime, string id, string func,bool prefix=true)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (string.IsNullOrWhiteSpace(func)) throw new ArgumentNullException("方法不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.execFunc", id, func,prefix);
        }
        /// <summary>
        /// Echarts注册可用的地图
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="id">ECharts容器ID</param>
        /// <param name="url">Json地址</param>
        /// <param name="name">地图名称，在 geo 组件或者 map 图表类型中设置的 map 对应的就是该值。</param>
        /// <param name="_callback">成功后的回调方法</param>
        /// <returns></returns>
        public static async Task RegisterMapAsync(this IJSRuntime jsRuntime, string id,string url, string name="map", object _callback=null)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("json数据地址不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.registerMap", id, name, url, _callback);
        }
    }

    public static class StringExt
    {
        /// <summary>
        /// 将字符串转换为 javascript function 对象
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static JRaw ToJRaw(this string str) 
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException("不能为空");
            //if (!str.StartsWith("function")) throw new InvalidOperationException("格式不正确");
            return new JRaw(str);
        }
        public static string ToLower(this string str,int len) 
        {
            if (string.IsNullOrWhiteSpace(str)) return str;
            if (len >= str.Length) return str.ToLower();
            return str.Substring(0,len).ToLower() + str.Substring(len);
        }
    }
}
