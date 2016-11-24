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
	public class CWorkDayManagement : CManagementBase<t_WorkDay, DateTime, TimeSpan, CWorkDayData>, IWorkDayManagement
	{
		public CWorkDayManagement(IDb db)
			: base(db)
		{ }

		protected override Expression<Func<t_WorkDay, DateTime>> getStandardOrderBy()
		{
			return x => x.WorkDay;
		}

		protected override Expression<Func<t_WorkDay, TimeSpan>> getStandardThenBy()
		{
			return x => x.Begin;
		}

		public IEnumerable<t_WorkDay> getWorkingDays()
		{
			return getWorkingDays(null);
		}

		public IEnumerable<t_WorkDay> getWorkingDays(Expression<Func<t_WorkDay, bool>> whereClause)
		{
			return getEntities(whereClause, getStandardOrderBy(), getStandardThenBy());
		}

		public IEnumerable<t_WorkDay> getSearchResults(Expression<Func<t_WorkDay, bool>> pv_exWhere)
		{
			return getWorkingDays(pv_exWhere);
		}
	}
}