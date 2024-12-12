
namespace Task3_E_CommerceSystem
{
    public abstract class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Product Name: {Name}");
            Console.WriteLine($"Original Price: {Price:C}");
            Console.WriteLine($"Discounted Price: {GetDiscountedPrice():C}");
            Console.WriteLine();
        }

        public abstract decimal GetDiscountedPrice();
    }
}
