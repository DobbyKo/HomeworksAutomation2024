

Console.WriteLine("Enter the type of screening (Premiere, Normal, Discount):");

string ticketType = Console.ReadLine().ToLower();

double ticketTypePrice = 0;

if (ticketType == "premiere")
{
    ticketTypePrice = 12.0;
}
else if (ticketType == "normal")
{
    ticketTypePrice = 7.50;
}
else if (ticketType == "discount")
{
    ticketTypePrice = 5.0;
}
else
{
    Console.WriteLine("Invalid ticket's type! Start again!");
}

Console.WriteLine("Enter the number of rows:");
int rowsNum = int.Parse(Console.ReadLine());

Console.WriteLine("Enter the number of columns:");
int columnsNum = int.Parse(Console.ReadLine());

double totalRevenue = ticketTypePrice * rowsNum * columnsNum;

Console.WriteLine($"Total revenue: {totalRevenue:f2} BGN");


