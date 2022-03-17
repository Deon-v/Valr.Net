namespace Valr.Net.Enpoints.PayApi
{
    internal static class PayEndpoints
    {
        internal const string NewPayment = "/v1/pay";
        internal const string PaymentLimit = "/v1/pay/limits";
        internal const string PayId = "/v1/pay/payid";
        internal const string PaymentHistory = "v1/pay/history";
        internal const string PaymentDetails = "/v1/pay/identifier/:identifier";
        internal const string PaymentStatus = "/v1/pay/transactionid/:transactionId";
    }
}
