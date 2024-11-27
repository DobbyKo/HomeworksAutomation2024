
string input = Console.ReadLine();

Dictionary<char, int> charCounts = new Dictionary<char, int>();

foreach (char c in input)
{
    if (c != ' ') 
    {
        if (charCounts.ContainsKey(c))
        {
            charCounts[c]++;
        }
        else
        {
            charCounts[c] = 1;
        }
    }
}

foreach (var entry in charCounts)
{
    Console.WriteLine($"{entry.Key} -> {entry.Value}");
}
