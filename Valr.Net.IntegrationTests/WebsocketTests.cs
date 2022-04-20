using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;

namespace Valr.Net.IntegrationTests
{
    public class WebsocketTests
    {
        IValrSocketClient _valrSocketCLient { get; set; }
        private string _key;
        private string _secret;
        IConfiguration Configuration { get; set; }

        [SetUp]
        public void Setup()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<WebsocketTests>()
                .Build();

            _key = Configuration["key"];
            _secret = Configuration["secret"];

            
        }

        [Test]
        public async Task TestAccountSubsciption()
        {
            _valrSocketCLient = new ValrSocketClient(new Objects.Options.ValrSocketClientOptions
            {
                ApiCredentials = new ApiCredentials(_key, _secret),
                SocketNoDataTimeout = TimeSpan.FromSeconds(10),
                LogLevel = LogLevel.Trace,
                AutoReconnect = true,
                MaxReconnectTries = 5
            });

            var result = await _valrSocketCLient.GeneralStreams.SubscribeToAccountUpdatesAsync(ReadyResult);

            await Task.Delay(TimeSpan.FromSeconds(10));
            Assert.IsTrue(result.Success);
        }

        private void ReadyResult(DataEvent<string> obj)
        {
            Console.WriteLine(obj.Data);
        }
    }
}
