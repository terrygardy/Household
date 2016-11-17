using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class IntervalController : CRUDController<txx_Interval, IIntervalManagement, CIntervalData>
	{
		public IntervalController(IIntervalManagement management)
			: base(management)
		{ }
	}
}