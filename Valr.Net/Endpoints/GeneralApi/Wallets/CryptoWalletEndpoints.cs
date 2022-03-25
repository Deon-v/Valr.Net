namespace Valr.Net.Endpoints.GeneralApi.Wallets
{
    internal static class CryptoWalletEndpoints
    {
        internal const string DepositAddress = "v1/wallet/crypto/:currencyCode/deposit/address";
        internal const string WhitelistedAddress = "v1/wallet/crypto/address-book";
        internal const string WhitelistedAddressCurrency = "v1/wallet/crypto/address-book/:currencyCode";
        internal const string Withdrawal = "v1/wallet/crypto/:currencyCode/withdraw";
        internal const string WithdrawalStatus = "v1/wallet/crypto/:currencyCode/withdraw/:withdrawId";
        internal const string DepositHistory = "v1/wallet/crypto/:currencyCode/deposit/history";
        internal const string WithdrawalHistory = "v1/wallet/crypto/:currencyCode/withdraw/history";
    }
}
