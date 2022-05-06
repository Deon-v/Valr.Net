using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;
using Valr.Net.Objects.Models.Spot.Streams;

namespace Valr.Net.OrderBooks;

/// <summary>
/// Interface for order book
/// </summary>
public interface IValrSymbolOrderbook
{
    /// <summary>
    /// The list of asks
    /// </summary>
    IEnumerable<ISymbolOrderBookEntry> Asks { get; }

    /// <summary>
    /// The list of bids
    /// </summary>
    IEnumerable<ISymbolOrderBookEntry> Bids { get; }

    /// <summary>
    /// Identifier
    /// </summary>
    string Id { get; }

    /// <summary>
    /// The status of the order book. Order book is up to date when the status is `Synced`
    /// </summary>
    OrderBookStatus Status { get; set; }

    /// <summary>
    /// Last update identifier
    /// </summary>
    long LastSequenceNumber { get; }

    /// <summary>
    /// The symbol of the order book
    /// </summary>
    string Symbol { get; }

    /// <summary>
    /// Timestamp of the last update
    /// </summary>
    DateTime UpdateTime { get; }

    /// <summary>
    /// The number of asks in the book
    /// </summary>
    int AskCount { get; }

    /// <summary>
    /// The number of bids in the book
    /// </summary>
    int BidCount { get; }

    /// <summary>
    /// Get a snapshot of the book at this moment
    /// </summary>
    (IEnumerable<ISymbolOrderBookEntry> bids, IEnumerable<ISymbolOrderBookEntry> asks) Book { get; }

    /// <summary>
    /// The best bid currently in the order book
    /// </summary>
    ISymbolOrderBookEntry BestBid { get; }

    /// <summary>
    /// The best ask currently in the order book
    /// </summary>
    ISymbolOrderBookEntry BestAsk { get; }

    /// <summary>
    /// BestBid/BesAsk returned as a pair
    /// </summary>
    (ISymbolOrderBookEntry Bid, ISymbolOrderBookEntry Ask) BestOffers { get; }

    /// <summary>
    /// Event when the state changes
    /// </summary>
    event Action<OrderBookStatus, OrderBookStatus> OnStatusChange;
    /// <summary>
    /// Event when order book was updated. Be careful! It can generate a lot of events at high-liquidity markets
    /// </summary>    
    event Action<(IEnumerable<ISymbolOrderBookEntry> Bids, IEnumerable<ISymbolOrderBookEntry> Asks)> OnOrderBookUpdate;
    /// <summary>
    /// Event when the BestBid or BestAsk changes ie a Pricing Tick
    /// </summary>
    event Action<(ISymbolOrderBookEntry BestBid, ISymbolOrderBookEntry BestAsk)> OnBestOffersChanged;

    /// <summary>
    /// Get the average price that a market order would fill at at the current order book state. This is no guarentee that an order of that quantity would actually be filled
    /// at that price since between this calculation and the order placement the book can have changed.
    /// </summary>
    /// <param name="quantity">The quantity in base asset to fill</param>
    /// <param name="type">The type</param>
    /// <returns>Average fill price</returns>
    CallResult<decimal> CalculateAverageFillPrice(decimal quantity, OrderBookEntryType type);

    /// <summary>
    /// Update the order book value with the newly received data
    /// </summary>
    /// <param name="data"></param>
    void SetOrderBook(AggregateOrderBookData data);

    /// <summary>
    /// Clear the orderbook and set the status
    /// </summary>
    /// <param name="status"></param>
    void ClearOrderBook(OrderBookStatus status);

    /// <summary>
    /// Stop syncing the order book
    /// </summary>
    /// <returns></returns>
    void Stop();

    /// <summary>
    /// IDisposable implementation for the order book
    /// </summary>
    void Dispose();
}