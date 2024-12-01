

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please, enter a string: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty or just whitespace. Please enter a valid string.");
            return;
        }

        List<char> word = input.ToList();
        ReverseAString(word);
    }

    private static void ReverseAString(List<char> word)
    {
        List<char> result = new List<char>();

        for (int i = word.Count - 1; i >= 0; i--)
        {
            result.Add(word[i]); 
        }

        Console.WriteLine(new string(result.ToArray()));
    }
}