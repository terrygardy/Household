using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.Management.t.Interfaces;
using Household.Data.Db;
using Household.BL.DATA.t.Implementations;

namespace Household.BL.Management.t.Implementations
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