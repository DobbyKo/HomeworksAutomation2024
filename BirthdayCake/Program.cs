
Console.WriteLine("Enter the cake width:");
int cakeWidth = int.Parse(Console.ReadLine());

if (cakeWidth < 1 || cakeWidth > 1000)
{
    Console.WriteLine("Invalid input!");
    return;
}

Console.WriteLine("Enter the cake length:");
int cakeLength = int.Parse(Console.ReadLine());

if (cakeLength < 1 || cakeLength > 1000)
{
    Console.WriteLine("Invalid input!");
    return;
}

int totalPieces = cakeWidth * cakeLength;

int takenPieces = 0;

while (true)
{
    string input = Console.ReadLine();

    if (input == "STOP")
    {
        if (totalPieces > 0)
        {
            Console.WriteLine($"{totalPieces} pieces are left.");
        }
        else
        {
            Console.WriteLine("No more cake left!");
        }
        break;
    }

    int piecesTaken = int.Parse(input);

    totalPieces -= piecesTaken;

    if (totalPieces <= 0)
    {
        Console.WriteLine($"No more cake left! You need {-totalPieces} pieces more.");
        break;
    }
}