namespace Valr.Net.Objects.Models.General.Streams
{
    public class ProcessedOrderData
    {
        public string orderId { get; set; }
        public bool success { get; set; }
        public string failureReason { get; set; }
    }

}
