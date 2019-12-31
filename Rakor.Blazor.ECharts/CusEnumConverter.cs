using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Rakor.Blazor.ECharts
{
    public class CustomEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            writer.WriteValue(value.ToString().ToLower());
        }
    }
}
