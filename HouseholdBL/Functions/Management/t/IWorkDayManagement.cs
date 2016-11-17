using Household.BL.DATA.t;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Functions.Management.t
{
	public interface IWorkDayManagement : IManagementBase<t_WorkDay, CWorkDayData>
	{
		IEnumerable<t_WorkDay> getWorkingDays();

		IEnumerable<t_WorkDay> getWorkingDays(Expression<Func<t_WorkDay, bool>> pv_exWhere);
	}
}