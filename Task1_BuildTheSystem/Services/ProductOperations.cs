namespace Task1_BuildTheSystem.Services
{
    public class ProductOperations
    {
        private readonly ProductService _productService;

        public ProductOperations(ProductService productService)
        {
            _productService = productService;
        }
        public void AddProduct()
        {
            Console.WriteLine("Enter product details:");

            Console.Write("Product Name: ");
            string productName = Console.ReadLine();

            var existingProduct = _productService.GetAllProducts()
                .FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (existingProduct != null)
            {
                Console.WriteLine($"Error: A product with the name '{productName}' already exists.");
                return;
            }

            Console.Write("Product Price: ");
            decimal productPrice = decimal.Parse(Console.ReadLine());

            Console.Write("Product Stock: ");
            int productStock = int.Parse(Console.ReadLine());

            var newProduct = new Product
            {
                Name = productName,
                Price = productPrice,
                Stock = productStock
            };

            _productService.AddProduct(newProduct);
        }
        public void UpdateProduct()
        {
            Console.Write("Enter the Product ID to update: ");
            int productId = int.Parse(Console.ReadLine());

            var existingProduct = _productService.GetProductById(productId);
            if (existingProduct == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            Console.Write("Enter new name (leave empty to keep existing): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
                existingProduct.Name = newName;

            Console.Write("Enter new price (leave empty to keep existing): ");
            string newPriceInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(newPriceInput))
                existingProduct.Price = decimal.Parse(newPriceInput);

            Console.Write("Enter new stock (leave empty to keep existing): ");
            string newStockInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(newStockInput))
                existingProduct.Stock = int.Parse(newStockInput);

            _productService.UpdateProduct(existingProduct);
        }

        public void DeleteProduct()
        {
            Console.Write("Enter the Product ID to delete: ");
            int productId = int.Parse(Console.ReadLine());

            _productService.DeleteProduct(productId);
        }

        public void ListAllProducts()
        {
            Console.WriteLine("\nCurrent Products in the System:");
            var products = _productService.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"ProductId: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
            Console.WriteLine();
        }
    }
}

