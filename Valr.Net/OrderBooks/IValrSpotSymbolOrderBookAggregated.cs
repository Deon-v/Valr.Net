using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;

namespace Valr.Net.SymbolOrderBooks;

/// <summary>
/// Implementation for a synchronized order book. After calling Start the order book will sync itself and keep up to date with new data. It will automatically try to reconnect and resync in case of a lost/interrupted connection.
/// Make sure to check the State property to see if the order book is synced.
/// </summary>
public interface IValrSpotSymbolOrderBookAggregated
{
    /// <summary>
    /// Start connecting and synchronizing the order book
    /// </summary>
    /// <param name="ct">A cancellation token to stop the order book when canceled</param>
    /// <returns></returns>
    Task<CallResult<bool>> StartAsync(CancellationToken? ct = null);

    /// <summary>
    /// Stop syncing the order book
    /// </summary>
    /// <returns></returns>
    Task StopAsync();

    /// <summary>
    /// The list of asks
    /// </summary>
    IEnumerable<ISymbolOrderBookEntry> GetAsks(string symbol);

    /// <summary>
    /// The list of bids
    /// </summary>
    IEnumerable<ISymbolOrderBookEntry> GetBids(string symbol);

    /// <summary>
    /// Get a snapshot of the book at this moment
    /// </summary>
    (IEnumerable<ISymbolOrderBookEntry> bids, IEnumerable<ISymbolOrderBookEntry> asks) GetBook(string symbol);
}