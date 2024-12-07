using System.Transactions;
using _1.CreateAProductClass;

public class Program
{
    static void Main()
    {
        Product product = new Product();

        Console.Write("Enter a product: ");
        product.Name = Console.ReadLine();

        Console.Write("Enter the price: ");
        product.Price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter the quantity: ");
        product.Quantity = int.Parse(Console.ReadLine());

        decimal totalPrice = product.CalculateTotalCost();

        Console.WriteLine($"The total price is: {totalPrice}");
    }
}
