using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Functions.Management.t
{
	public interface IBankingManagement
	{
		IEnumerable<t_BankBalance> getBankBalances();

		IEnumerable<t_BankBalance> getBankBalances(Expression<Func<t_BankBalance, bool>> pv_exWhere);

		decimal getCurrentBankBalance();
	}
}