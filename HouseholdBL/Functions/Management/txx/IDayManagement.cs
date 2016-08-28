using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.txx
{
	public interface IDayManagement : IManagementBase<txx_Day, int, int, CDayData>
	{
		List<txx_Day> getDays();
	}
}