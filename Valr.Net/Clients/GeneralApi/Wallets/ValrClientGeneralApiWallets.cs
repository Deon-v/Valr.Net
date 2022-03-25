using CryptoExchange.Net.Logging;
using Valr.Net.Interfaces.Clients.GeneralApi.Wallets;

namespace Valr.Net.Clients.GeneralApi.Wallets;

public class ValrClientGeneralApiWallets : IValrClientGeneralApiWallets
{
    private readonly Log _log;
    private readonly ValrClientGeneralApi _baseClient;

    public IValrClientGeneralApiWalletCrypto Crypto { get; }
    public IValrClientGeneralApiWalletFiat Fiat { get; }
    public IValrClientGeneralApiWalletWire Wire { get; }

    internal ValrClientGeneralApiWallets(Log log, ValrClientGeneralApi valrClientGeneralApi)
    {
        _log = log;
        _baseClient = valrClientGeneralApi;

        Crypto = new ValrClientGeneralApiWalletCrypto(_log, _baseClient);
        Fiat = new ValrClientGeneralApiWalletFiat(_log, _baseClient);
        Wire = new ValrClientGeneralApiWalletWire(_log, _baseClient);
    }
}