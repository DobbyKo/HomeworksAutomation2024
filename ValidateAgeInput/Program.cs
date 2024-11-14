
string ageInput = Console.ReadLine();

if (int.TryParse(ageInput, out int age))
{
    Console.WriteLine($"Your age is: {age}");
}
else
{
    Console.WriteLine("Invalid age entered.");
}
