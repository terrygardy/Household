namespace Household.BL.Interfaces.txx
{
	public interface IBankAccount : IContextBase
	{
		string AccountName { get; set; }

		string IBAN { get; set; }

		string BIC { get; set; }

		string BankName { get; set; }
	}
}
