using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valr.Net.Endpoints.GeneralApi.Wallets
{
    internal static class FiatWalletEndpoints
    {
        internal const string BankAccounts = "v1/wallet/fiat/:currencyCode/accounts";
        internal const string DepositReference = "v1/wallet/fiat/:currencyCode/deposit/reference";
        internal const string Withdrawal = "v1/wallet/fiat/:currencyCode/withdraw";
    }
}
