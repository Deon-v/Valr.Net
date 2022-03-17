namespace Valr.Net.Interfaces.Clients.PayApi
{
    public interface IValrClientPayApi : IDisposable
    {
        /// <summary>
        /// Endpoints related to Valr Pay
        /// </summary>
        public IValrClientPayApiValrPay VarlPay { get; }

    }
}
