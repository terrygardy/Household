using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Management.t.Interfaces
{
	public interface IBankingManagement
	{
		IEnumerable<t_BankBalance> getBankBalances();

		IEnumerable<t_BankBalance> getBankBalances(Expression<Func<t_BankBalance, bool>> pv_exWhere);

		decimal getCurrentBankBalance();
	}
}