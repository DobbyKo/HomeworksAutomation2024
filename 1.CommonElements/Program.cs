

string firstInput = Console.ReadLine();
string secondInput = Console.ReadLine();

List<string> firstList = new List<string>(firstInput.Split(' '));
List<string> secondList = new List<string>(secondInput.Split(' '));
List<string> finalList = new List<string>();

foreach (string word in secondList)
{
    if (firstList.Contains(word))
    {
        Console.Write(word + " ");
        firstList.Remove(word);
    }
}
