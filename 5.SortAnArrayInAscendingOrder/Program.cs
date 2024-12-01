public class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine()
                           .Split(", ")
                           .Select(int.Parse)
                           .ToArray();

        SortTheArray(arr);

        Console.WriteLine(string.Join(", ", arr));
    }

    static void SortTheArray(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}
