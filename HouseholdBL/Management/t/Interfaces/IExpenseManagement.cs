using Household.BL.DATA.t.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Management.t.Interfaces
{
	public interface IExpenseManagement : IManagementBase<t_Expense, CExpenseData>
	{
		IEnumerable<t_Expense> getExpenses(Expression<Func<t_Expense, bool>> pv_exWhere);
	}
}