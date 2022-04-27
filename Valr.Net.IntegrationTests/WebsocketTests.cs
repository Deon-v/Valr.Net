using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;
using Valr.Net.Objects.Models;
using Valr.Net.Objects.Models.General.Streams;
using Valr.Net.Objects.Models.Spot.Streams;

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
        public async Task TestAccountSubscription()
        {
            _valrSocketCLient = new ValrSocketClient(new Objects.Options.ValrSocketClientOptions
            {
                ApiCredentials = new ApiCredentials(_key, _secret),
                SocketNoDataTimeout = TimeSpan.FromSeconds(30),
                LogLevel = LogLevel.Trace,
                AutoReconnect = true,
                MaxReconnectTries = 5
            });

            var result = await _valrSocketCLient.GeneralStreams.SubscribeToAccountUpdatesAsync(ReadyResult);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public async Task TestAggregateOrderbookSubscription()
        {
            _valrSocketCLient = new ValrSocketClient(new Objects.Options.ValrSocketClientOptions
            {
                ApiCredentials = new ApiCredentials(_key, _secret),
                SocketNoDataTimeout = TimeSpan.FromSeconds(10),
                LogLevel = LogLevel.Trace,
                AutoReconnect = true,
                MaxReconnectTries = 5
            });

            var result = await _valrSocketCLient.SpotStreams.SubscribeToAggregateOrderbookUpdatesAsync(new[]
            {
                "BTCZAR"
            }, AggregateResult);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public async Task TestFullOrderbookSubscription()
        {
            _valrSocketCLient = new ValrSocketClient(new Objects.Options.ValrSocketClientOptions
            {
                ApiCredentials = new ApiCredentials(_key, _secret),
                SocketNoDataTimeout = TimeSpan.FromSeconds(10),
                LogLevel = LogLevel.Trace,
                AutoReconnect = true,
                MaxReconnectTries = 5
            });

            var result = await _valrSocketCLient.SpotStreams.SubscribeToFullOrderbookUpdatesAsync(new[]
            {
                "BTCZAR"
            }, SnapShotResult, UpdateResult);

            Assert.IsTrue(result.Success);
        }

        private void ReadyResult(DataEvent<string> obj)
        {
            Console.WriteLine(obj.Data);
        }

        private void AggregateResult(DataEvent<InboundStreamPayload<AggregateOrderBookData>> obj)
        {
            Console.WriteLine(obj.Data);
        }

        private void SnapShotResult(DataEvent<InboundStreamPayload<FullOrderBookData>> obj)
        {
            Console.WriteLine(obj.Data);
        }

        private void UpdateResult(DataEvent<InboundStreamPayload<FullOrderBookData>> obj)
        {
            Console.WriteLine(obj.Data);
        }
    }
}
