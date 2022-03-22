using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;
using Valr.Net.Objects.Options;

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

        [Test]
        public async Task TestGetTradeHistoryFiltered()
        {
            var result = await _valrCLient.GeneralApi.ExchangeData.GetTradeHistoryFilteredAsync("BTCZAR",System.DateTime.Now.AddDays(-1),
                System.DateTime.Now);

            Assert.IsTrue(result.Success);
        }
    }
}