using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Linq.Expressions;
using Household.BL.DATA.t;
using System.Collections.Generic;
using Household.BL.Functions.Management.t;

namespace Household.BL.Functions.t
{
	public class CWorkDayManagement : CModelBase<t_WorkDay, DateTime, TimeSpan, CWorkDayData>, IWorkDayManagement
	{
		public CWorkDayManagement() { }

		protected override Expression<Func<t_WorkDay, DateTime>> getStandardOrderBy()
		{
			return x => x.WorkDay;
		}

		protected override Expression<Func<t_WorkDay, TimeSpan>> getStandardThenBy()
		{
			return x => x.Begin;
		}

		protected override Expression<Func<t_WorkDay, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		public List<t_WorkDay> getWorkingDays()
		{
			return getWorkingDays(null);
		}

		public List<t_WorkDay> getWorkingDays(Expression<Func<t_WorkDay, bool>> pv_exWhere)
		{
			return base.getEntities(pv_exWhere, getStandardOrderBy(), getStandardThenBy());
		}

		public ICollection<t_WorkDay> getSearchResults(Expression<Func<t_WorkDay, bool>> pv_exWhere)
		{
			return getWorkingDays(pv_exWhere);
		}
	}
}