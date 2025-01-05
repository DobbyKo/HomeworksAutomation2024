namespace Task1_BuildTheSystem
{
    public class Program
    {
        static void Main()
        {
            var productRepository = new ProductRepository(new ApplicationDbContext());
            var orderRepository = new OrderRepository(new ApplicationDbContext());

            var productService = new ProductService(productRepository);
            var orderService = new OrderService(productRepository, orderRepository);

            // Create a new product
            var newProduct = new Product
            {
                Name = "Laptop",
                Price = 1200.00m,
                Stock = 10
            };

            productService.AddProduct(newProduct);

            // Check stock and place an order
            var order = new Order
            {
                ProductId = newProduct.ProductId,
                Quantity = 2
            };

            if (orderService.PlaceOrder(order))
            {
                Console.WriteLine("Order placed successfully!");
            }
            else
            {
                Console.WriteLine("Failed to place order. Insufficient stock or invalid product.");
            }

            var orders = orderService.GetOrders();
            foreach (var o in orders)
            {
                Console.WriteLine($"Order ID: {o.OrderId}, Product ID: {o.ProductId}, Quantity: {o.Quantity}");
            }
        }
    }
}
