public class Program
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        string input1 = Console.ReadLine();
        int firstNum = int.Parse(input1);

        Console.Write("Enter second number: ");
        string input2 = Console.ReadLine();
        int secondNum = int.Parse(input2);

        Swap(ref firstNum, ref secondNum);

        Console.WriteLine($"Swapped numbers: num1 = {firstNum} and num2 = {secondNum}");
    }

    static void Swap(ref int firstNum, ref int secondNum)
    {
        int temp = firstNum;
        firstNum = secondNum;
        secondNum = temp;
    }
}
