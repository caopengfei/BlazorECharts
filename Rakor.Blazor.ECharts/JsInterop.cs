using Microsoft.JSInterop;
using Newtonsoft.Json;
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
}
