namespace T2.ComplexObjectSerializationAndDeserialization
{
    public class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Dobby Ko",
                    Employer = new Company
                    {
                        Name = "BF",
                        Location = new Address { Street = "123 Tech Blvd", City = "Sofia" }
                    },
                    Skills = new List<string> { "C#", "SQL", "Azure" }
                },
                new Employee
                {
                    Id = 2,
                    Name = "John Doe",
                    Employer = new Company
                    {
                        Name = "Google",
                        Location = new Address { Street = "456 Web St", City = "Seattle" }
                    },
                    Skills = new List<string> { "JavaScript", "React", "Node.js" }
                },
                new Employee
                {
                    Id = 3,
                    Name = "Sheldon Cupper",
                    Employer = new Company
                    {
                        Name = "Apple",
                        Location = new Address { Street = "789 Design Ave", City = "Pasadena" }
                    },
                    Skills = new List<string> { "Photoshop", "Illustrator", "UI/UX Design" }
                }
            };

            var jsonData = System.Text.Json.JsonSerializer.Serialize(employees);

            var deserializedEmployees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(jsonData);

            foreach (var employee in deserializedEmployees)
            {
                Console.WriteLine($"Name: {employee.Name}");
                Console.WriteLine($"Company: {employee.Employer.Name}, {employee.Employer.Location.Street}, {employee.Employer.Location.City}");
                Console.WriteLine("Skills: " + string.Join(", ", employee.Skills));
                Console.WriteLine();
            }

            var specificCity = deserializedEmployees
            .Where(e => e.Employer.Location.City == "Sofia")
            .Select(e => e.Name)
            .ToList();

            Console.WriteLine("Employees in Sofia:");

            foreach (var name in specificCity)
            {
                Console.WriteLine(name);
            }
        }
    }
}
