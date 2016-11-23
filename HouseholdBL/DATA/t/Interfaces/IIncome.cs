using Household.BL.DATA.Base.Interfaces;
using Household.Data.Context;
using System;

namespace Household.BL.DATA.t.Interfaces
{
	public interface IIncome : IContextBase
	{
		DateTime StartDate { get; set; }

		DateTime? EndDate { get; set; }

		long? Interval_ID { get; set; }

		decimal Amount { get; set; }

		long? Payee_ID { get; set; }

		long? Company_ID { get; set; }

		string Description { get; set; }

		long Day_ID { get; set; }

		txx_BankAccount txx_BankAccount { get; set; }
	}
}