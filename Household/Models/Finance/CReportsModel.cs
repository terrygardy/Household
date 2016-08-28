using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Models.Chart;
using Household.Models.MasterData;
using System.Collections.Generic;

namespace Household.Models.Finance
{
	public class CReportsModel
	{
		public List<txx_Shop> Shops { get; set; }

		public CReportsModel() { }
		public CReportsModel(bool pv_blnFill)
		{
			if (pv_blnFill) FillShops();
		}

		public CShopChart GetShopCompareChartInfo(long pv_lngShopID, int pv_intYear)
		{
			return new CShopsModel().GetCompareChartInfo(pv_lngShopID, pv_intYear);
		}

		public CYearChart GetYearCompareChartInfo(int pv_intYear)
		{
			return new CPurchasesModel().GetYearCompareChartInfo(pv_intYear);
		}

		public void FillShops()
		{
			Shops = new CShopManagement().getShops();
		}
	}
}