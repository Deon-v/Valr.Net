using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Valr.Net.Objects.Models.General.Streams;

namespace Valr.Net.Interfaces.Clients.GeneralApi;

public interface IValrSocketClientGeneralStreams : IDisposable
{
    /// <summary>
    /// Subscribe to updates on the account
    /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
    /// </summary>
    /// <param name="newTransactionHandler"></param>
    /// <param name="balanceSnapshotHandler"></param>
    /// <param name="balanceUpdateHandler"></param>
    /// <param name="newTradeHandler"></param>
    /// <param name="instantOrderCompleteHandler"></param>
    /// <param name="openOrderUpdateHandler"></param>
    /// <param name="orderProcessedHandler"></param>
    /// <param name="orderUpdateHandler"></param>
    /// <param name="failedOrderCancellationHandler"></param>
    /// <param name="pendingCryptoDepositHandler"></param>
    /// <param name="cryptoWithdrawalStatusHandler"></param>
    /// <param name="ct">Cancellation token for closing this subscription</param>
    /// <returns>A stream subscription. This stream subscription can be used to be notified when the socket is disconnected/reconnected</returns>
    Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<NewTransactionPayload>> newTransactionHandler,
        Action<DataEvent<BalanceSnapshotPayload>> balanceSnapshotHandler,
        Action<DataEvent<BalanceUpdatePayload>> balanceUpdateHandler,
        Action<DataEvent<NewTradePayload>> newTradeHandler,
        Action<DataEvent<InstantOrderCompletePayload>> instantOrderCompleteHandler,//
        Action<DataEvent<OpenOrderUpdatePayload>> openOrderUpdateHandler,
        Action<DataEvent<OrderProcessedPayload>> orderProcessedHandler,
        Action<DataEvent<OrderUpdatePayload>> orderUpdateHandler,
        Action<DataEvent<FailedOrderCancellationPayload>> failedOrderCancellationHandler,
        Action<DataEvent<PendingCryptoDepositPayload>> pendingCryptoDepositHandler,
        Action<DataEvent<CryptoWithdrawalStatusPayload>> cryptoWithdrawalStatusHandler,
        CancellationToken ct = default);

    /// <summary>
    /// Subscribe to updates on the account
    /// <para><a href="https://docs.valr.com/#da6a3bc7-51e6-4585-baa6-65502a7c8de7" /></para>
    /// </summary>
    /// <param name="stringHandler"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<string>> stringHandler,
        CancellationToken ct = default);
}