using Household.BL.Functions.txx;
using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Controllers.Base;

namespace Household.Controllers
{
	public class ShopController : CRUDController<txx_Shop, CShop, string, string, CShopData>
	{
		protected override long GetDataID(CShopData data)
		{
			return data.ID;
		}
	}
}