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
        public static ValueTask InitChart(this IJSRuntime jsRuntime, string id)
        {
            try
            {
                return jsRuntime.InvokeVoidAsync("initChart", id);
            }
            catch (Exception exp)
            {
                Console.Error.WriteLine($"Error while init chart: {exp.Message}");
            }
            return new ValueTask();
        }
        public static ValueTask SetupChart(this IJSRuntime jsRuntime,string id, object option,bool notMerge=false)
        {
            try
            {
                if (option == null) return new ValueTask();
                return jsRuntime.InvokeVoidAsync("setupChart", id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings), notMerge);
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
        public static async Task ExecFuncAsync(this IJSRuntime jsRuntime, string id, string func) 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(func)) return;
                await jsRuntime.InvokeVoidAsync("execFunc", id, func);
            }
            catch (Exception exp)
            {
                Console.Error.WriteLine($"执行自定义javascript方法出错:\n方法体：{func}\n错误信息： {exp.Message}\n错误堆栈：{exp.StackTrace}");
            }
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
