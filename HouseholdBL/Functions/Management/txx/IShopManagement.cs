using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.txx
{
	public interface IShopManagement : IManagementBase<txx_Shop, string, string, CShopData>
	{
		List<txx_Shop> getShops();
	}
}
