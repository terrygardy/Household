using Household.BL.DATA.t.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Management.t.Interfaces
{
	public interface IPersonManagement : IManagementBase<t_Person, CPersonData>
	{
		IEnumerable<t_Person> getPeople();
	}
}