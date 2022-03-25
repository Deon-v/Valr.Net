namespace Valr.Net.Interfaces.Clients.GeneralApi.Wallets;

public interface IValrClientGeneralApiWallets
{
    public IValrClientGeneralApiWalletCrypto Crypto { get; }
    public IValrClientGeneralApiWalletFiat Fiat { get; }
    public IValrClientGeneralApiWalletWire Wire { get; }
}