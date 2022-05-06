using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoExchange.Net.CommonObjects;
using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.OrderBook;
using CryptoExchange.Net.Sockets;
using Microsoft.Extensions.Logging;
using Valr.Net.Clients;
using Valr.Net.Interfaces.Clients;
using Valr.Net.Objects.Models;
using Valr.Net.Objects.Models.Spot.Streams;
using Valr.Net.Objects.Options;
using Valr.Net.OrderBooks;

namespace Valr.Net.SymbolOrderBooks
{
    /// <inheritdoc/>
    public class ValrSpotSymbolOrderBookAggregated : IValrSpotSymbolOrderBookAggregated, IDisposable
    {
        private readonly IValrClient _restClient;
        private readonly IValrSocketClient _socketClient;
        private readonly TimeSpan _initialDataTimeout;
        private readonly bool _restOwner;
        private readonly bool _socketOwner;

        private CancellationTokenSource? _cts;

        /// <summary>
        /// The log
        /// </summary>
        protected Log log;

        private readonly string[] Symbols;
        private readonly ValrOrderBookOptions _options;
        private UpdateSubscription? _subscription;
        private const string _id = "Valr[Spot]";

        private readonly ConcurrentDictionary<string, IValrSymbolOrderbook> _orderBooks;

        public ValrSpotSymbolOrderBookAggregated(string[] symbols, ValrOrderBookOptions? options = null)
        {
            if (symbols.Length == 0) throw new ArgumentException(nameof(symbols));

            _options = options ?? new ValrOrderBookOptions();

            _initialDataTimeout = options?.InitialDataTimeout ?? TimeSpan.FromSeconds(30);
            _socketClient = options?.SocketClient ?? new ValrSocketClient();
            _restClient = options?.RestClient ?? new ValrClient();
            _restOwner = options?.RestClient == null;
            _socketOwner = options?.SocketClient == null;
            _orderBooks = new ConcurrentDictionary<string, IValrSymbolOrderbook>();
            Symbols = symbols;
            log = new Log("Symbol Order Book") { Level = options.LogLevel };
            var writers = options.LogWriters ?? new List<ILogger> { new DebugLogger() };
            log.UpdateWriters(writers.ToList());
        }

        /// <inheritdoc/>
        public async Task<CallResult<bool>> StartAsync(CancellationToken? ct = null)
        {
            foreach (var symbol in Symbols)
            {
                _orderBooks.TryAdd(symbol, new ValrSymbolOrderbook(_id, symbol, _options));
            }

            _cts = new CancellationTokenSource();
            ct?.Register(async () =>
            {
                _cts.Cancel();
                await StopAsync().ConfigureAwait(false);
            }, false);

            CallResult<UpdateSubscription> subResult = await _socketClient.SpotStreams.SubscribeToAggregateOrderbookUpdatesAsync(Symbols, HandleUpdate, ct.Value);

            _subscription = subResult.Data;
            _subscription.ConnectionLost += () =>
            {
                Reset();
            };

            _subscription.ConnectionClosed += () =>
            {
                log.Write(LogLevel.Warning, $"{_id} order books disconnected");
                _ = StopAsync();
            };

            _subscription.ConnectionRestored += time =>
                log.Write(LogLevel.Information, $"{_id} order books connection restored after {time.TotalSeconds} seconds");

            if (!subResult)
            {
                foreach (var order in _orderBooks)
                {
                    order.Value.Status = OrderBookStatus.Disconnected;
                }

                return new CallResult<bool>(subResult.Error!);
            }

            if (_cts.IsCancellationRequested)
            {
                await subResult.Data.CloseAsync().ConfigureAwait(false);
                foreach (var order in _orderBooks)
                {
                    order.Value.Status = OrderBookStatus.Disconnected;
                }
                return new CallResult<bool>(false);
            }

            foreach (var order in _orderBooks)
            {
                order.Value.Status = OrderBookStatus.Synced;
            }

            return new CallResult<bool>(true);
        }

        /// <inheritdoc/>
        public async Task StopAsync()
        {
            log.Write(LogLevel.Debug, $"{_id} order books stopping");
            foreach (var order in _orderBooks)
            {
                order.Value.Stop();
            }

            _cts?.Cancel();
            if (_subscription != null)
                await _subscription.CloseAsync().ConfigureAwait(false);

            foreach (var book in _orderBooks)
            {
                book.Value.Dispose();
            }

            _orderBooks.Clear();

            log.Write(LogLevel.Trace, $"{_id} order books stopped");
        }

        /// <inheritdoc/>
        public IEnumerable<ISymbolOrderBookEntry> GetAsks(string symbol)
        {
            return _orderBooks[symbol].Asks;
        }

        /// <inheritdoc/>
        public IEnumerable<ISymbolOrderBookEntry> GetBids(string symbol)
        {
            return _orderBooks[symbol].Bids;
        }

        /// <inheritdoc/>
        public (IEnumerable<ISymbolOrderBookEntry> bids, IEnumerable<ISymbolOrderBookEntry> asks) GetBook(string symbol)
        {
            return (GetBids(symbol), GetAsks(symbol));
        }

        private void Reset()
        {
            log.Write(LogLevel.Warning, $"{_id} order books connection lost");
            foreach (var order in _orderBooks)
            {
                order.Value.ClearOrderBook(OrderBookStatus.Reconnecting);
            }
        }

        private void HandleUpdate(DataEvent<InboundStreamPayload<AggregateOrderBookData>> data)
        {
            if (!string.IsNullOrEmpty(data.Data.Symbol))
                _orderBooks[data.Data.Symbol].SetOrderBook(data.Data.Data);
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
            if (_restOwner)
                _restClient?.Dispose();
            if (_socketOwner)
                _socketClient?.Dispose();

            foreach (var book in _orderBooks)
            {
                book.Value.Dispose();
            }

            _orderBooks.Clear();
        }
    }
}
