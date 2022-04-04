using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Requests;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Valr.Net.Clients;
using Valr.Net.Objects.Options;
using Valr.Net.UnitTests.Helpers;

namespace Valr.Net.UnitTests
{
    internal class ValrClientTest
    {
        IConfiguration Configuration { get; set; }

        [SetUp]
        protected void SetUp()
        {
            Configuration = new ConfigurationBuilder()
                .AddUserSecrets<ValrClientTest>()
                .Build();

            _key = Configuration["testKey"];
            _secret = Configuration["testSecret"];
        }

        private string _key;
        private string _secret;

        [Test]
        public async Task ReceivingError_Should_ReturnErrorAndNotSuccess()
        {
            // arrange
            var client = ValrClientHelpers.CreateClient();
            ValrClientHelpers.SetErrorWithResponse(client, "{\"message\": \"Error!\", \"code\": 123}", HttpStatusCode.BadRequest);

            // act
            var result = await client.GeneralApi.ExchangeData.GetServerTimeAsync();

            // assert
            Assert.IsFalse(result.Success);
            Assert.IsNotNull(result.Error);
            Assert.IsTrue(result.Error.Code == 123);
            Assert.IsTrue(result.Error.Message == "Error!");
        }

        [Test]
        public void AddingAuthToRequest_Should_AddApiKeyHeader()
        {
            // arrange
            var authProvider = new ValrAuthenticationProvider(new ApiCredentials(_key, _secret));
            var client = new HttpClient();
            var request = new Request(new HttpRequestMessage(HttpMethod.Get, "https://test.valr-api.com"), client, 1);

            // act
            var headers = new Dictionary<string, string>();
            authProvider.AuthenticateRequest(null, request.Uri, HttpMethod.Get, new Dictionary<string, object>(), true, ArrayParametersSerialization.MultipleValues,
                HttpMethodParameterPosition.InUri, out var uriParameters, out var bodyParameters, out headers);

            // assert
            Assert.IsTrue(headers.First().Key == "X-VALR-API-KEY" && headers.First().Value == _key);
        }

        [TestCase("1558014486185", ExpectedResult = "9d52c181ed69460b49307b7891f04658e938b21181173844b5018b2fe783a6d4c62b8e67a03de4d099e7437ebfabe12c56233b73c6a0cc0f7ae87e05f6289928")]
        public string TestGetSignatureGeneration_Should_Match(string timeStamp)
        {
            // arrange
            var authProvider = new ValrAuthenticationProvider(new ApiCredentials(_key, _secret), timeStamp);
            var client = new HttpClient();
            var request = new Request(new HttpRequestMessage(HttpMethod.Get, "https://test.test-api.com/v1/account/balances"), client, 1);

            // act
            var headers = new Dictionary<string, string>();
            authProvider.AuthenticateRequest(null, request.Uri, HttpMethod.Get, new Dictionary<string, object>(), true, ArrayParametersSerialization.MultipleValues,
                HttpMethodParameterPosition.InUri, out var uriParameters, out var bodyParameters, out headers);

            // assert
            return headers["X-VALR-SIGNATURE"];
        }

        [TestCase("1558017528946", ExpectedResult = "be97d4cd9077a9eea7c4e199ddcfd87408cb638f2ec2f7f74dd44aef70a49fdc49960fd5de9b8b2845dc4a38b4fc7e56ef08f042a3c78a3af9aed23ca80822e8")]
        public string TestPostSignatureGeneration_Should_Match(string timeStamp)
        {
            // arrange
            var authProvider = new ValrAuthenticationProvider(new ApiCredentials(_key, _secret), timeStamp);
            var client = new HttpClient();
            var request = new Request(new HttpRequestMessage(HttpMethod.Post, "https://test.test-api.com/v1/orders/market"), client, 1);

            // act
            var headers = new Dictionary<string, string>();
            var parameters = new Dictionary<string, object>()
            {
                {"customerOrderId", "ORDER-000001"},
                {"pair", "BTCZAR"},
                {"side", "BUY"},
                {"quoteAmount", "80000"}
            };

            authProvider.AuthenticateRequest(null, request.Uri, HttpMethod.Post, parameters, true, ArrayParametersSerialization.MultipleValues,
                    HttpMethodParameterPosition.InBody, out var uriParameters, out var bodyParameters, out headers);

            // assert
            return headers["X-VALR-SIGNATURE"];
        }

        [Test]
        public void ProvidingApiCredentials_Should_SaveApiCredentials()
        {
            // arrange
            // act
            var authProvider = new ValrAuthenticationProvider(new ApiCredentials("TestKey", "TestSecret"));

            // assert
            Assert.AreEqual(authProvider.Credentials.Key.GetString(), "TestKey");
            Assert.AreEqual(authProvider.Credentials.Secret.GetString(), "TestSecret");
        }

        [Test]
        public void CheckRestInterfaces()
        {
            var assembly = Assembly.GetAssembly(typeof(ValrClient));
            var ignore = new string[] { };
            var clientInterfaces = assembly.GetTypes().Where(t => t.Name.StartsWith("IValrClient") && !ignore.Contains(t.Name));

            foreach (var clientInterface in clientInterfaces)
            {
                var implementation = assembly.GetTypes().Single(t => t.IsAssignableTo(clientInterface) && t != clientInterface);
                int methods = 0;
                foreach (var method in implementation.GetMethods().Where(m => m.ReturnType.IsAssignableTo(typeof(Task))))
                {
                    var interfaceMethod = clientInterface.GetMethod(method.Name, method.GetParameters().Select(p => p.ParameterType).ToArray());
                    Assert.NotNull(interfaceMethod, $"Missing interface for method {method.Name} in {implementation.Name} implementing interface {clientInterface.Name}");
                    methods++;
                }
                Debug.WriteLine($"{clientInterface.Name} {methods} methods validated");
            }
        }

        [Test]
        public async Task RecieveSuccesCodeAndEmptyBody_Should_ReturnSuccess()
        {
            // arrange
            var client = ValrClientHelpers.CreateClient(new ValrClientOptions { ApiCredentials = new ApiCredentials(_key, _secret),LogLevel = LogLevel.Trace});
            ValrClientHelpers.SetResponse(client, "");

            // act
            var result = await client.SpotApi.Spot.CancelOrderAsync(Guid.NewGuid(), "BTCZAR");

            // assert
            Assert.IsTrue(result.Success);
            Assert.IsNull(result.Error);
        }
    }
}
