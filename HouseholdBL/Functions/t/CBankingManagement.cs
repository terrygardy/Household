using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.Data.Db;

namespace Household.BL.Functions.t
{
	public class CBankingManagement
	{
		private readonly IDb _db;

		public CBankingManagement(IDb db)
		{
			_db = db;
		}

		public IEnumerable<t_BankBalance> getBankBalances()
		{
			return getBankBalances(null);
		}

		public IEnumerable<t_BankBalance> getBankBalances(Expression<Func<t_BankBalance, bool>> pv_exWhere)
		{
			return _db.getEntities(pv_exWhere, b => b.ReferenceDate, b => b.Balance);
		}
	}
}
