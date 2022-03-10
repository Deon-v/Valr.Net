namespace Valr.Net.Interfaces.Clients.GeneralApi
{
    public interface IValrClientGeneralApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to requesting data for and controlling sub accounts
        /// </summary>
        public IValrClientGeneralApiSubAccount SubAccount { get; }
    }
}
