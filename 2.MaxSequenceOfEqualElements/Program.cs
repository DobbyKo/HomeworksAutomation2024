

int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();

int longestStartIndex = 0;
int longestLength = 1;

int currentStartIndex = 0;
int currentLength = 1;

for (int i = 1; i < arr.Length; i++)
{
    if (arr[i] == arr[i - 1]) 
    {
        currentLength++;
    }
    else 
    {
        if (currentLength > longestLength)
        {
            longestLength = currentLength;
            longestStartIndex = currentStartIndex;
        }
        currentStartIndex = i; 
        currentLength = 1; 
    }
}

if (currentLength > longestLength)
{
    longestLength = currentLength;
    longestStartIndex = currentStartIndex;
}

for (int i = longestStartIndex; i < longestStartIndex + longestLength; i++)
{
    Console.Write(arr[i] + " ");
}
