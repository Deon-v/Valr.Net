using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using Valr.Net.Interfaces.Clients.GeneralApi;
using Valr.Net.Objects.Models.General.Wallet;

namespace Valr.Net.Clients.GeneralApi;

public class ValrClientGeneralApiWallet : IValrClientGeneralApiWallet
{
    private readonly Log _log;
    private readonly ValrClientGeneralApi _baseClient;

    internal ValrClientGeneralApiWallet(Log log, ValrClientGeneralApi valrClientGeneralApi)
    {
        _log = log;
        _baseClient = valrClientGeneralApi;
    }

    public Task<WebCallResult<IEnumerable<ValrWalletAddress>>> GetDepositAddressAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<ValrDepositStatusInfo>>> GetDepositHistoryAsync(string currencyCode, int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<ValrWithdrawalId>> GetDoWithdrawalAsync(string currencyCode, string? paymentReference = null, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<ValrWhitelistedAddress>>> GetWhitelistedWithdrawalAddressAsync(long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<ValrWhitelistedAddress>>> GetWhitelistedWithdrawalAddressAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<IEnumerable<ValrWithdrawalStatusInfo>>> GetWithdrawalHistoryAsync(string currencyCode, int skip = 0, int limit = 10, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<ValrWithdrawalInfo>> GetWithdrawalInfoAsync(string currencyCode, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<WebCallResult<ValrWithdrawalStatusInfo>> GetWithdrawalStatusAsync(string currencyCode, Guid Id, long? receiveWindow = null, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}