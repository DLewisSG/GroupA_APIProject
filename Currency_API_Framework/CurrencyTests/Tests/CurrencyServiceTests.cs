using NUnit.Framework;
using System.Threading.Tasks;
using Currency_API_Framework.CurrencyService;
using RestSharp;
using System;

namespace CurrencyTests.Tests
{

    public class CurrencyServiceTestsBitcoin

    {
        CurrencyService _currencyService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _currencyService = new CurrencyService();
            await _currencyService.MakeRequestAsync("bitcoin", "gbp");
        }


        [Test]
        public void CorrectPriceOfBitcoinPoundsIsReturned()
        {
            var result = Int32.Parse(_currencyService.ResponseContent["bitcoin"]["gbp"].ToString());
            Assert.That(result, Is.InRange(10000, 80000));
        }
    }

    public class IotaTest
    {
        CurrencyService _currencyService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _currencyService = new CurrencyService();
            await _currencyService.MakeRequestAsync("iota", "usd");
        }

        [Test]
        public void CorrectPriceOfIotaToDollarsIsReturned()
        {
            var result = float.Parse(_currencyService.ResponseContent["iota"]["usd"].ToString());
            Assert.That(result, Is.InRange(1, 100000000));
        }
    }

    public class EosTest
    {
        CurrencyService _currencyService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _currencyService = new CurrencyService();
            await _currencyService.MakeRequestAsync("eos", "pln");
        }

        [Test]
        public void CorrectPriceOfEOSToZlotyIsReturned()
        {
            var result = float.Parse(_currencyService.ResponseContent["eos"]["pln"].ToString());
            Assert.That(result, Is.InRange(1, 100000000));
        }
    }

    public class MadeUpCryptoTest
    {
        CurrencyService _currencyService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _currencyService = new CurrencyService();
            await _currencyService.MakeRequestAsync("abcdefg", "pln");
        }

        [Test]
        public void MadeUpCrypto_ThrowsException()
        {
            var result = float.Parse(_currencyService.ResponseContent["abcdefg"]["pln"].ToString());
            Assert.That(result, Throws.ArgumentException);
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