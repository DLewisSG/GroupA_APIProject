using System;
using System.Threading.Tasks;
using RestSharp;

namespace Currency_API_Framework.CurrencyService
{
    public class CallManager
    {
        //
        // Restsharp object which handles comunitcation wiith the API
        readonly IRestClient _client;

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }
        /// <summary>
        /// Defines and makes the API request, and stores the response
        /// </summary>
        /// <param name="coins"></param>
        /// <returns>The response content</returns>
        public async Task<string> MakeCurrencyRequest(string cryptoCurrency, string currency)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"v3/simple/price?ids={cryptoCurrency.ToLower()}&vs_currencies={currency.ToLower()}";
            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}