using Household.BL.Functions.txx;
using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class DayController : CRUDController<txx_Day, CDay, int, int, CDayData>
	{
		protected override long GetDataID(CDayData data)
		{
			return data.ID;
		}
	}
}