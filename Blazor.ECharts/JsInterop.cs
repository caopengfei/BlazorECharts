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
                if (model == null) return new ValueTask();
                //var data = JsonConvert.SerializeObject(model, Formatting.None, JsonSerializerSettings);
                //Console.WriteLine(data);
                object Tooltip_Position = null;
                if (model.Tooltip != null && model.Tooltip.Position != null && model.Tooltip.Position.ToString().Contains("function"))
                {
                    //Tooltip_Position = new Newtonsoft.Json.Linq.JRaw(model.Tooltip.Position.ToString());
                    Tooltip_Position = model.Tooltip.Position.ToString();
                    model.Tooltip.Position = null;
                }
                return jsRuntime.InvokeVoidAsync("setupChart", 
                    id, 
                    JsonConvert.SerializeObject(model, Formatting.None, JsonSerializerSettings),
                    Tooltip_Position);
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
