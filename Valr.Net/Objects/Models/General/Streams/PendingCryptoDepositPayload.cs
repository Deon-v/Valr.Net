namespace Valr.Net.Objects.Models.General.Streams
{
    public class PendingCryptoDepositData
    {
        public CurrencyInfo currency { get; set; }
        public string receiveAddress { get; set; }
        public string transactionHash { get; set; }
        public float amount { get; set; }
        public DateTime createdAt { get; set; }
        public int confirmations { get; set; }
        public bool confirmed { get; set; }
    }
}
