using NUnit.Framework;
using Currency_API_Framework.CurrencyService;
using NUnit.Framework.Internal;

namespace CurrencyTests.Tests
{
    public class WhenCurrencyDTOIsCalledWithValidDataTests
    {
        private CurrencyDTO currencyDTO = new CurrencyDTO();

        [Test]
        public void CurrencyDTOIsCalledWithBitcoin_PriceInUsd()
        {
            string jsonString = "{\"bitcoin\": {\"usd\": 54568}}";
            currencyDTO.DeserializeResponse(jsonString);
            Assert.That(currencyDTO.SingleCurrencyToAnotherResponse.bitcoin.usd, Is.InRange(10000, 200000));
        }
    }
}
