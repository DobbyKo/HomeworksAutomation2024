using Newtonsoft.Json;

namespace T5.AdvancedSerializationWithCustomConverters
{
    public class Program
    {
        static void Main(string[] args)
        {
            var events = new List<Event>
            {
                new Event { Date = new DateTime(2025, 3, 15), Name = "Spring Conference" },
                new Event { Date = new DateTime(2025, 7, 20), Name = "Summer Festival" }
            };

            var settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new CustomDateConverter() },
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(events, settings);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(json);

            var deserializedEvents = JsonConvert.DeserializeObject<List<Event>>(json, settings);

            Console.WriteLine("\nDeserialized Events:");
            foreach (var ev in deserializedEvents)
            {
                Console.WriteLine($"Name: {ev.Name}, Date: {ev.Date.ToString("yyyy-MM-dd")}");
            }
        }
    }
}
