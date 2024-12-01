public class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine()
                           .Split(' ')
                           .Select(int.Parse)
                           .ToArray();

        string factorInput = Console.ReadLine();
        int factor = int.Parse(factorInput);

        MultiplyElements(ref arr, factor);

        Console.WriteLine(string.Join(" ", arr));
    }

    static void MultiplyElements(ref int[] array, int factor)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] *= factor;
        }
    }
}
