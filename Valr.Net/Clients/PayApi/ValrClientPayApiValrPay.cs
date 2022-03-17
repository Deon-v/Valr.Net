using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients.PayApi;
using Valr.Net.Objects.Models.Pay;

namespace Valr.Net.Clients.PayApi
{
    public class ValrClientPayApiValrPay : IValrClientPayApiValrPay
    {
        private readonly Log _log;
        private readonly ValrClientPayApi _baseClient;

        internal ValrClientPayApiValrPay(Log log, ValrClientPayApi valrClientPayApi)
        {
            _log = log;
            _baseClient = valrClientPayApi;
        }

        public Task<WebCallResult<ValrPaymentResponse>> CreatePaymentAsync(ValrPaymentIdentifierType paymentIdentifierType, string recipientAccountId, string currency, decimal amount, string recipientNote, string senderNote, bool anonymous = false, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPaymentHistoryResponse>> GetPaymentDetailsAsync(Guid id, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ICollection<ValrPaymentHistoryResponse>>> GetPaymentHistoryAsync(ValrPaymentStatus[]? status = null, int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPaymentIdResponse>> GetPaymentIdAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPaymentLimitResponse>> GetPaymentLimitsAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPaymentStatusResponse>> GetPaymentStatusAsync(string transactionId, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
