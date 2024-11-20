/*Tony and his friends love fishing so much that they decide to go on a fishing trip with a boat. 
 * The rental price of the boat depends on the season and the number of fishermen.
The price depends on the season:
- In spring, the boat rental costs 3000 BGN.
- In summer and autumn, the boat rental costs 4200 BGN.
- In winter, the boat rental costs 2600 BGN.
Depending on their group size, the group receives a discount:
- If the group consists of up to 6 people (inclusive) – a 10% discount.
- If the group consists of 7 to 11 people (inclusive) – a 15% discount.
- If the group consists of 12 or more people – a 25% discount.
Additionally, the fishermen receive a further 5% discount if their number is even, except in autumn, 
where no additional discount is applied. This discount is applied after the group discount.

Write a program that calculates whether the fishermen can gather enough money.  
The program should read exactly three lines from the console:
1. Group budget – an integer in the range [1…8000].
2. Season – text: `"Spring"`, `"Summer"`, `"Autumn"`, `"Winter"`.
3. Number of fishermen – an integer in the range [4…18].*/

using System.Transactions;

Console.WriteLine("Enter the group budget:");
int groupBudget = int.Parse(Console.ReadLine());

Console.WriteLine("Enter a season (options are: Spring, Summer, Autumn, Winter");
string season = Console.ReadLine();

Console.WriteLine("Enter the number of fishermen:");
int fishermenNum = int.Parse(Console.ReadLine());

double rentalPrice = 0;
double discount = 0;
double totalSpends = 0;

if ((groupBudget >= 1 && groupBudget <= 8000) && (fishermenNum >= 4 && fishermenNum <= 18))
{
    switch (season)
    {
        case "Spring":
            rentalPrice = 3000;
            break;
        case "Summer":
        case "Autumn":
            rentalPrice = 4200;
            break;
        case
        "Winter":
            rentalPrice = 2600;
            break;
        default:
            Console.WriteLine("Invalid season.");
            return;
    }

    if (fishermenNum <= 6)
    {
        discount = 0.10;
    }
    else if (fishermenNum >= 7 && fishermenNum <= 11)
    {
        discount = 0.15;
    }
    else
    {
        discount = 0.25;
    }

    if (fishermenNum % 2 == 0 && season != "Autumn")
    {
        totalSpends = rentalPrice - (rentalPrice * discount * 0.05);
    }
    else
    {
        totalSpends = rentalPrice - (rentalPrice * discount);
    }

    if (groupBudget >= totalSpends)
    {
        Console.WriteLine($"Yes! You have {(groupBudget - totalSpends):F2} BGN left.");
    }
    else
    {
        Console.WriteLine($"Not enough money! You need {(totalSpends - groupBudget):F2} BGN more.");
    }
}
else
{
    Console.WriteLine("Invalid input!");
    return;
}