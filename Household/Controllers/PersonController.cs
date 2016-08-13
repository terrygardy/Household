using Household.BL.Functions.t;
using Household.BL.DATA.t;
using Household.Data.Context;
using Household.Controllers.Base;

namespace Household.Controllers
{
	public class PersonController : CRUDController<t_Person, CPerson, string, string, CPersonData>
	{
		protected override long GetDataID(CPersonData data)
		{
			return data.ID;
		}
	}
}