
string radiusAsString = Console.ReadLine();

double radius = double.Parse(radiusAsString);

double area = Math.PI *  radius * radius;

string formattedArea = area.ToString("F2");

Console.WriteLine(formattedArea);

//Console.WriteLine($"{area:f2}"); - this is option if skip formattedArea