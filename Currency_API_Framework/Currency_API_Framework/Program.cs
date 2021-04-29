using System;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Currency_API_Framework.CurrencyService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var restClient = new RestClient("https://api.coingecko.com/api/");
            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Timeout = -1;

            var currency = "usd";
            restRequest.Resource = $"v3/simple/price?ids=bitcoin&vs_currencies={currency.ToLower()}";

            var restResponse = await restClient.ExecuteAsync(restRequest);
            Console.WriteLine("Response content (string):");
            Console.WriteLine(restResponse.Content);

            var jsonResponse = JObject.Parse(restResponse.Content);
            Console.WriteLine("\nResponse content as a JObject");
            Console.WriteLine(jsonResponse);

            var currencyType = jsonResponse["bitcoin"]["usd"];
            Console.WriteLine($"currency: {currencyType}");
        }
    }
}
