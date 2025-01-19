
using Newtonsoft.Json;

namespace MergeTwoJSONFiles
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string products1Json = File.ReadAllText(@"../../../products1.json");
                List<Product> products1 = JsonConvert.DeserializeObject<List<Product>>(products1Json);

                string products2Json = File.ReadAllText(@"../../../products2.json");
                List<Product> products2 = JsonConvert.DeserializeObject<List<Product>>(products2Json);

                Dictionary<int, Product> mergedProductsDict = new Dictionary<int, Product>();

                foreach (var product in products1)
                {
                    mergedProductsDict[product.Id] = product;
                }

                foreach (var product in products2)
                {
                    mergedProductsDict[product.Id] = product;
                }

                List<Product> mergedProducts = new List<Product>(mergedProductsDict.Values);
               
                string mergedJson = JsonConvert.SerializeObject(mergedProducts, Formatting.Indented);

                File.WriteAllText(@"../../../mergedProducts.json", mergedJson);

                Console.WriteLine("Merged products saved to mergedProducts.json.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

    }
}
