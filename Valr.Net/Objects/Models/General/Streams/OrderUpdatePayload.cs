namespace Valr.Net.Objects.Models.General.Streams
{
    public class OrderUpdateData
    {
        public string orderId { get; set; }
        public string orderStatusType { get; set; }
        public Currencypair currencyPair { get; set; }
        public string originalPrice { get; set; }
        public string remainingQuantity { get; set; }
        public string originalQuantity { get; set; }
        public string orderSide { get; set; }
        public string orderType { get; set; }
        public string failedReason { get; set; }
        public DateTime orderUpdatedAt { get; set; }
        public DateTime orderCreatedAt { get; set; }
        public string customerOrderId { get; set; }
    }
}
