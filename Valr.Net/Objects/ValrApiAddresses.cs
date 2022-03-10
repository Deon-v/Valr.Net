namespace Valr.Net.Objects
{
    public class ValrApiAddresses
    {
        /// <summary>
        /// The address used by the ValrClient for the Spot API
        /// </summary>
        public string RestClientAddress { get; set; } = "";
        /// <summary>
        /// The address used by the ValrSocketClient for the Spot API
        /// </summary>
        public string SocketClientAddress { get; set; } = "";


        public static ValrApiAddresses Default = new ValrApiAddresses
        {
            RestClientAddress = "https://api.valr.com",
            SocketClientAddress = "wss://api.valr.com"
        };
    }
}
