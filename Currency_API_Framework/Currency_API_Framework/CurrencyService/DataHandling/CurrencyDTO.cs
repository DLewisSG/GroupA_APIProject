using Newtonsoft.Json;
namespace Currency_API_Framework.CurrencyService
{
    public class CurrencyDTO
    {
        public SingleCurrencyToAnotherResponse SingleCurrencyToAnotherResponse { get; set; }
        public void DeserializeResponse(string singleCurrencyResponse)
        {
            SingleCurrencyToAnotherResponse = JsonConvert.DeserializeObject<SingleCurrencyToAnotherResponse>(singleCurrencyResponse);
        }
    }
}
