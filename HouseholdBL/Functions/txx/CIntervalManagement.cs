using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx;
using Household.BL.Functions.Management.txx;
using Household.Data.Db;

namespace Household.BL.Functions.txx
{
	public class CIntervalManagement : CManagementBase<txx_Interval, string, string, CIntervalData>, IIntervalManagement
	{
		public CIntervalManagement(IDb db)
		: base(db) { }

		protected override Expression<Func<txx_Interval, string>> getStandardOrderBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<txx_Interval, string>> getStandardThenBy()
		{
			return x => x.Name;
		}

		protected override void deleteAllowed(txx_Interval pv_cEntity)
		{
			if (Db.GetGenericRepository<t_Income>().Where(x => x.Interval_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Interval.InUseIncome);
			if (Db.GetGenericRepository<t_Expense>().Where(x => x.Interval_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Interval.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		public IEnumerable<txx_Interval> getIntervals()
		{
			return getIntervals(null);
		}

		public IEnumerable<txx_Interval> getIntervals(Expression<Func<txx_Interval, bool>> whereClause)
		{
			return getEntities(whereClause, getStandardOrderBy(), getStandardThenBy());
		}
	}
}