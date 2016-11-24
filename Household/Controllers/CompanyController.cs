using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class CompanyController : CRUDController<txx_Company, ICompanyManagement, CCompanyData>
	{
		public CompanyController(ICompanyManagement management)
			: base(management)
		{ }
	}
}