namespace Exam16JAN
{
    using RestSharp;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public class CountryService
    {
        private const string ApiUrl = "https://restcountries.com/v3.1/all?fields=name";

        public List<Country> GetCountries()
        {
            var client = new RestClient(ApiUrl);
            var request = new RestRequest();
            request.Method = Method.Get;
            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Country>>(response.Content);
            }
            else
            {
                Console.WriteLine("Error fetching country data.");
                return new List<Country>();
            }
        }
    }

}
