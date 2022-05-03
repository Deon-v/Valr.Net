using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;
using Valr.Net.Objects.Models;
using Valr.Net.Objects.Models.Spot.Streams;
using Valr.Net.Objects.Options;

namespace Valr.Net.SymbolOrderBooks
{
    /// <inheritdoc/>
    public class ValrSpotSymbolOrderBookAggregated : SymbolOrderBook
    {
        private readonly IValrClient _restClient;
        private readonly IValrSocketClient _socketClient;
        private readonly TimeSpan _initialDataTimeout;
        private readonly bool _restOwner;
        private readonly bool _socketOwner;
        private readonly int? _updateInterval;

        /// <inheritdoc/>
        public ValrSpotSymbolOrderBookAggregated(string symbol, ValrOrderBookOptions? options = null) : base("Valr", symbol, options ?? new ValrOrderBookOptions())
        {


            _updateInterval = options?.UpdateInterval;
            _initialDataTimeout = options?.InitialDataTimeout ?? TimeSpan.FromSeconds(30);
            _socketClient = options?.SocketClient ?? new ValrSocketClient();
            _restClient = options?.RestClient ?? new ValrClient();
            _restOwner = options?.RestClient == null;
            _socketOwner = options?.SocketClient == null;

            sequencesAreConsecutive = false;
            strictLevels = false;
        }

        /// <inheritdoc/>
        protected override async Task<CallResult<UpdateSubscription>> DoStartAsync(CancellationToken ct)
        {
            CallResult<UpdateSubscription> subResult;

            subResult = await _socketClient.SpotStreams.SubscribeToAggregateOrderbookUpdatesAsync(new[] { Symbol }, HandleUpdate, ct);

            if (!subResult)
                return new CallResult<UpdateSubscription>(subResult.Error!);

            if (ct.IsCancellationRequested)
            {
                await subResult.Data.CloseAsync().ConfigureAwait(false);
                return subResult.AsError<UpdateSubscription>(new CancellationRequestedError());
            }

            Status = OrderBookStatus.Syncing;

            var setResult = await WaitForSetOrderBookAsync(_initialDataTimeout, ct).ConfigureAwait(false);
            return setResult ? subResult : new CallResult<UpdateSubscription>(setResult.Error!);
        }

        private void HandleUpdate(DataEvent<InboundStreamPayload<AggregateOrderBookData>> data)
        {
            SetInitialOrderBook(data.Data.Data.SequenceNumber, GetBidList(data), GetAskList(data));
        }

        private IEnumerable<ISymbolOrderBookEntry> GetBidList(DataEvent<InboundStreamPayload<AggregateOrderBookData>> data)
        {
            return data.Data.Data.Bids.Select(s => ConvertOrderBook(s));
        }

        private IEnumerable<ISymbolOrderBookEntry> GetAskList(DataEvent<InboundStreamPayload<AggregateOrderBookData>> data)
        {
            return data.Data.Data.Asks.Select(s => ConvertOrderBook(s));
        }

        private ISymbolOrderBookEntry ConvertOrderBook(AggregateOrder order)
        {
            return new BookEntry { Price = order.Price, Quantity = order.Quantity };
        }

        protected override async Task<CallResult<bool>> DoResyncAsync(CancellationToken ct)
        {
            return await WaitForSetOrderBookAsync(_initialDataTimeout, ct).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (_restOwner)
                _restClient?.Dispose();
            if (_socketOwner)
                _socketClient?.Dispose();

            base.Dispose(disposing);
        }
    }

    public class BookEntry : ISymbolOrderBookEntry
    {
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
