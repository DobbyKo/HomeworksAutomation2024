using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

namespace T1.ParseAndExtractData
{
    public class Program
    {
        static void Main(string[] args)
        {
            string jsonData = @"
                {
                    ""departments"": [
                        {
                            ""name"": ""Engineering"",
                            ""employees"": [
                                { ""name"": ""Alice"", ""age"": 30, ""skills"": [""C#"", ""SQL""] },
                                { ""name"": ""Bob"", ""age"": 35, ""skills"": [""Java"", ""AWS""] }
                            ]
                        },
                        {
                            ""name"": ""HR"",
                            ""employees"": [
                                { ""name"": ""Charlie"", ""age"": 28, ""skills"": [""Recruitment"", ""Communication""] },
                                { ""name"": ""Diana"", ""age"": 32, ""skills"": [""Onboarding"", ""Training""] }
                            ]
                        }
                    ]
            }";

            JObject jsonObject = JObject.Parse(jsonData);

            List<JToken> engineeringEmployeeNames = jsonObject.SelectTokens("$.departments[?(@.name=='Engineering')].employees[*].name").ToList();

            Console.WriteLine("Employee names in Engineering department:");

            foreach (var name in engineeringEmployeeNames)
            {
                Console.WriteLine(name);
            }

            List<JToken> allSkills = jsonObject.SelectTokens("$.departments[*].employees[*].skills[*]").ToList();
            List<string> uniqueSkills = allSkills.Select(skill => skill.ToString()).Distinct().ToList();

            Console.WriteLine("\nUnique skills across all employees:");

            foreach (var skill in uniqueSkills)
            {
                Console.WriteLine(skill);
            }

            var employeesOver30 = jsonObject
                .SelectTokens("$.departments[*]")
                .SelectMany(dept => dept["employees"]
                    .Where(emp => (int)emp["age"] > 30)
                    .Select(emp => new
                    {
                        Departament = dept["name"].ToString(),
                        EmployeeName = emp["name"].ToString()
                    }))
                .ToList();

            Console.WriteLine("\nEmployees older than 30:");

            foreach (var emp in employeesOver30)
            {
                Console.WriteLine($"Department: {emp.Departament}, Employee: {emp.EmployeeName}");
            }
        }
    }
}
