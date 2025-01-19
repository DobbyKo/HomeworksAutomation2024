
using Newtonsoft.Json;

namespace SplitAJSONFileByKey
{
    public class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"../../../transactions.json";
            string creditFilePath = @"../../../credits.json";
            string debitFilePath = @"../../../debits.json";

            List<Transaction> transactions = ReadTransactionsFromFile(inputFilePath);

            var creditTransactions = transactions.Where(t => t.Type == "credit").ToList();
            var debitTransactions = transactions.Where(t => t.Type == "debit").ToList();

            WriteTransactionsToFile(creditTransactions, creditFilePath);
            WriteTransactionsToFile(debitTransactions, debitFilePath);

            decimal totalCreditAmount = creditTransactions.Sum(t => t.Amount);
            decimal totalDebitAmount = debitTransactions.Sum(t => t.Amount);

            Console.WriteLine($"Total Credit Amount: {totalCreditAmount:C}");
            Console.WriteLine($"Total Debit Amount: {totalDebitAmount:C}");
        }

        static List<Transaction> ReadTransactionsFromFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Transaction>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
                return new List<Transaction>();
            }
        }

        static void WriteTransactionsToFile(List<Transaction> transactions, string filePath)
        {
            try
            {
                string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                File.WriteAllText(filePath, json);

                string[] splitFileName = filePath.Split("/");
                string fileName = splitFileName[splitFileName.Length - 1];

                Console.WriteLine($"Transactions written to {fileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
