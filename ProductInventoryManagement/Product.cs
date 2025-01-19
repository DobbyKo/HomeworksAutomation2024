
using System.ComponentModel;

namespace ProductInventoryManagement
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<int> Sales { get; set; }

        public Product(int productId, string productName, string category, decimal price, int stock, List<int> sales)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Price = price;
            Stock = stock;
            Sales = sales;
        }
    }
}
