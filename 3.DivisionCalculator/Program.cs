public class Program
{
    static void Main()
    {
        try
        {

            Console.Write("Enter dividend: ");
            int dividend = int.Parse(Console.ReadLine());

            Console.Write("Enter divisor: ");
            int divisor = int.Parse(Console.ReadLine());

            int result = DivideNumbers(dividend, divisor);

            Console.WriteLine($"The result is: {result}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Error: Cannot divide by zero!");
        }
    }

    public static int DivideNumbers(int dividend, int divisor)
    {
        return dividend / divisor;
    }
}
