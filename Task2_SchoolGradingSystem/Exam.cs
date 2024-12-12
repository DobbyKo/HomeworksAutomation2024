
namespace Task2_SchoolGradingSystem
{
    public class Exam : IGradeCalculator
    {
        public double MaxMarks { get; set; }
        public double MarksObtained { get; set; }

        public Exam(double maxMarks, double marksObtained)
        {
            MaxMarks = maxMarks;
            MarksObtained = marksObtained;
        }

        public double CalculateGrade()
        {
            if (MaxMarks == 0)
            {
                return 0; 
            }

            return (MarksObtained / MaxMarks) * 100;
        }
    }
}
