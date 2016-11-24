using Household.BL.DATA.Base.Interfaces;
using System;

namespace Household.BL.DATA.t.Interfaces
{
	public interface IExpense : IContextBase
	{
		DateTime StartDate { get; set; }

		DateTime? EndDate { get; set; }

		long? Interval_ID { get; set; }

		long? Company_ID { get; set; }

		decimal Amount { get; set; }

		long? BankAccount_ID { get; set; }

		long? PaymentDay_ID { get; set; }

		string Description { get; set; }
	}
}