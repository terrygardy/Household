namespace Household.Data.Context
{
	using Audit;

	public partial class tbr_BankAccountPerson : DataAuditBase
	{
		public long ID { get; set; }

		public long BankAccount_ID { get; set; }

		public long Person_ID { get; set; }

		public virtual t_Person t_Person { get; set; }

		public virtual txx_BankAccount txx_BankAccount { get; set; }

		public override string EntityName => "BankAccountPerson";
	}
}
