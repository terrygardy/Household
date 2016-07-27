using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Models.Chart;
using System.Collections.Generic;
using Household.Models.Search;
using System.Linq.Expressions;
using System;

namespace Household.Models.Finance
{
	public class CPurchasesModel
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);
		private Database DbHousehold { get; set; }

		public CPurchasesModel(Database pv_dbHousehold) { DbHousehold = pv_dbHousehold; }

		public CDisplayTable getDisplayTable()
		{
			var cPurchase = new CPurchase(DbHousehold);
			var lstPurchases = cPurchase.getPurchases();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Purchase",
				OnClickController = "Purchases"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Date";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Who";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Where";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Amount";
			dcColumn.CSS = "right";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tPurchase in lstPurchases)
			{
				var strDate = GARTE.TypeHandling.Base.convertShortDateString(tPurchase.Occurrence);
				string strPurchase, strBuyer, strShop, strAmount;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tPurchase.ID.ToString()
				};

				if (tPurchase.Shop_ID > 0)
				{
					strShop = tPurchase.txx_Shop.Name;
				}
				else
				{
					strShop = "";
				}

				if (tPurchase.Payer_ID > 0)
				{
					strBuyer = tPurchase.txx_BankAccount.AccountName;
				}
				else
				{
					strBuyer = "";
				}

				strAmount = tPurchase.Amount.ToString("C2");

				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strBuyer, strShop, " - ");
				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strPurchase, strAmount, " - ");
				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strDate, strPurchase, ", ");
				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strPurchase, tPurchase.Description, ", ");

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strDate,
					CSS = "center",
					Tooltip = strPurchase
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strBuyer,
					CSS = "left",
					Tooltip = strPurchase
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strShop,
					CSS = "left",
					Tooltip = strPurchase
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strAmount,
					CSS = "right",
					Tooltip = strPurchase
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstPurchases.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstPurchases.Count.ToString(),
				ColumnSpan = 4
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}

		public CYearChart GetYearCompareChartInfo(int pv_intYear)
		{
			var cYearChart = new CYearChart();

			cYearChart.name = pv_intYear.ToString();

			cYearChart.data = new List<object>() { pv_intYear.ToString(), new CPurchase(DbHousehold).getSumByYear(pv_intYear) };

			return cYearChart;
		}

		public CDisplayTable search(CSearchPurchase pv_spSearch)
		{
			var cPurchase = new CPurchase(DbHousehold);
			Expression<Func<t_Purchase, bool>> exSearch;
			List<t_Purchase> lstPurchases;
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Purchase",
				OnClickController = "Purchases"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			pv_spSearch.Description = GARTE.TypeHandling.Base.convertString(pv_spSearch.Description).ToLower();
			pv_spSearch.From = GARTE.TypeHandling.Base.convertDate(pv_spSearch.From);
			pv_spSearch.To = GARTE.TypeHandling.Base.convertDate(pv_spSearch.To);
			pv_spSearch.Where = GARTE.TypeHandling.Base.convertString(pv_spSearch.Where).ToLower();
			pv_spSearch.Who = GARTE.TypeHandling.Base.convertString(pv_spSearch.Who).ToLower();

			exSearch = x => (((pv_spSearch.To <= m_datNull) || (x.Occurrence <= pv_spSearch.To))
			&& ((pv_spSearch.From <= m_datNull) || (x.Occurrence >= pv_spSearch.From))
			&& ((pv_spSearch.Where.Length < 1) || (x.txx_Shop.Name.ToLower().Contains(pv_spSearch.Where)))
			&& ((pv_spSearch.Who.Length < 1)
			|| (x.txx_BankAccount.AccountName.ToLower().Contains(pv_spSearch.Who))
			|| (x.txx_BankAccount.IBAN.ToLower().Contains(pv_spSearch.Who))
			|| (x.txx_BankAccount.BIC.ToLower().Contains(pv_spSearch.Who)))
			&& ((pv_spSearch.Description.Length < 1) || (x.Description.ToLower().Contains(pv_spSearch.Description)))
			&& ((pv_spSearch.Amount <= 0) || (x.Amount == pv_spSearch.Amount)));

			lstPurchases = cPurchase.getPurchases(exSearch);

			dcColumn.Content = "Date";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Who";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Where";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Amount";
			dcColumn.CSS = "right";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tPurchase in lstPurchases)
			{
				var strDate = GARTE.TypeHandling.Base.convertShortDateString(tPurchase.Occurrence);
				string strPurchase, strBuyer, strShop, strAmount;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tPurchase.ID.ToString()
				};

				if (tPurchase.Shop_ID > 0)
				{
					strShop = tPurchase.txx_Shop.Name;
				}
				else
				{
					strShop = "";
				}

				if (tPurchase.Payer_ID > 0)
				{
					strBuyer = tPurchase.txx_BankAccount.AccountName;
				}
				else
				{
					strBuyer = "";
				}

				strAmount = tPurchase.Amount.ToString("C2");

				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strBuyer, strShop, " - ");
				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strPurchase, strAmount, " - ");
				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strDate, strPurchase, ", ");
				strPurchase = GARTE.TypeHandling.Strings.concatStrings(strPurchase, tPurchase.Description, ", ");

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strDate,
					CSS = "center",
					Tooltip = strPurchase
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strBuyer,
					CSS = "left",
					Tooltip = strPurchase
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strShop,
					CSS = "left",
					Tooltip = strPurchase
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strAmount,
					CSS = "right",
					Tooltip = strPurchase
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstPurchases.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstPurchases.Count.ToString(),
				ColumnSpan = 4
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}