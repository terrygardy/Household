using System;
using Household.BL.DATA.t;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.t;

namespace Household.Controllers
{
	public class IncomeController : CRUDController<t_Income, IIncomeManagement, DateTime, string, CIncomeData>
	{
		public IncomeController(IIncomeManagement management)
			: base(management)
		{ }
	}
}