using Household.BL.Functions.Management.t;
using Household.BL.DATA.t;
using Household.Data.Context;
using Household.Controllers.Base;

namespace Household.Controllers
{
	public class PersonController : CRUDController<t_Person, IPersonManagement, string, string, CPersonData>
	{
		public PersonController(IPersonManagement management)
			: base(management)
		{ }

		protected override long GetDataID(CPersonData data)
		{
			return data.ID;
		}
	}
}