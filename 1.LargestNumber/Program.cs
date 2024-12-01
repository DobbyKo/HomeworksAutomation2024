using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter an array of integers, separated by spaces:");

        string[] input = Console.ReadLine().Split(' ').ToArray();

        var numbers = new System.Collections.Generic.List<int>();

        foreach (var item in input)
        {
            if (int.TryParse(item, out int num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter only integers separated by spaces.");
                return; 
            }
        }

        int[] arr = numbers.ToArray();

        int? largest = FindLargestNumber(arr);

        if (largest.HasValue)
        {
            Console.WriteLine($"The largest number is: {largest.Value}");
        }
        else
        {
            Console.WriteLine("The array is empty.");
        }
    }

    public static int? FindLargestNumber(int[] arr)
    {
        if (arr.Length == 0)
        {
            return null; 
        }

        if (arr.All(num => num < 0))
        {
            Console.WriteLine("All numbers are negative.");
        }

        return arr.Max();
    }
}
