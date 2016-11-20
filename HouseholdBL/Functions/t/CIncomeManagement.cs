using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.DATA.t;
using Household.BL.Functions.Management.t;
using Household.Data.Db;

namespace Household.BL.Functions.t
{
	public class CIncomeManagement : CManagementBase<t_Income, DateTime, string, CIncomeData>, IIncomeManagement
	{
		public CIncomeManagement(IDb db)
			: base(db) { }

		protected override Expression<Func<t_Income, DateTime>> getStandardOrderBy()
		{
			return x => x.StartDate;
		}

		protected override Expression<Func<t_Income, string>> getStandardThenBy()
		{
			return x => x.txx_BankAccount.AccountName;
		}

		public IEnumerable<t_Income> getIncomes()
		{
			return getIncomes(null);
		}

		public IEnumerable<t_Income> getIncomes(Expression<Func<t_Income, bool>> whereClause)
		{
			return getEntities(whereClause, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
