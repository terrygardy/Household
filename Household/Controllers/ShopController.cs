using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class ShopController : CRUDController<txx_Shop, IShopManagement, CShopData>
	{
		public ShopController(IShopManagement management) : base(management) { }
	}
}