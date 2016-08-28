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

namespace Household.BL.Functions.txx
{
	public class CDayManagement : CModelBase<txx_Day, int, int, CDayData>, IDayManagement
	{
		public CDayManagement() { }

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
