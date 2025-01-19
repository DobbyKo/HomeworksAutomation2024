

using Newtonsoft.Json;

namespace DynamicJSONConfigurationManager
{
    public class AppManager
    {
        private const string ConfigFilePath = @"../../../config.json";
        private Config config;

        public AppManager()
        {
            config = LoadConfig();
        }

        private Config LoadConfig()
        {
            if (!File.Exists(ConfigFilePath))
            {
                Console.WriteLine("Config file not found.");
                Environment.Exit(1);
            }

            var json = File.ReadAllText(ConfigFilePath);
            return JsonConvert.DeserializeObject<Config>(json);
        }

        public void SaveConfig()
        {
            var json = JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }
        public void DisplayConfig()
        {
            Console.WriteLine("App Settings:");
            Console.WriteLine($"- App Name: {config.appSettings.appName}");
            Console.WriteLine($"- Version: {config.appSettings.version}");
            Console.WriteLine();

            Console.WriteLine("Feature Flags:");
            foreach (var feature in config.featureFlags)
            {
                Console.WriteLine($"- {feature.Key}: {feature.Value}");
            }
            Console.WriteLine();

            Console.WriteLine("API Endpoints:");
            foreach (var api in config.apiEndpoints)
            {
                Console.WriteLine($"- {api.name}: {api.url} (Secure: {api.isSecure})");
            }
            Console.WriteLine();
        }
        public void EnableFeatureFlag(string feature, bool isEnabled)
        {
            if (config.featureFlags.ContainsKey(feature))
            {
                config.featureFlags[feature] = isEnabled;
                Console.WriteLine($"Feature '{feature}' has been {(isEnabled ? "enabled" : "disabled")}");
            }
            else
            {
                Console.WriteLine($"Feature '{feature}' not found.");
            }
        }
        public void PrintSecureApiEndpoints()
        {
            Console.WriteLine("Secure API Endpoints:");
            foreach (var api in config.apiEndpoints)
            {
                if (api.isSecure)
                {
                    Console.WriteLine($"- {api.name}: {api.url}");
                }
            }
            Console.WriteLine();
        }
        public void AddApiEndpoint(ApiEndpoint newApi)
        {
            var existingApi = config.apiEndpoints.Find(api => api.name == newApi.name);
            if (existingApi == null)
            {
                config.apiEndpoints.Add(newApi);
                Console.WriteLine($"API endpoint '{newApi.name}' has been added.");
            }
            else
            {
                Console.WriteLine($"API endpoint with name '{newApi.name}' already exists.");
            }
        }
    }
}
