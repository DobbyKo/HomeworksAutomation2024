using System.Xml;
using Newtonsoft.Json;

namespace DynamicJSONConfigurationManager
{
    public class Program
    {
        
        public static void Main()
        {
            var appManager = new AppManager();

            appManager.DisplayConfig();

            appManager.EnableFeatureFlag("darkMode", false);  
            appManager.EnableFeatureFlag("betaFeatures", true); 

            appManager.PrintSecureApiEndpoints();

            appManager.AddApiEndpoint(new ApiEndpoint
            {
                name = "OrderService",
                url = "https://api.example.com/orders",
                isSecure = true
            });

            appManager.SaveConfig();

            Console.WriteLine("Updated configuration saved.");
        }
    }
}

