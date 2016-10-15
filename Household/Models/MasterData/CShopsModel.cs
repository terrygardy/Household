using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Models.Chart;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CShopsModel
	{
		public CShopsModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cShop = new CShopManagement();
			var lstShops = cShop.getShops();
			var action = "Shop";
			var controller = "MasterData";
			var dtTable = new CDisplayTable()
			{
				AddAction = action,
				AddController = controller
			};
			var drHead = new CDisplayRow() {
				OnClickAction = action,
				OnClickController = controller
			};
			var drFoot = new CDisplayRow() {
				OnClickAction = action,
				OnClickController = controller
			};
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = ShopText.Name;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = ShopText.Description;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var txxShop in lstShops)
			{
				var strShop = txxShop.Name;
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxShop.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
				};

				if (!string.IsNullOrEmpty(txxShop.Description)) strShop += ", " + txxShop.Description;

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxShop.Name,
					CSS = "left",
					Tooltip = strShop
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxShop.Description,
					CSS = "left",
					Tooltip = strShop
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {lstShops.Count.ToString()}",
				CSS = "right",
				ColumnSpan = 2
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}

		public CShopChart GetCompareChartInfo(long pv_lngID, int pv_intYear)
		{
			var cPurchase = new CPurchaseManagement();
			var cShopChart = new CShopChart();

			cShopChart.name = new CShopManagement().getDataByID(pv_lngID).Name;

			foreach (var objInfo in cPurchase.getPurchaseInfoForShopChart(pv_lngID, pv_intYear))
			{
				while (cShopChart.data.Count < objInfo.Integer - 1) cShopChart.data.Add(null);

				cShopChart.data.Add(objInfo.Decimal);
			}

			while (cShopChart.data.Count < 12) cShopChart.data.Add(null);

			return cShopChart;
		}
	}
}