
int n = int.Parse(Console.ReadLine());
if (n < 1 || n > 9)
{
    Console.WriteLine("Invalid input");
    return;
}

int l = int.Parse(Console.ReadLine());
if (l < 1 || l > 9)
{
    Console.WriteLine("Invalid input");
    return;
}

var passwords = new List<string>();

for (int d1 = 0; d1 < n; d1++)
{
    for (int d2 = 0; d2 < n; d2++)
    {
        for (int c1 = 0; c1 < l; c1++)
        {
            for (int c2 = 0; c2 < l; c2++)
            {
                for (int d3 = 0; d3 < n; d3++)
                {
                    if (d3 > d1 && d3 > d2)
                    {
                        string password = $"{d1}{d2}{(char)('a' + c1)}{(char)('a' + c2)}{d3}";
                        passwords.Add(password);
                    }
                }
            }
        }
    }
}

Console.WriteLine(string.Join(" ", passwords));
