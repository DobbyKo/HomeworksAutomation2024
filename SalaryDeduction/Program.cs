
Console.WriteLine("Enter the number of open tabs:");
int openTabsNum = int.Parse(Console.ReadLine());

if (openTabsNum < 1 || openTabsNum > 10)
{
    Console.WriteLine("Invalid input!");
    return;
}

Console.WriteLine("Enter the salary:");
double salary = double.Parse(Console.ReadLine());

if (salary < 700 || salary > 1500)
{
    Console.WriteLine("Invalid input!");
    return;
}

for (int i = 0; i < openTabsNum; i++)
{
    string site = Console.ReadLine();

    int fineAmount = 0;

    switch (site)
    {
        case "Facebook": fineAmount = 150;
            break;
        case "Instagram": fineAmount = 100;
            break;
        case "Reddit": fineAmount = 50;
            break;
        default:
            Console.WriteLine("Invalid site!");
            return;
    }

    salary -= fineAmount;

    if (salary <= 0)
    {
        Console.WriteLine("You have lost your salary.");
        return;
    }
    else
    {
        Console.WriteLine(salary);
    }
}
