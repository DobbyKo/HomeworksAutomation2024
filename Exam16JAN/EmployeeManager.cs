using Newtonsoft.Json;

namespace Exam16JAN
{
    public class EmployeeManager
    {
        private List<Employee> employees;
        private readonly string filePath = "employees.json";

        public EmployeeManager()
        {
            employees = LoadEmployees();
        }

        public void AddEmployee(Employee employee)
        {
            if (!employees.Any(e => e.FullName == employee.FullName))
            {
                employees.Add(employee);
                Console.WriteLine("Employee added successfully.");
            }
            else
            {
                Console.WriteLine("Duplicate employee name. Employee not added.");
            }
        }

        public void RemoveEmployee(string fullName)
        {
            var employee = employees.FirstOrDefault(e => e.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
            if (employee != null)
            {
                employees.Remove(employee);
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void UpdateSalary(string fullName, decimal newSalary)
        {
            var employee = employees.FirstOrDefault(e => e.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
            if (employee != null)
            {
                employee.UpdateSalary(newSalary);
                Console.WriteLine("Salary updated successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void AddDepartment(string fullName, string department)
        {
            var employee = employees.FirstOrDefault(e => e.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));
            if (employee != null)
            {
                employee.AddDepartment(department);
                Console.WriteLine("Department added successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void SaveEmployees()
        {
            var jsonData = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine("Employee data saved to file.");
        }

        private List<Employee> LoadEmployees()
        {
            if (File.Exists(filePath))
            {
                var jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Employee>>(jsonData) ?? new List<Employee>();
            }
            return new List<Employee>();
        }
    }

}
