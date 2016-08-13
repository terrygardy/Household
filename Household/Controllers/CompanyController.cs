using Household.BL.Functions.txx;
using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class CompanyController : CRUDController<txx_Company, CCompany, string, string, CCompanyData>
	{
		protected override long GetDataID(CCompanyData data)
		{
			return data.ID;
		}
	}
}