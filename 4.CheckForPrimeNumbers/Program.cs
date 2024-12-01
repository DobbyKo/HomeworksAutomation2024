public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please, enter a number: ");
        string input = Console.ReadLine();
        int num = int.Parse(input);

        if (IsPrime(num) == true)
        {
            Console.WriteLine("true (prime)");
        }
        else
        {
            Console.WriteLine("false (not prime)");
        }
    }

    public static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        if (number == 2)
            return true;

        if (number % 2 == 0)
            return false;

        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}
