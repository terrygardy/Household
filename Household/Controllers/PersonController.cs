using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Management.t.Interfaces;
using Household.BL.DATA.t.Implementations;

namespace Household.Controllers
{
	public class PersonController : CRUDController<t_Person, IPersonManagement, CPersonData>
	{
		public PersonController(IPersonManagement management)
			: base(management)
		{ }
	}
}