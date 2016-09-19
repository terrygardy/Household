using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class ShopController : CRUDController<txx_Shop, IShopManagement, string, string, CShopData>
	{
		public ShopController(IShopManagement management) : base(management) { }

		protected override long GetDataID(CShopData data)
		{
			return data.ID;
		}
	}
}