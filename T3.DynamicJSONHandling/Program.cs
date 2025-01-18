
using Newtonsoft.Json.Linq;

namespace T3.DynamicJSONHandling
{
    public class Program
    {
        static void Main(string[] args)
        {
            string jsonString = @"
            {
                'store': {
                    'products': [
                        { 'id': 1, 'name': 'Laptop', 'price': 1200, 'category': 'Electronics', 'stock': 10 },
                        { 'id': 2, 'name': 'Tablet', 'price': 800, 'category': 'Electronics', 'stock': 0 },
                        { 'id': 3, 'name': 'Notebook', 'price': 15, 'category': 'Stationery', 'stock': 50 },
                        { 'id': 4, 'name': 'Pen', 'price': 2, 'category': 'Stationery', 'stock': 100 }
                    ],
                    'lastUpdated': '2025-01-01T10:00:00Z'
                }
            }";

            JObject store = JObject.Parse(jsonString);

            var newProduct = new JObject
            {
                { "id", 5 },
                { "name", "Headphones" },
                { "price", 150 },
                { "category", "Electronics" },
                { "stock", 25 }
            };

            store["store"]["products"].Last.AddAfterSelf(newProduct);

            foreach (var product in store["store"]["products"])
            {
                if (product["category"].ToString() == "Electronics" && product["stock"].ToObject<int>() == 0)
                {
                    product["stock"] = 50;
                }
            }

            int totalStock = store["store"]["products"].Sum(p => p["stock"].ToObject<int>());
            store["store"]["totalStock"] = totalStock;

            var productsArray = store["store"]["products"].ToList();

            foreach (var product in productsArray)
            {
                if (product["price"].ToObject<decimal>() < 10)
                {
                    product.Remove();
                }
            }

            string updatedJson = store.ToString();
            Console.WriteLine("Updated JSON:");
            Console.WriteLine(updatedJson);

            var stationeryProducts = ExtractStationeryProducts(store);
            Console.WriteLine("\nStationery Products (Name, Price):");
            foreach (var item in stationeryProducts)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        private static List<KeyValuePair<string, decimal>> ExtractStationeryProducts(JObject store)
        {
            var stationeryProducts = new List<KeyValuePair<string, decimal>>();
            var products = store["store"]["products"];

            foreach (var product in products)
            {
                if (product["category"].ToString() == "Stationery")
                {
                    string name = product["name"].ToString();
                    decimal price = product["price"].ToObject<decimal>();
                    stationeryProducts.Add(new KeyValuePair<string, decimal>(name, price));
                }
            }

            return stationeryProducts;
        }
    }
}
