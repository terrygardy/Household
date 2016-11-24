using Household.BL.DATA.txx.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Management.txx.Interfaces
{
	public interface IDayManagement : IManagementBase<txx_Day, CDayData>
	{
		IEnumerable<txx_Day> getDays();
	}
}