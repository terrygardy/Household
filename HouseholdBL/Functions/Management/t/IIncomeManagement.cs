using Household.BL.DATA.t;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.t
{
	public interface IIncomeManagement : IManagementBase<t_Income, CIncomeData>
	{
		IEnumerable<t_Income> getIncomes();
	}
}