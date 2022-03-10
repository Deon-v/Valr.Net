using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Valr.Net
{
    internal class ValrAuthenticationProvider : AuthenticationProvider
    {
        private readonly HMACSHA512 encryptor;

        public ValrAuthenticationProvider(ApiCredentials credentials) : base(credentials)
        {
            if (credentials.Secret is null || credentials.Key is null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

            encryptor = new HMACSHA512(Encoding.UTF8.GetBytes(credentials.Secret.GetString()));
        }

        public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method,
            Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization,
            HttpMethodParameterPosition parameterPosition, out SortedDictionary<string, object> uriParameters,
            out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
        {
            uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            headers = new Dictionary<string, string>() { { "X-VALR-API-KEY", Credentials.Key.GetString() } };

            if (!auth)
                return;

            var parameters = parameterPosition == HttpMethodParameterPosition.InUri ? uriParameters : bodyParameters;

            var timestamp = GetMillisecondTimestamp(apiClient);
            parameters.Add("X-VALR-TIMESTAMP", timestamp);
            uri = uri.SetParameters(uriParameters, arraySerialization);
            parameters.Add("X-VALR-SIGNATURE", SignRequest(Credentials.Secret.ToString(), timestamp, method.Method, uri.PathAndQuery, JsonConvert.SerializeObject(parameters)));
        }

        private string GetTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        private new string SignRequest(string apiKeySecret, string timestamp, string verb, string path, string body)
        {
            var payload = timestamp + verb.ToUpper() + path + body;
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);


            using (HMACSHA512 hmac = new HMACSHA512(Encoding.UTF8.GetBytes(apiKeySecret)))
            {
                byte[] hash = hmac.ComputeHash(payloadBytes);
                return BytesToHexString(hash);
            }
        }

        private new string BytesToHexString(byte[] hash)
        {
            StringBuilder result = new StringBuilder(hash.Length * 2);
            foreach (var b in hash)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }
    }
}
