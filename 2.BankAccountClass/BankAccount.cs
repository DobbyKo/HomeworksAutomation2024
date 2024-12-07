
namespace _2.BankAccountClass
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, decimal balance) 
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposit(decimal moneyToAdd)
        {
            if (moneyToAdd <= 0)
            {
                throw new ArgumentException("The deposit should be greater than 0!");
            }
            else
            {
                Balance += moneyToAdd;

                Console.WriteLine($"The Balance after the deposit is: {Balance}");
            }
        }

        public void Withdraw(decimal moneyToWithdraw)
        {
            if (moneyToWithdraw <= 0)
            {
                throw new ArgumentException("Withdrawal amount should be greater than 0!");
            }
            if (moneyToWithdraw > Balance)
            {
                throw new InvalidOperationException("No enough money!");
            }
            Balance -= moneyToWithdraw;
            Console.WriteLine($"The Balance after withdraw is: {Balance}");
        }
    }
}
