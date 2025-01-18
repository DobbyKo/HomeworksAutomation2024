using Microsoft.Extensions.Logging;
using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Repos;
using Task1_BuildTheSystem.Services;

namespace Task1_BuildTheSystem
{
    public class Program
    {
        static void Main()
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger<OrderService> logger = loggerFactory.CreateLogger<OrderService>();

            string connectionString = "...";

            IProductRepository productRepository = new ProductRepository(connectionString);
            IOrderRepository orderRepository = new OrderRepository(connectionString);

            ProductService productService = new ProductService(productRepository);  
            OrderService orderService = new OrderService(productRepository, orderRepository, logger);

            ProductOperations productOperations = new ProductOperations(productService);


            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. List All Products");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        productOperations.AddProduct();
                        break;

                    case "2":
                        productOperations.UpdateProduct();
                        break;

                    case "3":
                        productOperations.DeleteProduct();
                        break;

                    case "4":
                        productOperations.ListAllProducts();
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
