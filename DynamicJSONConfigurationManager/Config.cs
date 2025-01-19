
namespace DynamicJSONConfigurationManager
{
    public class Config
    {
        public AppSettings appSettings { get; set; }
        public Dictionary<string, bool> featureFlags { get; set; }
        public List<ApiEndpoint> apiEndpoints { get; set; }
    }
}
