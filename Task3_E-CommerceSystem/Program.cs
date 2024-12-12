namespace Task3_E_CommerceSystem
{
    public class Program
    {
        static void Main()
        {
            List<Product> products = new List<Product>
            {
                new Electronics("Car", 35000m),
                new Electronics("Camper", 150000m),
                new Clothing("Bike", 900m),
                new Clothing("Scooter", 160m)
            };

            foreach (var product in products)
            {
                product.DisplayInfo();
            }
        }
    }
}
