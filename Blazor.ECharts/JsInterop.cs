using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Blazor.ECharts.Option;
using System;
using System.Threading.Tasks;

namespace Blazor.ECharts
{
    public static class JsInterop
    {
        //private const string JsInteropName = "ECharts";
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public static ValueTask SetupChart<T>(this IJSRuntime jsRuntime,string id, EChartsOption<T> model)
        {
            try
            {
                //var data = JsonConvert.SerializeObject(model, Formatting.None, JsonSerializerSettings);
                //Console.WriteLine(data);
                return jsRuntime.InvokeVoidAsync("setupChart", id, JsonConvert.SerializeObject(model, Formatting.None, JsonSerializerSettings));
                //return jsRuntime.InvokeVoidAsync("setupChart", id, model);
            }
            catch (Exception exp)
            {
                Console.Error.WriteLine($"Error while setting up chart: {exp.Message}");
            }
            return new ValueTask();
        }
        public static ValueTask UpdateChart<T>(this IJSRuntime jsRuntime, string id, EChartsOption<T> model)
        {
            return SetupChart(jsRuntime, id, model);
        }
    }
}
