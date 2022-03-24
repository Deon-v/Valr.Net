using NUnit.Framework;
using System.Threading.Tasks;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;

namespace Valr.Net.IntegrationTests
{
    public class GeneralApiTests
    {
        IValrClient _valrCLient { get; set; }

        [SetUp]
        public void Setup()
        {
            _valrCLient = new ValrClient();
        }

        [Test]
        public async Task TestGetServerTime()
        {
            var result = await _valrCLient.GeneralApi.ExchangeData.GetServerTimeAsync();

            Assert.IsTrue(result.Success);
        }

        [TestCase("BTCZAR", ExpectedResult = true)]
        [TestCase("BTC-ZAR", ExpectedResult = false)]
        public async Task<bool> TestGetTradeHistoryFiltered(string pair)
        {
            var result = await _valrCLient.GeneralApi.ExchangeData.GetTradeHistoryFilteredAsync(pair, System.DateTime.Now.AddDays(-1),
                System.DateTime.Now);

            return result.Success;
        }


        [TestCase("BTCZAR", ExpectedResult = true)]
        [TestCase("BTC-ZAR", ExpectedResult = false)]
        public async Task<bool> TestGetTradeHistory(string pair)
        {
            var result = await _valrCLient.GeneralApi.ExchangeData.GetTradeHistoryAsync(pair);

            return result.Success;
        }
        //
    }
}