using NUnit.Framework;
using System.Threading.Tasks;
using Currency_API_Framework.CurrencyService;
using RestSharp;
using System;

namespace CurrencyTests.Tests
{
    public class CurrencyServiceTests
    {
        CurrencyService _currencyService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _currencyService = new CurrencyService();
            await _currencyService.MakeRequestAsync("usd");
        }

        [Test]
        public void StatusIs200()
        {
            //restResponse.StatusCode
            
            Assert.That((int)_currencyService.CallManager.Response.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void CorrectPriceOfCurrencyIsReturned()
        {
            var result = Int32.Parse(_currencyService.ResponseContent["bitcoin"]["usd"].ToString());
            Assert.That(result, Is.InRange(10000, 80000));
        }
    }
}
