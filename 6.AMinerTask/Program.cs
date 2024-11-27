
Dictionary<string, long> resources = new Dictionary<string, long>();

string line;
int lineCounter = 1;

while ((line = Console.ReadLine()) != "stop")
{
    if (lineCounter % 2 != 0)
    {
        string resource = line;
        long quantity = long.Parse(Console.ReadLine());

        if (resources.ContainsKey(resource))
        {
            resources[resource] += quantity;
        }
        else
        {
            resources[resource] = quantity;
        }
    }

    lineCounter+= 2;
}

foreach (var resource in resources)
{
    Console.WriteLine($"{resource.Key} -> {resource.Value}");
}
