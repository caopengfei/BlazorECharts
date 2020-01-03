using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Rakor.Blazor.ECharts.Option;
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
        public static ValueTask SetupChart<T>(this IJSRuntime jsRuntime,string id, EChartsOption<T> option)
        {
            try
            {
                if (option == null) return new ValueTask();
                return jsRuntime.InvokeVoidAsync("setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings));
            }
            catch (Exception exp)
            {
                Console.Error.WriteLine($"Error while setting up chart: {exp.Message}");
            }
            return new ValueTask();
        }
        public static ValueTask UpdateChart(this IJSRuntime jsRuntime, string id, object option)
        {
            try
            {
                if (option == null) return new ValueTask();
                return jsRuntime.InvokeVoidAsync("setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings));
            }
            catch (Exception exp)
            {
                Console.Error.WriteLine($"Error while setting up chart: {exp.Message}");
            }
            return new ValueTask();
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
            if (string.IsNullOrWhiteSpace(str)) throw new InvalidOperationException("不能为空");
            if (!str.StartsWith("function")) throw new InvalidOperationException("格式不正确");
            return new JRaw(str);
        }
    }
}
