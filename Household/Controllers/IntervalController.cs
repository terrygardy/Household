using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class IntervalController : CRUDController<txx_Interval, IIntervalManagement, CIntervalData>
	{
		public IntervalController(IIntervalManagement management)
			: base(management)
		{ }
	}
}