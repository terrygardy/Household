using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Models.Chart;
using System.Collections.Generic;
using Household.Models.Search;
using System.Linq.Expressions;
using System;
using System.Linq;
using GARTE.TypeHandling;

namespace Household.Models.Finance
{
	public class CPurchasesModel
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);

		public CPurchasesModel() { }

		public CDisplayTable getDisplayTable()
		{
			return getDisplayTable(null);
		}

		public CDisplayTable getDisplayTable(Expression<Func<t_Purchase, bool>> exSearch)
		{
			var cPurchase = new CPurchase();
			var lstPurchases = cPurchase.getPurchases(exSearch);
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Purchase",
				OnClickController = "Purchases"
			};
			var drHead = new CDisplayRow();
			var drFeet = new List<CDisplayRow>();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Date";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Who";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Where";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Amount";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tPurchase in lstPurchases)
			{
				var strDate = Base.convertShortDateString(tPurchase.Occurrence);
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

			var drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstPurchases.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstPurchases.Count.ToString(),
				ColumnSpan = 4
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			var sumPurchases = lstPurchases.Sum(x => x.Amount).ToString("C2");

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Sum: " + sumPurchases,
				CSS = "right",
				Tooltip = "Sum: " + sumPurchases,
				ColumnSpan = 4
			});

			drFeet.Add(drFoot);
			dtTable.Foot = drFeet;

			return dtTable;
		}

		public CYearChart GetYearCompareChartInfo(int pv_intYear)
		{
			var cYearChart = new CYearChart();

			cYearChart.name = pv_intYear.ToString();

			cYearChart.data = new List<object>() { pv_intYear.ToString(), new CPurchase().getSumByYear(pv_intYear) };

			return cYearChart;
		}

		public CDisplayTable search(CSearchPurchase pv_spSearch)
		{
			pv_spSearch.Description = Base.convertString(pv_spSearch.Description).ToLower();
			pv_spSearch.From = Base.convertDate(pv_spSearch.From);
			pv_spSearch.To = Base.convertDate(pv_spSearch.To);
			pv_spSearch.Where = Base.convertString(pv_spSearch.Where).ToLower();
			pv_spSearch.Who = Base.convertString(pv_spSearch.Who).ToLower();

			return getDisplayTable(x => (((pv_spSearch.To <= m_datNull) || (x.Occurrence <= pv_spSearch.To))
									&& ((pv_spSearch.From <= m_datNull) || (x.Occurrence >= pv_spSearch.From))
									&& ((pv_spSearch.Where.Length < 1) || (x.txx_Shop.Name.ToLower().Contains(pv_spSearch.Where)))
									&& ((pv_spSearch.Who.Length < 1)
									|| (x.txx_BankAccount.AccountName.ToLower().Contains(pv_spSearch.Who))
									|| (x.txx_BankAccount.IBAN.ToLower().Contains(pv_spSearch.Who))
									|| (x.txx_BankAccount.BIC.ToLower().Contains(pv_spSearch.Who)))
									&& ((pv_spSearch.Description.Length < 1) || (x.Description.ToLower().Contains(pv_spSearch.Description)))
									&& ((pv_spSearch.Amount <= 0) || (x.Amount == pv_spSearch.Amount))));
		}
	}
}