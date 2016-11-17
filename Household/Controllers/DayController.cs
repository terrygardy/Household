using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class DayController : CRUDController<txx_Day, IDayManagement, CDayData>
	{
		public DayController(IDayManagement management)
			: base(management)
		{ }
	}
}