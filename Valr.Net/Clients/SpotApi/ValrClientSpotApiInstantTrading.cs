using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients.SpotApi;
using Valr.Net.Objects.Models.Spot.InstantTrading;

namespace Valr.Net.Clients.SpotApi
{
    public class ValrClientSpotApiInstantTrading : IValrClientSpotApiInstantTrading
    {
        private readonly Log _log;
        private readonly ValrClientSpotApi _baseClient;

        internal ValrClientSpotApiInstantTrading(Log log, ValrClientSpotApi valrClientSpotApi)
        {
            _baseClient = valrClientSpotApi;
            _log = log;
        }

        public Task<WebCallResult<ValrInstantTradeStatusResponse>> GetInstantOrderStatusAsync(string symbol, Guid id, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrInstantTradeQuote>> GetQuoteAsync(string symbol, ValrOrderSide side, decimal quantity, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<WebCallResult<ValrInstantTradeResponse>> PlaceInstantOrderAsync(string symbol, ValrOrderSide side, decimal quantity, long? receiveWindow = null, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}
