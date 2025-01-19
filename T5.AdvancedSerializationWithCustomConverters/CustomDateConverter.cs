using System.Globalization;
using Newtonsoft.Json;

namespace T5.AdvancedSerializationWithCustomConverters
{
    public class CustomDateConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string dateString = reader.Value.ToString();
            return DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }
    }
}