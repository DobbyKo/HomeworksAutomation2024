using Newtonsoft.Json;

namespace Exam16JAN
{
    public class FileService
    {
        private const string FilePath = "employees.json";

        public static void SaveToFile(List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        public static List<Employee> LoadFromFile()
        {
            if (!File.Exists(FilePath))
                return new List<Employee>();

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>();
        }
    }
}
