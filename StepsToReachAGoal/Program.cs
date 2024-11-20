
int dailyGoal = 10000;
int totalSteps = 0;
int stepsRemaining = 0;
string input = Console.ReadLine();

while (input != "Going home")
{ 
    int steps = int.Parse(input);
    totalSteps += steps;

    if (totalSteps >= dailyGoal)
    {
        Console.WriteLine("Goal reached! Good job!");
        return;
    }

    input = Console.ReadLine();
}

if (input == "Going home")
{
    Console.WriteLine("Enter the number of steps taken while heading home:");
    int homeSteps = int.Parse(Console.ReadLine());
    totalSteps += homeSteps;

    if (totalSteps < dailyGoal)
    {
        stepsRemaining = dailyGoal - totalSteps;
        Console.WriteLine($"{stepsRemaining} more steps to reach goal.");
    }
    else
    {
        Console.WriteLine("Goal reached! Good job!");
    }
}