using CryptoExchange.Net.Interfaces;
using CryptoExchange.Net.Objects;

namespace Valr.Net.OrderBooks;

/// <summary>
/// Implementation for a synchronized order book. After calling Start the order book will sync itself and keep up to date with new data. It will automatically try to reconnect and resync in case of a lost/interrupted connection.
/// Make sure to check the State property to see if the order book is synced.
/// </summary>
public interface IValrSpotSymbolOrderBookAggregated
{
    /// <summary>
    /// The list of Symbols that order books are being synced for
    /// </summary>
    string[] Symbols { get; }

    /// <summary>
    /// Start connecting and synchronizing the order book
    /// </summary>
    /// <param name="ct">A cancellation token to stop the order book when canceled</param>
    /// <returns>Success or failure</returns>
    Task<CallResult<bool>> StartAsync(CancellationToken? ct = null);

    /// <summary>
    /// Stop syncing the order book
    /// </summary>
    Task StopAsync();

    /// <summary>
    /// The list of asks for a symbol
    /// </summary>
    ///  <param name="symbol">The symbol to retrieve the asks for</param>
    /// <param name="onlySynced">Should the data only be return if it's synced</param>
    /// <returns>A list of asks</returns>
    IEnumerable<ISymbolOrderBookEntry> GetAsks(string symbol, bool onlySynced = false);

    /// <summary>
    /// The list of bids for a symbol
    /// </summary>
    /// <param name="symbol">The symbol to retrieve the bids for</param>
    /// <param name="onlySynced">Should the data only be return if it's synced</param>
    /// <returns>A list of bids</returns>
    IEnumerable<ISymbolOrderBookEntry> GetBids(string symbol, bool onlySynced = false);

    /// <summary>
    /// Get a snapshot of the book at this moment
    /// </summary>
    /// <param name="symbol">The symbol to retrieve the bids and asks for</param>
    /// <param name="onlySynced">Should the data only be return if it's synced</param>
    /// <returns>A list of bids</returns>
    (IEnumerable<ISymbolOrderBookEntry> bids, IEnumerable<ISymbolOrderBookEntry> asks) GetBook(string symbol, bool onlySynced = false);
}