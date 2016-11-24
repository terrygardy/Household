using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Household.BL.Management.t.Interfaces;
using Household.Data.Db;
using Household.BL.DATA.t.Implementations;

namespace Household.BL.Management.t.Implementations
{
	public class CExpenseManagement : CManagementBase<t_Expense, DateTime, string, CExpenseData>, IExpenseManagement
	{
		public CExpenseManagement(IDb db)
			: base(db) { }

		protected override Expression<Func<t_Expense, DateTime>> getStandardOrderBy()
		{
			return x => x.StartDate;
		}

		protected override Expression<Func<t_Expense, string>> getStandardThenBy()
		{
			return x => x.txx_BankAccount.AccountName;
		}

		public IEnumerable<t_Expense> getExpenses(Expression<Func<t_Expense, bool>> whereClause)
		{
			return getEntities(whereClause, getStandardOrderBy(), getStandardThenBy());
		}
	}
}