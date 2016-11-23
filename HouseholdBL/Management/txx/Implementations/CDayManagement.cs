using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Data.Db;

namespace Household.BL.Management.txx.Implementations
{
	public class CDayManagement : CManagementBase<txx_Day, int, int, CDayData>, IDayManagement
	{
		public CDayManagement(IDb db)
			: base(db) { }

		protected override Expression<Func<txx_Day, int>> getStandardOrderBy()
		{
			return x => x.Day;
		}

		protected override Expression<Func<txx_Day, int>> getStandardThenBy()
		{
			return x => x.Day;
		}

		protected override void deleteAllowed(txx_Day pv_cEntity)
		{
			if (Db.GetGenericRepository<t_Income>().Where(x => x.Day_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Day.InUseIncome);
			if (Db.GetGenericRepository<t_Expense>().Where(x => x.PaymentDay_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Day.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		public IEnumerable<txx_Day> getDays()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}