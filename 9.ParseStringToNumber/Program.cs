public class Program
{
    static void Main()
    {
        Console.Write("Enter input: ");
        string input = Console.ReadLine();

        int result = TryConvertToInt(input);

        Console.WriteLine(result);
    }

    static int TryConvertToInt(string input)
    {
        int result;
        
        if (int.TryParse(input, out result))
        {
            return result;  
        }
        else
        {
            return 0; 
        }
    }
}
