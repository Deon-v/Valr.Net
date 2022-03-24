namespace Valr.Net.Endpoints.GeneralApi
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

    internal static class FiatWalletEndpoints
    {
        internal const string BankAccounts = "v1/wallet/fiat/:currencyCode/accounts";
        internal const string DepositReference = "v1/wallet/fiat/:currencyCode/deposit/reference";
        internal const string Withdrawal = "v1/wallet/fiat/:currencyCode/withdraw";
    }

    internal static class WireWalletEndpoints
    {
        internal const string WireAccounts = "v1/wallet/fiat/:currencyCode/accounts";
        internal const string DepositInstructions = "v1/wire/accounts/:identifier/instructions";
        internal const string Withdrawal = "v1/wire/withdrawals";
    }
}
