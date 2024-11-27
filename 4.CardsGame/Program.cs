List<int> firstDeck = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

List<int> secondDeck = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToList();

Queue<int> firstPlayer = new Queue<int>(firstDeck);
Queue<int> secondPlayer = new Queue<int>(secondDeck);

while (firstPlayer.Count > 0 && secondPlayer.Count > 0)
{
    int firstCard = firstPlayer.Dequeue();
    int secondCard = secondPlayer.Dequeue();

    if (firstCard > secondCard)
    {   
        firstPlayer.Enqueue(firstCard);
        firstPlayer.Enqueue(secondCard);
    }
    else if (firstCard < secondCard)
    {
        secondPlayer.Enqueue(secondCard);
        secondPlayer.Enqueue(firstCard);
    }
    else
    {
        continue;
    }
}

if (firstPlayer.Count > 0)
{
    int totalSum = firstPlayer.Sum();
    Console.WriteLine($"First player wins! Sum: {totalSum}");
}
else
{
    int totalSum = secondPlayer.Sum();
    Console.WriteLine($"Second player wins! Sum: {totalSum}");
}