using Household.BL.DATA.Base.Interfaces;

namespace Household.BL.DATA.txx.Interfaces
{
	public interface IBankAccount : IContextBase
	{
		string AccountName { get; set; }

		string IBAN { get; set; }

		string BIC { get; set; }

		string BankName { get; set; }
	}
}