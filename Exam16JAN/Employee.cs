
namespace Exam16JAN
{
    public class Employee
    {
        public string FullName { get; set; }
        public Country Country { get; set; }
        public List<string> AssignedDepartments { get; set; } = new List<string>();
        public decimal Salary { get; set; }

        public Employee(string fullName, Country country, decimal salary)
        {
            FullName = fullName;
            Country = country;
            Salary = salary;
        }

        public void AddDepartment(string department)
        {
            if (!AssignedDepartments.Contains(department))
            {
                AssignedDepartments.Add(department);
            }
        }

        public void UpdateSalary(decimal newSalary)
        {
            if (newSalary > 0)
            {
                Salary = newSalary;
            }
        }
    }
}
