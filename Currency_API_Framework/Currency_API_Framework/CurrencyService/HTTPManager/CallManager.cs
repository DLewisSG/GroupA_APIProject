﻿using System;
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
        public async Task<string> MakeCurrencyRequest(string currency)
        {
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            request.Resource = $"coins/{currency.ToLower().Replace(" ", "")}";
            var response = await _client.ExecuteAsync(request);
            return response.Content;
        }
    }
}
