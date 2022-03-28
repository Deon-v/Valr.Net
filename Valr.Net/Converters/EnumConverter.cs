using CryptoExchange.Net.CommonObjects;
using Valr.Net.Enums;

namespace Valr.Net.Converters
{
    public static class EnumConverter
    {
        public static CommonOrderSide ConvertToCommonOrderSde(ValrOrderSide side)
        {
            if (side == ValrOrderSide.Buy)
                return CommonOrderSide.Buy;

            return CommonOrderSide.Sell;
        }

        public static CommonOrderStatus ConvertToCommonOrderSide(ValrOrderStatus status)
        {
            switch (status)
            {
                case ValrOrderStatus.New:
                case ValrOrderStatus.Open:
                case ValrOrderStatus.PartiallyFilled:
                case ValrOrderStatus.Active: return CommonOrderStatus.Active;
                case ValrOrderStatus.Failed:
                case ValrOrderStatus.Cancelled: return CommonOrderStatus.Canceled;
                case ValrOrderStatus.Filled: return CommonOrderStatus.Filled;
                default: return CommonOrderStatus.Active;
            }
        }

        public static CommonOrderType ConvertToCommonOrderType(ValrOrderType type)
        {
            switch (type)
            {
                case ValrOrderType.LIMIT:
                case ValrOrderType.LIMIT_POST_ONLY: return CommonOrderType.Limit;
                case ValrOrderType.SIMPLE:
                case ValrOrderType.MARKET: return CommonOrderType.Market;
                default: return CommonOrderType.Other;
            }
        }

        public static ValrOrderSide ConvertFromCommonOrderSde(CommonOrderSide side)
        {
            if (side == CommonOrderSide.Buy)
                return ValrOrderSide.Buy;

            return ValrOrderSide.Sell;
        }

        public static CommonOrderStatus ConvertFromCommonOrderSide(ValrOrderStatus status)
        {
            switch (status)
            {
                case ValrOrderStatus.New:
                case ValrOrderStatus.Open:
                case ValrOrderStatus.PartiallyFilled:
                case ValrOrderStatus.Active: return CommonOrderStatus.Active;
                case ValrOrderStatus.Failed:
                case ValrOrderStatus.Cancelled: return CommonOrderStatus.Canceled;
                case ValrOrderStatus.Filled: return CommonOrderStatus.Filled;
                default: return CommonOrderStatus.Active;
            }
        }

        public static CommonOrderType ConvertFromCommonOrderType(ValrOrderType type)
        {
            switch (type)
            {
                case ValrOrderType.LIMIT:
                case ValrOrderType.LIMIT_POST_ONLY: return CommonOrderType.Limit;
                case ValrOrderType.SIMPLE:
                case ValrOrderType.MARKET: return CommonOrderType.Market;
                default: return CommonOrderType.Other;
            }
        }
    }
}
