public class Program
{
    static void Main()
    {
        Console.Write("Enter number: ");
        string input1 = Console.ReadLine();
        int mainNum = int.Parse(input1);

        Console.Write("Enter divisor: ");
        string input2 = Console.ReadLine();
        int divisor = int.Parse(input2);

        int quotient;
        int remainder;

        CalculateResult(mainNum, divisor, out quotient, out remainder);

        Console.WriteLine($"Dividend: {mainNum}, Divisor: {divisor}");
        Console.WriteLine($"Quotient: {quotient}, Remainder: {remainder}");
    }

    static void CalculateResult(int mainNum, int divisor, out int quotient, out int remainder)
    {
        quotient = mainNum / divisor;
        remainder = mainNum % divisor;
    }
}
