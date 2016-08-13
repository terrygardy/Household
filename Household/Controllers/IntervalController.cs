using Household.BL.Functions.txx;
using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class IntervalController : CRUDController<txx_Interval, CInterval, string, string, CIntervalData>
	{
		protected override long GetDataID(CIntervalData data)
		{
			return data.ID;
		}
	}
}