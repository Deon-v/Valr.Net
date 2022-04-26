using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Valr.Net.Objects.Models;
using Valr.Net.Objects.Models.Spot.Streams;

namespace Valr.Net.Interfaces.Clients.SpotApi
{
    public interface IValrSocketClientSpotStreams : IDisposable
    {
        /// <summary>
        /// Subscribe to updates on the account
        /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="stringHandler"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToAggregateOrderbookUpdatesAsync(string[] symbol, Action<DataEvent<InboundStreamPayload<AggregateOrderBookData>>> stringHandler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to updates on the account
        /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="snapShotHandler"></param>
        /// <param name="updateHandler"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToFullOrderbookUpdatesAsync(string[] symbol, Action<DataEvent<InboundStreamPayload<FullOrderBookData>>> snapShotHandler,
            Action<DataEvent<InboundStreamPayload<FullOrderBookData>>> updateHandler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to updates on the account
        /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="stringHandler"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToMarketSummaryUpdatesAsync(string[] symbol, Action<DataEvent<InboundStreamPayload<MarketSummaryData>>> stringHandler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to updates on the account
        /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="stringHandler"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToNewTradeBucketUpdatesAsync(string[] symbol, Action<DataEvent<InboundStreamPayload<NewTradeBucketData>>> stringHandler,
            CancellationToken ct = default);

        /// <summary>
        /// Subscribe to updates on the account
        /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="stringHandler"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<UpdateSubscription>> SubscribeToNewTradeUpdatesAsync(string[] symbol, Action<DataEvent<InboundStreamPayload<NewTradeData>>> stringHandler,
            CancellationToken ct = default);
    }
}
