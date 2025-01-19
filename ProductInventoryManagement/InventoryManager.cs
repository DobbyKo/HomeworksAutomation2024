

using Newtonsoft.Json;

namespace ProductInventoryManagement
{
    public class InventoryManager
    {
        private const string FilePath = @"../../../inventory.json";
        private List<Product> products;

        public InventoryManager()
        {
            products = LoadProductsFromFile();
        }

        private List<Product> LoadProductsFromFile()
        {
            if (File.Exists(FilePath))
            {
                var jsonData = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<Product>>(jsonData);
            }

            return new List<Product>();
        }
        private void SaveProductsToFile()
        {
            try
            {
                var json = JsonConvert.SerializeObject(products, Formatting.Indented);

                File.WriteAllText(FilePath, json);
                Console.WriteLine("Product list has been updated and saved to inventory.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }
        }
        public void AddProduct(Product newProduct)
        {
            if (products.Any(p => p.ProductId == newProduct.ProductId))
            {
                Console.WriteLine($"Error: Product with ID {newProduct.ProductId} already exists.");
                return;
            }

            products.Add(newProduct);
            SaveProductsToFile();
            Console.WriteLine($"Product {newProduct.ProductName} added successfully.");
        }
        public void CalculateStockValueByCategory()
        {
            var categoryStockValue = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    TotalValue = g.Sum(p => p.Price * p.Stock)
                })
                .ToList();

            foreach (var category in categoryStockValue)
            {
                Console.WriteLine($"Category: {category.Category}, Total Stock Value: {category.TotalValue:C}");
            }
        }
        public void PrintBestSellingProduct()
        {
            var bestSellingProduct = products
                .Select(p => new
                {
                    Product = p,
                    TotalSales = p.Sales.Sum()
                })
                .OrderByDescending(x => x.TotalSales)
                .FirstOrDefault();

            if (bestSellingProduct != null)
            {
                Console.WriteLine($"Best Selling Product: {bestSellingProduct.Product.ProductName} (ID: {bestSellingProduct.Product.ProductId}), Total Sales: {bestSellingProduct.TotalSales}");
            }
        }
        public void UpdateProductStock(int productId, int newStock)
        {
            var product = products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                product.Stock = newStock;
                SaveProductsToFile();
                Console.WriteLine($"Stock updated for {product.ProductName} (ID: {productId}) to {newStock}.");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }
    }
}
