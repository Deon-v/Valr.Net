using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients.SpotApi;
using Valr.Net.Objects.Models.Spot.Trading;

namespace Valr.Net.Clients.SpotApi
{
    public class ValrClientSpotApiTrading : IValrClientSpotApiTrading
    {
        private readonly Log _log;
        private readonly ValrClientSpotApi _baseClient;

        internal ValrClientSpotApiTrading(Log log, ValrClientSpotApi valrClientSpotApi)
        {
            _baseClient = valrClientSpotApi;
            _log = log;
        }

        public Task<WebCallResult> CancelOrderAsync(Guid id, string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult> CancelOrderAsync(int clientOrderId, string symbol, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ICollection<ValrOpenOrderResponse>>> GetOpenOrderAsync(long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ICollection<ValrOrderDetailResponse>>> GetOrderDetailAsync(Guid id, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ICollection<ValrOrderDetailResponse>>> GetOrderDetailAsync(int clientOrderId, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ICollection<ValrOrderHistoryResponse>>> GetOrderHistoryAsync(int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderStatusResponse>> GetOrderStatusAsync(string symbol, Guid id, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderStatusResponse>> GetOrderStatusAsync(string symbol, int clientOrderId, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderHistoryResponse>> GetOrderSummaryAsync(Guid id, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrOrderHistoryResponse>> GetOrderSummaryAsync(int clientOrderId, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPlaceOrderResponse>> PlaceLimitOrderAsync(string symbol, ValrOrderSide side, decimal quantity, decimal price, bool postOnly = false, ValrTimeInforce timeInForce = ValrTimeInforce.GTC, int? clientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPlaceOrderResponse>> PlaceMarketOrderAsync(string symbol, ValrOrderSide side, decimal quantity, int? newClientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrPlaceOrderResponse>> PlaceStopTakeLimitOrderAsync(string symbol, ValrOrderSide side, decimal quantity, decimal price, decimal stopPrice, ValrOrderType type, ValrTimeInforce timeInForce = ValrTimeInforce.GTC, int? newClientOrderId = null, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
