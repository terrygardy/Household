using Household.BL.DATA.txx.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Management.txx.Interfaces
{
	public interface IIntervalManagement : IManagementBase<txx_Interval, CIntervalData>
	{
		IEnumerable<txx_Interval> getIntervals();

		IEnumerable<txx_Interval> getIntervals(Expression<Func<txx_Interval, bool>> whereClause);
	}
}