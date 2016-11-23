using Household.Data.Context;
using System;

namespace Household.BL.DATA.t.Interfaces
{
	public interface IBankBalance
	{
		long ID { get; set; }

		DateTime ReferenceDate { get; set; }

		decimal Balance { get; set; }

		long BankAccount_ID { get; set; }

		txx_BankAccount BankAccount { get; set; }
	}
}