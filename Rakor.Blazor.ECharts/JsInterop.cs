using Microsoft.JSInterop;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Rakor.Blazor.ECharts.Option;
using System;
using System.Collections.Generic;
using System.Linq;
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
                List<JSFun> list = new List<JSFun>();
                Reset(option, list);
                //var data = JsonConvert.SerializeObject(model, Formatting.None, JsonSerializerSettings);
                //Console.WriteLine(data);
                //object Tooltip_Position = null;
                //if (option.Tooltip != null && option.Tooltip.Position != null && option.Tooltip.Position.ToString().Contains("function"))
                //{
                //    //Tooltip_Position = new Newtonsoft.Json.Linq.JRaw(model.Tooltip.Position.ToString());
                //    Tooltip_Position = option.Tooltip.Position.ToString();
                //    option.Tooltip.Position = null;
                //}
                //return jsRuntime.InvokeVoidAsync("setupChart", 
                //    id, 
                //    JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings),
                //    Tooltip_Position);
                return jsRuntime.InvokeVoidAsync("setupChart",id, JsonConvert.SerializeObject(option, Formatting.None, JsonSerializerSettings), list);
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
        public static ValueTask InitChart(this IJSRuntime jsRuntime, string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return new ValueTask();
                return jsRuntime.InvokeVoidAsync("initChart", id);
            }
            catch (Exception exp)
            {
                Console.Error.WriteLine($"Error while init up chart: {exp.Message}");
            }
            return new ValueTask();
        }
        private static void Reset(object option, List<JSFun> list) 
        {
            if (option == null) return;
            var properties=option.GetType().GetProperties().Where(p => p.GetIndexParameters().Length == 0);
            foreach (var item in properties)
            {
                //var type = item.PropertyType;
                //var name = item.Name;
                //Console.WriteLine($"{name}的类型是{type.FullName}");
                var value = item.GetValue(option);
                if (value != null)
                {
                    if (value.GetType() == typeof(string) && value.ToString().StartsWith("function"))
                    {
                        //Console.WriteLine($"{name}的值是{value.ToString()}");
                        item.SetValue(option,null);
                        list.Add(new JSFun($"{item.DeclaringType?.Name}.{item.Name}".ToLower(), value.ToString()));
                    }
                    if (item.PropertyType != typeof(string) && item.PropertyType.BaseType!=null) Reset(value, list);
                }
            }
        }
        public class JSFun 
        {
            public string Name { set; get; }
            public string Action { set; get; }
            public JSFun(string name,string action) 
            {
                Name = name;
                Action = action;
            }
        }
    }
}
