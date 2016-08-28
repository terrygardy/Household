using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.txx
{
	public interface ICompanyManagement : IManagementBase<txx_Company, string, string, CCompanyData>
	{
		List<txx_Company> getCompanies();
	}
}
