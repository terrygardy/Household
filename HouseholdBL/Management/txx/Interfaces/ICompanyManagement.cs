using Household.BL.DATA.txx.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Management.txx.Interfaces
{
	public interface ICompanyManagement : IManagementBase<txx_Company, CCompanyData>
	{
		IEnumerable<txx_Company> getCompanies();
	}
}