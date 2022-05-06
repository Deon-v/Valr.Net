using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Microsoft.Extensions.Logging;
using Valr.Net.Objects.Models.Spot.Streams;
using Valr.Net.Objects.Options;

namespace Valr.Net.OrderBooks
{
    public class ValrSymbolOrderbook : IDisposable, IValrSymbolOrderbook
    {
        private readonly object _bookLock = new object();

        private readonly int? _updateInterval;

        private OrderBookStatus _status;

        private CancellationTokenSource? _cts;


        private readonly SortedList<decimal, ISymbolOrderBookEntry> _asks;

        /// <summary>
        /// The bid list, should only be accessed using the bookLock
        /// </summary>
        private readonly SortedList<decimal, ISymbolOrderBookEntry> _bids;

        /// <summary>
        /// The log
        /// </summary>
        protected Log log;

        private class EmptySymbolOrderBookEntry : ISymbolOrderBookEntry
        {
            public decimal Quantity
            {
                get => 0m;
                set { }
            }
            public decimal Price
            {
                get => 0m;
                set { }
            }
        }

        private static readonly ISymbolOrderBookEntry emptySymbolOrderBookEntry = new EmptySymbolOrderBookEntry();

        public ValrSymbolOrderbook(string id, string symbol, ValrOrderBookOptions options)
        {
            _updateInterval = options?.UpdateInterval;

            if (symbol == null)
                throw new ArgumentNullException(nameof(symbol));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            Id = id;

            Symbol = symbol;
            Status = OrderBookStatus.Disconnected;

            _asks = new SortedList<decimal, ISymbolOrderBookEntry>();
            _bids = new SortedList<decimal, ISymbolOrderBookEntry>(new DescComparer<decimal>());

            log = new Log(id) { Level = options.LogLevel };
            var writers = options.LogWriters ?? new List<ILogger> { new DebugLogger() };
            log.UpdateWriters(writers.ToList());
        }

        /// <inheritdoc/>
        public string Id { get; }

        /// <inheritdoc/>
        public OrderBookStatus Status
        {
            get => _status;
            set
            {
                if (value == _status)
                    return;

                var old = _status;
                _status = value;
                log.Write(LogLevel.Information, $"{Id} order book {Symbol} status changed: {old} => {value}");
                OnStatusChange?.Invoke(old, _status);
            }
        }

        /// <inheritdoc/>
        public long LastSequenceNumber { get; private set; }

        /// <inheritdoc/>
        public string Symbol { get; }

        /// <inheritdoc/>
        public event Action<OrderBookStatus, OrderBookStatus>? OnStatusChange;

        /// <inheritdoc/>
        public event Action<(ISymbolOrderBookEntry BestBid, ISymbolOrderBookEntry BestAsk)>? OnBestOffersChanged;

        /// <inheritdoc/>
        public event Action<(IEnumerable<ISymbolOrderBookEntry> Bids, IEnumerable<ISymbolOrderBookEntry> Asks)>? OnOrderBookUpdate;

        /// <inheritdoc/>
        public DateTime UpdateTime { get; private set; }

        /// <inheritdoc/>
        public int AskCount { get; private set; }

