using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class CompanyController : CRUDController<txx_Company, ICompanyManagement, CCompanyData>
	{
		public CompanyController(ICompanyManagement management)
			: base(management)
		{ }
	}
}