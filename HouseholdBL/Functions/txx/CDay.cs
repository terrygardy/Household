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
	public class CDay : CModelBase<txx_Day, int, int, CDayData>
	{
		public CDay(Database pv_dmHH_DB) : base(pv_dmHH_DB) { }

		public override void validate(txx_Day pv_cEntity)
		{
			if ((pv_cEntity.Day < 1) || (pv_cEntity.Day > 31)) { throw new ValidationException(Day.Invalid); }

			if (getModel(x => x.Day == pv_cEntity.Day && x.ID != pv_cEntity.ID) != null) { throw new ValidationException(Day.DayExists); }
	}

		protected override Expression<Func<txx_Day, Int32>> getStandardOrderBy()
		{
			return x => x.Day;
		}

		protected override Expression<Func<txx_Day, Int32>> getStandardThenBy()
		{
			return x => x.Day;
		}

		protected override Expression<Func<txx_Day, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		protected override void deleteAllowed(txx_Day pv_cEntity)
		{
			if (Database.t_Income.Where(x => x.Day_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Day.InUseIncome);
			if (Database.t_Expense.Where(x => x.PaymentDay_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Day.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		public List<txx_Day> getDays()
		{
			return getEntities<int, int>(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
