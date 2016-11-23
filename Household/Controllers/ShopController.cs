using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Management.txx.Interfaces;
using Household.BL.DATA.txx.Implementations;

namespace Household.Controllers
{
	public class ShopController : CRUDController<txx_Shop, IShopManagement, CShopData>
	{
		public ShopController(IShopManagement management) : base(management) { }
	}
}