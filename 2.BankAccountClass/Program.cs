using _2.BankAccountClass;

public class Program
{
    static void Main()
    {
        try
        {
            string accountName = Console.ReadLine();
            decimal balance = decimal.Parse(Console.ReadLine());

            BankAccount bankAccount = new BankAccount(accountName, balance);

            string operation = Console.ReadLine();

            while (operation != "stop")
            {
                if (operation == "deposit")
                {
                    decimal depositAmount = decimal.Parse(Console.ReadLine());
                    bankAccount.Deposit(depositAmount);
                }
                else if (operation == "withdraw")
                {
                    decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                    bankAccount.Withdraw(withdrawAmount);
                }
                else
                {
                    Console.WriteLine("Invalid operation! Try again!");
                }

                operation = Console.ReadLine();
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
