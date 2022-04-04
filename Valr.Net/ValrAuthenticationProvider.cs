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
        private readonly string? _testTimeStamp;
        private readonly string? _subAccountId;

        public ValrAuthenticationProvider(ApiCredentials credentials, string? subAccountId = null, string? timeStamp = null) : base(credentials)
        {
            if (credentials.Secret is null || credentials.Key is null)
                throw new ArgumentException("No valid API credentials provided. Key/Secret needed.");

            _subAccountId = subAccountId;
            _testTimeStamp = timeStamp;

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

            var timestamp = string.IsNullOrEmpty(_testTimeStamp) ? GetTimestamp() : _testTimeStamp;

            headers.Add("X-VALR-API-KEY", Credentials.Key.GetString());

            headers.Add("X-VALR-SIGNATURE", SignRequest(timestamp, method.Method, uri.PathAndQuery, _subAccountId,
                providedParameters));
            headers.Add("X-VALR-TIMESTAMP", timestamp);

            if (!string.IsNullOrEmpty(_subAccountId))
            {
                headers.Add("X-VALR-SUB-ACCOUNT-ID", _subAccountId);
            }
        }

        private string GetTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        }

        private string SignRequest(string timestamp, string verb, string path, string subAccountId, Dictionary<string, object>? body = null)
        {
            string b = string.Empty;

            if (body?.Count != 0)
            {
                b = JsonConvert.SerializeObject(body);
            }

            var payload = timestamp + verb.ToUpper() + path + b + subAccountId;
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

            byte[] hash = encryptor.ComputeHash(payloadBytes);
            return BytesToHexString(hash);
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
