
using Newtonsoft.Json.Linq;

namespace T4.ComplexJPathFiltering
{
    class Program
    {
        static void Main()
        {
            string jsonData = @"
            {
                ""orders"": [
                    {
                        ""orderId"": 1,
                        ""customer"": ""John Doe"",
                        ""items"": [
                            { ""product"": ""Laptop"", ""price"": 1200 },
                            { ""product"": ""Mouse"", ""price"": 25 }
                        ]
                    },
                    {
                        ""orderId"": 2,
                        ""customer"": ""Jane Smith"",
                        ""items"": [
                            { ""product"": ""Phone"", ""price"": 800 },
                            { ""product"": ""Headphones"", ""price"": 100 }
                        ]
                    }
                ]
            }";

            JObject jsonObject = JObject.Parse(jsonData);

            var customers = jsonObject.SelectTokens("$.orders[*].customer").ToList();

            Console.WriteLine("Customers: ");

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

            var productsAbove100 = jsonObject.SelectTokens("$.orders[*].items[?(@.price > 100)].product").ToList();

            Console.WriteLine("\nProducts with price > 100: ");

            foreach (var product in productsAbove100)
            {
                Console.WriteLine(product);
            }

            var firstOrderItems = jsonObject.SelectTokens("$.orders[0].items[*].price").ToList();

            var totalPrice = firstOrderItems.Sum(price => price.Value<decimal>());

            Console.WriteLine($"\nTotal price of items in the first order: {totalPrice}");
        }
    }

}
