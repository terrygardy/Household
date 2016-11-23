using Household.BL.DATA.txx.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Management.txx.Interfaces
{
	public interface IShopManagement : IManagementBase<txx_Shop, CShopData>
	{
		IEnumerable<txx_Shop> getShops();
	}
}