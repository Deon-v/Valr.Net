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
        public string SpotSocketClientAddress { get; set; } = "";

        /// <summary>
        /// The address used by the ValrSocketClient for the General API
        /// </summary>
        public string GeneralSocketClientAddress { get; set; } = "";


        public static ValrApiAddresses Default = new ValrApiAddresses
        {
            RestClientAddress = "https://api.valr.com",
            SpotSocketClientAddress = "wss://api.valr.com/ws/trade",
            GeneralSocketClientAddress = "wss://api.valr.com/ws/account"
        };
    }
}
