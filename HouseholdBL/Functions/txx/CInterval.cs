using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx;

namespace Household.BL.Functions.txx
{
	public class CInterval : CModelBase<txx_Interval, string, string, CIntervalData>
	{
		public CInterval(Database pv_dmHH_DB) : base(pv_dmHH_DB) { }

		public override void validate(txx_Interval pv_cEntity)
		{
			if (string.IsNullOrEmpty(pv_cEntity.Name)) { throw new ValidationException(Interval.EnterName); }

			if (getModel(x=>string.Compare(x.Name, pv_cEntity.Name, true) == 0 && x.ID != pv_cEntity.ID) != null) { throw new ValidationException(Interval.NameExists); }
	}

		protected override Expression<Func<txx_Interval, string>> getStandardOrderBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<txx_Interval, string>> getStandardThenBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<txx_Interval, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		protected override void deleteAllowed(txx_Interval pv_cEntity)
		{
			if (Database.t_Income.Where(x => x.Interval_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Interval.InUseIncome);
			if (Database.t_Expense.Where(x => x.Interval_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Interval.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		public List<txx_Interval> getIntervals()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
