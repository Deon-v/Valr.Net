﻿using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using Newtonsoft.Json.Linq;
using Valr.Net.Enums;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Objects.Models;
using Valr.Net.Objects.Models.General.Streams;
using Valr.Net.Objects.Options;

namespace Valr.Net.Clients.GeneralApi
{
    internal class ValrSocketClientGeneralStreams : SocketApiClient, IValrSocketClientGeneralStreams
    {
        #region fields
        private readonly ValrSocketClient _baseClient;
        private readonly Log _log;
        private readonly ValrSocketClientOptions _options;
        #endregion

        #region constructor/destructor

        /// <summary>
        /// Create a new instance of ValrSocketClientGeneral with default options
        /// </summary>
        public ValrSocketClientGeneralStreams(Log log, ValrSocketClient baseClient, ValrSocketClientOptions options) :
            base(options, options.GeneralStreamsOptions)
        {
            _baseClient = baseClient;
            _log = log;
            _options = options;
        }
        #endregion

        /// <inheritdoc />
        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(Action<DataEvent<InboundStreamPayload<NewTransactionData>>> newTransactionHandler,
            Action<DataEvent<InboundStreamPayload<CryptoWithdrawalStatusData>>> balanceSnapshotHandler,
            Action<DataEvent<InboundStreamPayload<BalanceUpdateData>>> balanceUpdateHandler,
            Action<DataEvent<InboundStreamPayload<NewTradeData>>> newTradeHandler,
            Action<DataEvent<InboundStreamPayload<InstantOrderCompleteData>>> instantOrderCompleteHandler,
            Action<DataEvent<InboundStreamPayload<OpenOrderData[]>>> openOrderUpdateHandler,
            Action<DataEvent<InboundStreamPayload<ProcessedOrderData>>> orderProcessedHandler,
            Action<DataEvent<InboundStreamPayload<OrderUpdateData>>> orderUpdateHandler,
            Action<DataEvent<InboundStreamPayload<FailedOrderCancellationData>>> failedOrderCancellationHandler,
            Action<DataEvent<InboundStreamPayload<PendingCryptoDepositData>>> pendingCryptoDepositHandler,
            Action<DataEvent<InboundStreamPayload<CryptoWithdrawalStatusData>>> cryptoWithdrawalStatusHandler,
            CancellationToken ct = default)
        {
            var handler = new Action<DataEvent<string>>(data =>
            {
                var combinedToken = JToken.Parse(data.Data);

                var eventType = combinedToken["type"]?.ToObject<string>();
                if (Enum.TryParse(eventType, false, out ValrSocketInboundEvent parsedEventType))
                    return;

                EventRoutingHandler(newTransactionHandler, balanceSnapshotHandler, balanceUpdateHandler, newTradeHandler, instantOrderCompleteHandler, openOrderUpdateHandler, orderProcessedHandler, orderUpdateHandler, failedOrderCancellationHandler, pendingCryptoDepositHandler, cryptoWithdrawalStatusHandler, parsedEventType, data, combinedToken);
            });

            return await Subscribe(handler, ct, true).ConfigureAwait(false);
        }

