using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.txx
{
	public interface IIntervalManagement : IManagementBase<txx_Interval, CIntervalData>
	{
		IEnumerable<txx_Interval> getIntervals();
	}
}