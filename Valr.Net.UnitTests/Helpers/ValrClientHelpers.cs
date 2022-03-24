using CryptoExchange.Net.Interfaces;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;
using Valr.Net.Objects.Options;

namespace Valr.Net.UnitTests.Helpers
{
    internal class ValrClientHelpers
    {
        public static IValrClient CreateClient(ValrClientOptions options = null)
        {
            IValrClient client;
            client = options != null ? new ValrClient(options) : new ValrClient();
            client.RequestFactory = Mock.Of<IRequestFactory>();
            return client;
        }

        public static IValrClient CreateResponseClient(string response, ValrClientOptions options = null)
        {
            var client = (ValrClient)CreateClient(options);
            SetResponse(client, response);
            return client;
        }

        public static IValrClient CreateResponseClient<T>(T response, ValrClientOptions options = null)
        {
            var client = (ValrClient)CreateClient(options);
            SetResponse(client, JsonConvert.SerializeObject(response));
            return client;
        }

        public static void SetResponse(IValrClient client, string responseData)
        {
            var expectedBytes = Encoding.UTF8.GetBytes(responseData);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var response = new Mock<IResponse>();
            response.Setup(c => c.IsSuccessStatusCode).Returns(true);
            response.Setup(c => c.GetResponseStreamAsync()).Returns(Task.FromResult((Stream)responseStream));

            var request = new Mock<IRequest>();
            request.Setup(c => c.Uri).Returns(new Uri("https://test.valr-api.com"));
            request.Setup(c => c.GetHeaders()).Returns(new Dictionary<string, IEnumerable<string>>());
            request.Setup(c => c.GetResponseAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(response.Object));

            var factory = Mock.Get(client.RequestFactory);
            factory.Setup(c => c.Create(It.IsAny<HttpMethod>(), It.IsAny<Uri>(), It.IsAny<int>()))
                .Returns(request.Object);
        }

        public static void SetErrorWithResponse(IValrClient client, string responseData, HttpStatusCode code)
        {
            var expectedBytes = Encoding.UTF8.GetBytes(responseData);
            var responseStream = new MemoryStream();
            responseStream.Write(expectedBytes, 0, expectedBytes.Length);
            responseStream.Seek(0, SeekOrigin.Begin);

            var response = new Mock<IResponse>();
            response.Setup(c => c.IsSuccessStatusCode).Returns(false);
            response.Setup(c => c.GetResponseStreamAsync()).Returns(Task.FromResult((Stream)responseStream));

            var request = new Mock<IRequest>();
            request.Setup(c => c.Uri).Returns(new Uri("https://test.valr-api.com"));
            request.Setup(c => c.GetHeaders()).Returns(new Dictionary<string, IEnumerable<string>>());
            request.Setup(c => c.GetResponseAsync(It.IsAny<CancellationToken>())).Returns(Task.FromResult(response.Object));

            var factory = Mock.Get(client.RequestFactory);
            factory.Setup(c => c.Create(It.IsAny<HttpMethod>(), It.IsAny<Uri>(), It.IsAny<int>()))
                .Returns(request.Object);
        }

    }
}
