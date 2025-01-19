
namespace ProductInventoryManagement
{
    public class InventoryMenu
    {
        private InventoryManager manager;
        public InventoryMenu()
        {
            manager = new InventoryManager();
        }
        public void Run()
        {
            bool continueRunning = true;

            while (continueRunning)
            {
                Console.Clear();
                Console.WriteLine("Product Inventory Management");
                Console.WriteLine("1. Add a new product");
                Console.WriteLine("2. Calculate stock value by category");
                Console.WriteLine("3. View best-selling product");
                Console.WriteLine("4. Update product stock");
                Console.WriteLine("5. Exit");
                Console.Write("Please select an option (1-5): ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddNewProduct();
                        break;
                    case "2":
                        manager.CalculateStockValueByCategory();
                        break;
                    case "3":
                        manager.PrintBestSellingProduct();
                        break;
                    case "4":
                        UpdateProductStock();
                        break;
                    case "5":
                        continueRunning = false;
                        Console.WriteLine("Exiting the program...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
                        break;
                }

                if (continueRunning)
                {
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                }
            }
        }
        private void AddNewProduct()
        {
            Console.WriteLine("\nAdd New Product");

            try
            {
                Console.Write("Enter product ID: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter product name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter category (e.g., Electronics, Furniture): ");
                string category = Console.ReadLine();

                Console.Write("Enter price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter stock quantity: ");
                int stock = int.Parse(Console.ReadLine());

                Console.Write("Enter sales for the last 3 months (comma separated): ");
                string salesInput = Console.ReadLine();
                List<int> sales = new List<int>(Array.ConvertAll(salesInput.Split(','), int.Parse));

                var newProduct = new Product(productId, productName, category, price, stock, sales);
                manager.AddProduct(newProduct);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers and format.");
            }
        }
        private void UpdateProductStock()
        {
            Console.WriteLine("\nUpdate Product Stock");

            try
            {
                Console.Write("Enter product ID to update: ");
                int productId = int.Parse(Console.ReadLine());

                Console.Write("Enter the new stock quantity: ");
                int newStock = int.Parse(Console.ReadLine());

                manager.UpdateProductStock(productId, newStock);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
        }
    }

}
