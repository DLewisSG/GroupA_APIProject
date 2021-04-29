using System;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Linq;

namespace Currency_API_Framework.CurrencyService
{
    public class CurrencyService
    {
        #region Properties
        public CallManager CallManager { get; }
        //newtonsoft object for Json response
        public JObject ResponseContent;
        //object model of the response
        public CurrencyDTO CurrencyDTO { get; set; }
        //currency used in this API Request
        public string CurrencySelected { get; set; }
        public string CurrencyResponse { get; set; }
        #endregion

        //constructor- create Restclient object
        public CurrencyService()
        {
            CallManager = new CallManager();
            CurrencyDTO = new CurrencyDTO();
        }

        public async Task MakeRequestAsync(string currency)
        {
            CurrencySelected = currency;
            //Make request
            CurrencyResponse = await CallManager.MakeCurrencyRequest(currency);

            //parse json into a JObject
            ResponseContent = JObject.Parse(CurrencyResponse);
        }
    }

    

}
