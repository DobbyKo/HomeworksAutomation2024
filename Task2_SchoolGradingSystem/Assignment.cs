
namespace Task2_SchoolGradingSystem
{
    public class Assignment : IGradeCalculator
    {
        public double MaxScore { get; set; }
        public double ScoreAchieved { get; set; }

        public Assignment(double maxScore, double scoreAchieved)
        {
            MaxScore = maxScore;
            ScoreAchieved = scoreAchieved;
        }

        public Assignment()
        {
        }

        public double CalculateGrade()
        {
            if (MaxScore == 0)
            {
                return 0;
            }

            return (ScoreAchieved / MaxScore) * 100;
        }
    }
}
