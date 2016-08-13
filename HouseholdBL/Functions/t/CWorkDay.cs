using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Linq.Expressions;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using Household.BL.DATA.t;
using System.Collections.Generic;

namespace Household.BL.Functions.t
{
	public class CWorkDay : CModelBase<t_WorkDay, DateTime, TimeSpan, CWorkDayData>
	{
		public CWorkDay() { }

		public override void validate(t_WorkDay pv_cEntity)
		{
			//todo: Validation for CWorkDay
		}

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
			return base.getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
