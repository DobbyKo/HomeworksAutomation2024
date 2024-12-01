
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter an integer: ");
        string input = Console.ReadLine();
        int num = int.Parse(input);

        GenerateFibonacchiSeq(num);
    }

    private static void GenerateFibonacchiSeq(int num)
    {
        if (num <= 0)
        {
            Console.WriteLine("Please enter a positive integer greater than 0.");
            return;
        }

        int[] seq = new int[num];

        for (int i = 0; i < num; i++)
        {
            if (i == 0)
            {
                seq[i] = 0; 
            }
            else if (i == 1)
            {
                seq[i] = 1;
            }
            else
            {
                seq[i] = seq[i - 1] + seq[i - 2];
            }
        }

        Console.WriteLine("Fibonacci Sequence:");
        for (int i = 0; i < seq.Length; i++)
        {
            Console.Write(seq[i] + " ");
        }
    }
}
