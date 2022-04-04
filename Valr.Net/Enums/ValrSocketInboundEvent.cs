using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valr.Net.Enums
{
    public enum ValrSocketInboundEvent
    {
        NEW_ACCOUNT_HISTORY_RECORD,
        BALANCE_UPDATE,
        BALANCE_SNAPSHOT,
        INSTANT_ORDER_COMPLETED,
        OPEN_ORDERS_UPDATE,
        NEW_ACCOUNT_TRADE,
        ORDER_PROCESSED,
        ORDER_STATUS_UPDATE,
        FAILED_CANCEL_ORDER,
        NEW_PENDING_RECEIVE,
        SEND_STATUS_UPDATE,

        AGGREGATED_ORDERBOOK_UPDATE,
        AGGREGATED_ORDERBOOK_SNAPSHOT,
        FULL_ORDERBOOK_UPDATE,
        FULL_ORDERBOOK_SNAPSHOT,
        MARKET_SUMMARY_UPDATE,
        NEW_TRADE_BUCKET,
        NEW_TRADE
    }
}
