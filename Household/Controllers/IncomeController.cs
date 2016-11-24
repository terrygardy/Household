using Household.BL.DATA.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class IncomeController : CRUDController<t_Income, IIncomeManagement, CIncomeData>
	{
		public IncomeController(IIncomeManagement management)
			: base(management)
		{ }
	}
}