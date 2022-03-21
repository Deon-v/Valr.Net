using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Valr.Net
{
    public class ValrAuthenticationProvider : AuthenticationProvider
    {
        private readonly HMACSHA512 encryptor;
        private readonly string testTimeStamp;

        public ValrAuthenticationProvider(ApiCredentials credentials, string? timeStamp = null) : base(credentials)
        {
            if (credentials.Secret is null || credentials.Key is null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

            testTimeStamp = timeStamp;

            encryptor = new HMACSHA512(Encoding.UTF8.GetBytes(credentials.Secret.GetString()));
        }

        public override void AuthenticateRequest(RestApiClient apiClient, Uri uri, HttpMethod method,
            Dictionary<string, object> providedParameters, bool auth, ArrayParametersSerialization arraySerialization,
            HttpMethodParameterPosition parameterPosition, out SortedDictionary<string, object> uriParameters,
            out SortedDictionary<string, object> bodyParameters, out Dictionary<string, string> headers)
        {
            uriParameters = parameterPosition == HttpMethodParameterPosition.InUri ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            bodyParameters = parameterPosition == HttpMethodParameterPosition.InBody ? new SortedDictionary<string, object>(providedParameters) : new SortedDictionary<string, object>();
            headers = new Dictionary<string, string>();

            if (!auth)
                return;

            var timestamp = string.IsNullOrEmpty(testTimeStamp) ? GetTimestamp() : testTimeStamp;

            headers.Add("X-VALR-API-KEY", Credentials.Key.GetString());
            headers.Add("X-VALR-SIGNATURE", SignRequest(Credentials.Secret.GetString(), timestamp, method.Method, uri.PathAndQuery,
                providedParameters));
            headers.Add("X-VALR-TIMESTAMP", timestamp);
        }

        private string GetTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        private string SignRequest(string apiKeySecret, string timestamp, string verb, string path, Dictionary<string, object>? body = null)
        {
            string b = String.Empty;

            if (body?.Count != 0)
            {
                b = JsonConvert.SerializeObject(body);
            }

            var payload = timestamp + verb.ToUpper() + path + b;
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
