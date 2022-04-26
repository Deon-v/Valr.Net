namespace Valr.Net.Objects.Models.General.Streams
{
    public class OpenOrderData
    {
        public string orderId { get; set; }
        public string side { get; set; }
        public string remainingQuantity { get; set; }
        public string originalPrice { get; set; }
        public Currencypair currencyPair { get; set; }
        public DateTime createdAt { get; set; }
        public string originalQuantity { get; set; }
        public string filledPercentage { get; set; }
        public string customerOrderId { get; set; }
    }

    public class Currencypair
    {
        public int id { get; set; }
        public string symbol { get; set; }
        public CurrencyInfo baseCurrency { get; set; }
        public CurrencyInfo quoteCurrency { get; set; }
        public string shortName { get; set; }
        public string exchange { get; set; }
        public bool active { get; set; }
        public float minBaseAmount { get; set; }
        public int maxBaseAmount { get; set; }
        public int minQuoteAmount { get; set; }
        public int maxQuoteAmount { get; set; }
    }

    public class CurrencyInfo
    {
        public int? id { get; set; }
        public string symbol { get; set; }
        public int decimalPlaces { get; set; }
        public bool isActive { get; set; }
        public string shortName { get; set; }
        public string longName { get; set; }
        public int? currencyDecimalPlaces { get; set; }
        public int supportedWithdrawDecimalPlaces { get; set; }
    }
}
