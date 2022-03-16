using Valr.Net.Objects.Models.General.Account;

namespace Valr.Net.Objects.Models.General.SubAccount
{
    public class ValrSubAccountBalances
    {
        public IEnumerable<Accounts> Accounts { get; set; }
    }

    public class Accounts
    {
        public ValrSubAccount account { get; set; }
        public ValrAccountBalance[] balances { get; set; }
    }

}
