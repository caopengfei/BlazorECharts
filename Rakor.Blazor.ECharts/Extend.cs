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
        public static async Task InitChart(this IJSRuntime jsRuntime, string id)
        {
            if(string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.initChart", id);
        }
        public static async Task SetupChart(this IJSRuntime jsRuntime,string id, object option,bool notMerge=false)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (option == null) throw new ArgumentNullException("echarts参数不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings), notMerge);
        }
        public static async Task UpdateChart(this IJSRuntime jsRuntime, string id, object option)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (option == null) throw new ArgumentNullException("echarts参数不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings));
        }
        public static async Task ExecFuncAsync(this IJSRuntime jsRuntime, string id, string func)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentNullException("echarts控件id不能为空");
            if (string.IsNullOrWhiteSpace(func)) throw new ArgumentNullException("方法不能为空");
            await jsRuntime.InvokeVoidAsync("echartsFunctions.execFunc", id, func);
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
