namespace Valr.Net.Interfaces.Clients.GeneralApi
{
    public interface IValrClientPayApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to requesting data for general exchange data
        /// </summary>
        public IValrClientGeneralApiExchangeData ExchangeData { get; }

        /// <summary>
        /// Endpoints related to requesting data for and controlling accounts
        /// </summary>
        public IValrClientGeneralApiAccount Account { get; }

        /// <summary>
        /// Endpoints related to requesting data for and controlling wallets
        /// </summary>
        public IValrClientGeneralApiWallet Wallet { get; }

        /// <summary>
        /// Endpoints related to requesting data for and controlling sub accounts
        /// </summary>
        public IValrClientGeneralApiSubAccount SubAccount { get; }
    }
}