        /// <inheritdoc/>
        public int BidCount { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<ISymbolOrderBookEntry> Asks
        {
            get
            {
                lock (_bookLock)
                    return _asks.Select(a => a.Value).ToList();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<ISymbolOrderBookEntry> Bids
        {
            get
            {
                lock (_bookLock)
                    return _bids.Select(a => a.Value).ToList();
            }
        }

        /// <inheritdoc/>
        public (IEnumerable<ISymbolOrderBookEntry> bids, IEnumerable<ISymbolOrderBookEntry> asks) Book
        {
            get
            {
                lock (_bookLock)
                    return (Bids, Asks);
            }
        }

        /// <inheritdoc/>
        public ISymbolOrderBookEntry BestBid
        {
            get
            {
                lock (_bookLock)
                    return _bids.FirstOrDefault().Value ?? emptySymbolOrderBookEntry;
            }
        }

        /// <inheritdoc/>
        public ISymbolOrderBookEntry BestAsk
        {
            get
            {
                lock (_bookLock)
                    return _asks.FirstOrDefault().Value ?? emptySymbolOrderBookEntry;
            }
        }

        /// <inheritdoc/>
        public (ISymbolOrderBookEntry Bid, ISymbolOrderBookEntry Ask) BestOffers
        {
            get
            {
                lock (_bookLock)
                    return (BestBid, BestAsk);
            }
        }

        /// <inheritdoc/>
        public CallResult<decimal> CalculateAverageFillPrice(decimal quantity, OrderBookEntryType type)
        {
            if (Status != OrderBookStatus.Synced)
                return new CallResult<decimal>(new InvalidOperationError($"{nameof(CalculateAverageFillPrice)} is not available when book is not in Synced state"));

            var totalCost = 0m;
            var totalAmount = 0m;
            var amountLeft = quantity;
            lock (_bookLock)
            {
                var list = type == OrderBookEntryType.Ask ? _asks : _bids;

                var step = 0;
                while (amountLeft > 0)
                {
                    if (step == list.Count)
                        return new CallResult<decimal>(new InvalidOperationError("Quantity is larger than order in the order book"));

                    var element = list.ElementAt(step);
                    var stepAmount = Math.Min(element.Value.Quantity, amountLeft);
                    totalCost += stepAmount * element.Value.Price;
                    totalAmount += stepAmount;
                    amountLeft -= stepAmount;
                    step++;
                }
            }

            return new CallResult<decimal>(Math.Round(totalCost / totalAmount, 8));
        }

        /// <inheritdoc/>
        public void SetOrderBook(AggregateOrderBookData data)
        {
            Status = OrderBookStatus.Syncing;

            lock (_bookLock)
            {
                _asks.Clear();
                foreach (var ask in data.Asks)
                    _asks.Add(ask.Price, ConvertOrderBook(ask));
                _bids.Clear();
                foreach (var bid in data.Bids)
                    _bids.Add(bid.Price, ConvertOrderBook(bid));

                AskCount = _asks.Count;
                BidCount = _bids.Count;

                UpdateTime = DateTime.UtcNow;
                log.Write(LogLevel.Debug, $"{Id} order book {Symbol} data set: {BidCount} bids, {AskCount} asks. #{data.SequenceNumber}");

                OnOrderBookUpdate?.Invoke((GetBidList(data), GetAskList(data)));
                OnBestOffersChanged?.Invoke((BestBid, BestAsk));
            }

            Status = OrderBookStatus.Synced;
        }

        /// <inheritdoc/>
        public void ClearOrderBook(OrderBookStatus status)
        {
            Status = status;
            _asks.Clear();
            _bids.Clear();
            AskCount = 0;
            BidCount = 0;
        }

        private static IEnumerable<ISymbolOrderBookEntry> GetBidList(AggregateOrderBookData data)
        {
            return data.Bids.Select(s => ConvertOrderBook(s));
        }

        private static IEnumerable<ISymbolOrderBookEntry> GetAskList(AggregateOrderBookData data)
        {
            return data.Asks.Select(s => ConvertOrderBook(s));
        }

        private static ISymbolOrderBookEntry ConvertOrderBook(AggregateOrder order)
        {
            return new BookEntry { Price = order.Price, Quantity = order.Quantity };
        }

        /// <inheritdoc/>
        public void Stop()
        {
            Status = OrderBookStatus.Disconnected;
        }

        /// <summary>
        /// IDisposable implementation for the order book
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            ClearOrderBook(OrderBookStatus.Disposing);
            _cts?.Cancel();
            Status = OrderBookStatus.Disposed;
        }
    }
}
