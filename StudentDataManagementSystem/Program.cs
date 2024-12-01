namespace StudentDataManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<double>>> students =
                new Dictionary<string, Dictionary<string, List<double>>>();

            int selection = 0;

            while (selection != 6)
            {
                selection = PrintTheOptionsAndMakeSelection();

                if (selection >= 1 && selection <= 6)
                {
                    if (selection == 1)
                    {
                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();
                        ValidateTheInput(studentName);
                        AddNewStudent(students, studentName);
                    }
                    else if (selection == 2)
                    {
                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();
                        ValidateTheInput(studentName);
                        RemoveStudent(students, studentName);
                    }
                    else if (selection == 3)
                    {
                        Console.Write("Enter student name and subject (in format: John-Math): ");
                        string[] studentData = Console.ReadLine().Split('-');
                        if (studentData.Length == 2)
                        {
                            string studentName = studentData[0];
                            string subject = studentData[1];
                            ValidateTheInput(studentName);
                            ValidateTheInput(subject);
                            AssignStudentToSubject(students, studentName, subject);
                        }
                        else
                        {
                            Console.WriteLine("Invalid format! Please use 'Name-Subject'.");
                        }
                    }
                    else if (selection == 4)
                    {
                        Console.Write("Enter student name: ");
                        string studentName = Console.ReadLine();
                        ValidateTheInput(studentName);
                        Console.Write("Enter subject and grade (in format: Math-5): ");
                        string[] studentData = Console.ReadLine().Split('-');

                        if (studentData.Length == 2 && double.TryParse(studentData[1], out double grade))
                        {
                            string subject = studentData[0];
                            ValidateTheInput(subject);
                            ValidateTheInput(grade);
                            AddGradeToSubject(students, studentName, subject, grade);
                        }
                        else
                        {
                            Console.WriteLine("Invalid format! Please use 'Subject-Grade'.");
                        }
                    }
                    else if (selection == 5)
                    {
                        DisplayAllStudents(students);
                    }
                    else if (selection == 6)
                    {
                        Console.WriteLine("Exiting the system. Goodbye!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Try again");
                }
            }
        }

        static void DisplayAllStudents(Dictionary<string, Dictionary<string, List<double>>> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No added students yet! Try again with another option!");
            }

            foreach (var student in students)
            {
                string studentName = student.Key;
                var subjects = student.Value;

                string result = $"{studentName}: ";

                List<string> subjectInfo = new List<string>();

                foreach (var subject in subjects)
                {
                    string subjectName = subject.Key;
                    List<double> grades = subject.Value;

                    double averageGrade = grades.Count > 0 ? grades.Average() : 0;
                    averageGrade = Math.Min(6, Math.Max(2, averageGrade));

                    subjectInfo.Add($"{subjectName}: {averageGrade:F2}");
                }

                result += string.Join(", ", subjectInfo);

                Console.WriteLine(result);
            }
        }

        static void AddGradeToSubject(Dictionary<string, Dictionary<string, List<double>>> students, string studentName, string subject, double grade)
        {
            if (students.ContainsKey(studentName) && students[studentName].ContainsKey(subject))
            {
                students[studentName][subject].Add(grade);
            }
            else
            {
                Console.WriteLine("The student doesn't have such subject! Try with another option.");
            }
        }

        static void AssignStudentToSubject(Dictionary<string, Dictionary<string, List<double>>> students, string studentName, string subject)
        {
            if (!students.ContainsKey(studentName))
            {
                Console.WriteLine("There is no such student! Try again!");
            }
            else if (students.ContainsKey(studentName) && CheckTheSubject(subject))
            {
                students[studentName].Add(subject, new List<double>());
                Console.WriteLine($"Student {studentName} has successfully enrolled in the {subject} class.");
            }
            else
            {
                Console.WriteLine("Invalid subject! Try again!");
            }
        }

        static int PrintTheOptionsAndMakeSelection()
        {
            List<string> options = new List<string>()
            {
                "1. Add a new student",
                "2. Remove a student",
                "3. Assign student to subject",
                "4. Update a student's grades",
                "5. Display all students",
                "6. Exit"
            };

            Console.WriteLine("Choose an option:");
            Console.WriteLine(string.Join(Environment.NewLine, options));
            Console.Write("Enter your choice: ");
            int selection;

            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
            {
                Console.WriteLine("Invalid input! Please choose a number between 1 and 6.");
            }
            return selection;
        }

        static void ValidateTheInput(object input)
        {
            if (input is string subject)
            {
                if (string.IsNullOrWhiteSpace(subject))
                {
                    Console.WriteLine("Invalid input! Try again");
                }
            }
            else if (input is double grade)
            {
                if (grade < 2 || grade > 6)
                {
                    Console.WriteLine("Invalid input! Try again");
                }
            }
        }

        static bool CheckTheSubject(string input)
        {
            HashSet<string> subjects = new HashSet<string>()
                {
                    "Math", "Biology", "History", "English", "Sport", "Physics"
                };

            return subjects.Contains(input);
        }

        static void AddNewStudent(Dictionary<string, Dictionary<string, List<double>>> students, string studentName)
        {
            if (students.ContainsKey(studentName))
            {
                Console.WriteLine("Student already exists.");
            }
            else
            {
                students.Add(studentName, new Dictionary<string, List<double>>());
                Console.WriteLine($"Student {studentName} added successfully.");
            }
        }

        static void RemoveStudent(Dictionary<string, Dictionary<string, List<double>>> students, string studentName)
        {
            if (students.ContainsKey(studentName))
            {
                students.Remove(studentName);
                Console.WriteLine($"Student {studentName} removed successfully.");
            }
            else
            {
                Console.WriteLine("Student doesn't exist.");
            }
        }
    }
}
