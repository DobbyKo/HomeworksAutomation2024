namespace Task2_SchoolGradingSystem
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Enter Max Score: ");
                string maxScoreAsString = Console.ReadLine();
                double maxScore = double.Parse(maxScoreAsString);  

                Console.Write("Enter Score Achieved: ");
                string scoreAchievedAsString = Console.ReadLine();
                double scoreAchieved = double.Parse(scoreAchievedAsString); 

                IGradeCalculator assignment = new Assignment(maxScore, scoreAchieved);

                Console.Write("Enter Max Marks: ");
                string maxMarksAsString = Console.ReadLine();
                double maxMarks = double.Parse(maxMarksAsString);  

                Console.Write("Enter Marks Obtained: ");
                string marksObtainedAsString = Console.ReadLine();
                double marksObtained = double.Parse(marksObtainedAsString);  

                IGradeCalculator exam = new Exam(maxMarks, marksObtained);

                List<IGradeCalculator> gradeCalculators = new List<IGradeCalculator>
            {
                assignment,
                exam
            };

                foreach (var item in gradeCalculators)
                {
                    Console.WriteLine($"{item.GetType().Name} Grade: {item.CalculateGrade():F2}%");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Invalid input! Please enter valid numeric values. Details: {ex.Message}");
            }
        }
    }
}