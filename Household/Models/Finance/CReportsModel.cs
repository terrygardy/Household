using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Interfaces;
using Household.Data.Context;
using Household.Models.Chart;
using Household.Models.MasterData;
using System.Collections.Generic;
using System.Linq;

namespace Household.Models.Finance
{
	public class CReportsModel
	{
		public List<txx_Shop> Shops { get; set; }
		private readonly IShopManagement _shopManagement;

		public CReportsModel(IShopManagement shopManagement) { _shopManagement = shopManagement; }

		public CReportsModel(IShopManagement shopManagement, bool pv_blnFill)
			: this(shopManagement)
		{
			if (pv_blnFill) FillShops(_shopManagement);
		}

		public CShopChart GetShopCompareChartInfo(IPurchaseManagement purchaseManagement, long pv_lngShopID, int pv_intYear)
		{
			return new CShopsModel(_shopManagement).GetCompareChartInfo(purchaseManagement, pv_lngShopID, pv_intYear);
		}

		public CYearChart GetYearCompareChartInfo(IPurchaseManagement purchaseManagement, int pv_intYear)
		{
			return new CPurchasesModel(purchaseManagement).GetYearCompareChartInfo(pv_intYear);
		}

		public void FillShops(IShopManagement shopManagement)
		{
			Shops = shopManagement.getShops().ToList();
		}
	}
}