        private void EventRoutingHandler(Action<DataEvent<InboundStreamPayload<NewTransactionData>>> newTransactionHandler,
            Action<DataEvent<InboundStreamPayload<CryptoWithdrawalStatusData>>> balanceSnapshotHandler,
            Action<DataEvent<InboundStreamPayload<BalanceUpdateData>>> balanceUpdateHandler,
            Action<DataEvent<InboundStreamPayload<NewTradeData>>> newTradeHandler,
            Action<DataEvent<InboundStreamPayload<InstantOrderCompleteData>>> instantOrderCompleteHandler,
            Action<DataEvent<InboundStreamPayload<OpenOrderData[]>>> openOrderUpdateHandler,
            Action<DataEvent<InboundStreamPayload<ProcessedOrderData>>> orderProcessedHandler,
            Action<DataEvent<InboundStreamPayload<OrderUpdateData>>> orderUpdateHandler,
            Action<DataEvent<InboundStreamPayload<FailedOrderCancellationData>>> failedOrderCancellationHandler,
            Action<DataEvent<InboundStreamPayload<PendingCryptoDepositData>>> pendingCryptoDepositHandler,
            Action<DataEvent<InboundStreamPayload<CryptoWithdrawalStatusData>>> cryptoWithdrawalStatusHandler,
            ValrSocketInboundEvent parsedEventType, DataEvent<string> data, JToken combinedToken)
        {
            switch (parsedEventType)
            {
                case ValrSocketInboundEvent.NEW_ACCOUNT_HISTORY_RECORD:
                    {
                        InvokeHandler(data, combinedToken, newTransactionHandler);
                        break;
                    }
                case ValrSocketInboundEvent.BALANCE_UPDATE:
                    {
                        InvokeHandler(data, combinedToken, balanceUpdateHandler);
                        break;
                    }
                case ValrSocketInboundEvent.BALANCE_SNAPSHOT:
                    {
                        InvokeHandler(data, combinedToken, balanceSnapshotHandler);
                        break;
                    }
                case ValrSocketInboundEvent.INSTANT_ORDER_COMPLETED:
                    {
                        InvokeHandler(data, combinedToken, instantOrderCompleteHandler);
                        break;
                    }
                case ValrSocketInboundEvent.OPEN_ORDERS_UPDATE:
                    {
                        InvokeHandler(data, combinedToken, openOrderUpdateHandler);
                        break;
                    }
                case ValrSocketInboundEvent.NEW_ACCOUNT_TRADE:
                    {
                        InvokeHandler(data, combinedToken, newTradeHandler);
                        break;
                    }
                case ValrSocketInboundEvent.ORDER_PROCESSED:
                    {
                        InvokeHandler(data, combinedToken, orderProcessedHandler);
                        break;
                    }
                case ValrSocketInboundEvent.ORDER_STATUS_UPDATE:
                    {
                        InvokeHandler(data, combinedToken, orderUpdateHandler);
                        break;
                    }
                case ValrSocketInboundEvent.FAILED_CANCEL_ORDER:
                    {
                        InvokeHandler(data, combinedToken, failedOrderCancellationHandler);
                        break;
                    }
                case ValrSocketInboundEvent.NEW_PENDING_RECEIVE:
                    {
                        InvokeHandler(data, combinedToken, pendingCryptoDepositHandler);
                        break;
                    }
                case ValrSocketInboundEvent.SEND_STATUS_UPDATE:
                    {
                        InvokeHandler(data, combinedToken, cryptoWithdrawalStatusHandler);
                        break;
                    }
                default: return;
            }
        }

        public async Task<CallResult<UpdateSubscription>> SubscribeToAccountUpdatesAsync(
            Action<DataEvent<string>> stringHandler,
            CancellationToken ct = default)
        {
            return await Subscribe(stringHandler, ct, true).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="onData"></param>
        /// <param name="ct"></param>
        /// <param name="authenticated">Should this request be authenticated</param>
        /// <returns></returns>
        protected async Task<CallResult<UpdateSubscription>> Subscribe<T>(Action<DataEvent<T>> onData, CancellationToken ct, bool authenticated = false)
        {
            return await _baseClient.SubscribeInternalNoRequest(this, _options.GeneralStreamsOptions.BaseAddress, onData, ct, authenticated).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override AuthenticationProvider CreateAuthenticationProvider(ApiCredentials credentials)
            => new ValrAuthenticationProvider(credentials);

        private void InvokeHandler<T>(DataEvent<string> data, JToken combinedToken, Action<DataEvent<T>> handler)
        {
            var result = _baseClient.DeserializeInternal<T>(combinedToken);
            handler.Invoke(data.As(result.Data));
        }
    }
}
