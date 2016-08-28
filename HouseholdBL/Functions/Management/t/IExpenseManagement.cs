using Household.BL.DATA.t;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.t
{
	public interface IExpenseManagement : IManagementBase<t_Expense, DateTime, string, CExpenseData>
	{
		List<t_Expense> getExpenses();
	}
}