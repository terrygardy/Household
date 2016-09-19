﻿using Household.BL.DATA.t;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.t
{
	public interface IPersonManagement : IManagementBase<t_Person, string, string, CPersonData>
	{
		List<t_Person> getPeople();
	}
}