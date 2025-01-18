using System;
using System.Collections.Generic;

namespace Exam16JAN
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var apiClient = new CountryService();
            var employeeManager = new EmployeeManager();
            var countries = apiClient.GetCountries();

            Console.WriteLine("Fetching list of countries...");
            foreach (var country in countries)
            {
                Console.WriteLine($"- {country.Name.Common}");
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nEmployee Management Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Assign Department");
                Console.WriteLine("4. Update Salary");
                Console.WriteLine("5. Save Data");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddEmployee(employeeManager, countries);
                        break;
                    case "2":
                        RemoveEmployee(employeeManager);
                        break;
                    case "3":
                        AssignDepartment(employeeManager);
                        break;
                    case "4":
                        UpdateSalary(employeeManager);
                        break;
                    case "5":
                        employeeManager.SaveEmployees();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddEmployee(EmployeeManager employeeManager, List<Country> countries)
        {
            Console.Write("Enter employee full name: ");
            var fullName = Console.ReadLine();

            Console.Write("Enter salary: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary <= 0)
            {
                Console.WriteLine("Invalid salary input.");
                return;
            }

            Console.WriteLine("Select a country:");
            for (int i = 0; i < countries.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {countries[i].Name.Common}");
            }

            Console.Write("Enter country number: ");
            if (int.TryParse(Console.ReadLine(), out int countryIndex) && countryIndex > 0 && countryIndex <= countries.Count)
            {
                var selectedCountry = countries[countryIndex - 1];
                var employee = new Employee(fullName, selectedCountry, salary);
                employeeManager.AddEmployee(employee);
            }
            else
            {
                Console.WriteLine("Invalid country selection.");
            }
        }

        static void RemoveEmployee(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee full name to remove: ");
            var fullName = Console.ReadLine();
            employeeManager.RemoveEmployee(fullName);
        }

        static void AssignDepartment(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee full name to assign department: ");
            var fullName = Console.ReadLine();

            Console.Write("Enter department name: ");
            var department = Console.ReadLine();

            employeeManager.AddDepartment(fullName, department);
        }

        static void UpdateSalary(EmployeeManager employeeManager)
        {
            Console.Write("Enter employee full name to update salary: ");
            var fullName = Console.ReadLine();

            Console.Write("Enter new salary: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal newSalary) && newSalary > 0)
            {
                employeeManager.UpdateSalary(fullName, newSalary);
            }
            else
            {
                Console.WriteLine("Invalid salary input.");
            }
        }
    }

}