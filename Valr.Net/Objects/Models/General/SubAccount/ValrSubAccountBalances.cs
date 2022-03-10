using Valr.Net.Objects.Models.Spot.Account;

namespace Valr.Net.Objects.Models.General.SubAccount
{
    public class ValrSubAccountBalances
    {
        public IEnumerable<Accounts> Accounts { get; set; }
    }

    public class Accounts
    {
        public ValrSubAccount account { get; set; }
        public AccountBalance[] balances { get; set; }
    }

}
