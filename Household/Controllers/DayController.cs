using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class DayController : CRUDController<txx_Day, IDayManagement, CDayData>
	{
		public DayController(IDayManagement management)
			: base(management)
		{ }
	}
}