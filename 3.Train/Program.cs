
List<int> wagons = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

int maxCapacity = int.Parse(Console.ReadLine());

string currentInput;

while ((currentInput = Console.ReadLine()) != "end")
{
    string[] inputParts = currentInput.Split(' ');

    if (inputParts[0] == "Add")
    {
        int newWagon = int.Parse(inputParts[1]);

        wagons.Add(newWagon);
    }
    else
    {
        int peopleToAdd = int.Parse(inputParts[0]);

        for (int i = 0; i < wagons.Count; i++)
        {
            if (wagons[i] + peopleToAdd <= maxCapacity)
            {
                wagons[i] += peopleToAdd;
                break;
            }
        }
    }
}

Console.WriteLine(string.Join(" ", wagons));
