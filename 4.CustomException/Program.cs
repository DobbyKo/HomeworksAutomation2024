using _4.CustomException;

public class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the age: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine(ValidateAge(age));
        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    static string ValidateAge(int age)
    {
        if (age < 0 || age > 150)
        {
            throw new InvalidAgeException();
        }
        else
        {
            return "Age is valid";
        }
    }
}
