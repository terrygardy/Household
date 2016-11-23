using Household.Localisation.Main.Finance;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using Household.Data.Context;
using Household.Models.Chart;
using System.Collections.Generic;
using Household.Models.Search;
using System.Linq.Expressions;
using System;
using System.Linq;
using GARTE.TypeHandling;
using Household.Models.Interfaces;
using Household.BL.Management.t.Interfaces;

namespace Household.Models.Finance
{
	public class CPurchasesModel : ISearchModel<t_Purchase, CSearchPurchase>
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);
		private readonly IPurchaseManagement _purchaseManagement;

		public CPurchasesModel(IPurchaseManagement purchaseManagement)
		{
			_purchaseManagement = purchaseManagement;
		}

		public CDisplayTable GetDisplayTable(string actionMain, string controller) => GetDisplayTable(null, actionMain, controller);

		public CDisplayTable GetDisplayTable(Expression<Func<t_Purchase, bool>> exSearch, string actionMain, string controller)
		{
			var lstPurchases = _purchaseManagement.getPurchases(exSearch);
			var dtTable = new CDisplayTable()
			{
				AddAction = actionMain,
				AddController = controller
			};

			dtTable.Head = CreateTableHead(actionMain, controller);
			dtTable.Body = CreateTableBody(actionMain, controller, lstPurchases);
			dtTable.Foot = CreateTableFooter(actionMain, controller, lstPurchases.Count(), lstPurchases.Sum(x => x.Amount));

			return dtTable;
		}

		public List<CDisplayRow> CreateTableHead(string actionMain, string controller)
		{
			var drHead = new CDisplayRow()
			{
				OnClickAction = actionMain,
				OnClickController = controller
			};

			var dcColumn = new CDisplayColumn();

			dcColumn.Content = PurchaseText.Occurrence;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = GeneralText.Who;
			dcColumn.CSS = "hideable";
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = GeneralText.Where;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = PurchaseText.Amount;
			drHead.Columns.Add(dcColumn);

			return new List<CDisplayRow> { drHead };
		}

		public List<CDisplayRow> CreateTableFooter(string actionMain, string controller, int count, decimal sum)
		{
			var drFeet = new List<CDisplayRow>();
			var drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				CSS = "hideable",
				ColumnSpan = 1
			});

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {count.ToString()}",
				CSS = "right",
				ColumnSpan = 3
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			var sumPurchases = sum.ToString("C2");

			drFoot.Columns.Add(new CDisplayColumn()
			{
				CSS = "hideable",
				ColumnSpan = 1
			});

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Sum}: {sumPurchases}",
				CSS = "right",
				ColumnSpan = 3
			});

			drFeet.Add(drFoot);

			return drFeet;
		}

		public List<CDisplayRow> CreateTableBody(string actionMain, string controller, IEnumerable<t_Purchase> lstEntities)
		{

			var lstBody = new List<CDisplayRow>();

			foreach (var tPurchase in lstEntities)
			{
				lstBody.Add(CreateBodyRow(actionMain, controller, tPurchase));
			}

			return lstBody;
		}

		public CDisplayRow CreateBodyRow(string actionMain, string controller, t_Purchase tPurchase)
		{
			var strDate = Base.convertShortDateString(tPurchase.Occurrence);
			string strPurchase, strBuyer, strShop, strAmount;
			var drBody = new CDisplayRow()
			{
				OnClickParam = tPurchase.ID.ToString(),
				OnClickAction = actionMain,
				OnClickController = controller
			};

			if (tPurchase.txx_Shop != null)
			{
				strShop = tPurchase.txx_Shop.Name;
			}
			else
			{
				strShop = "";
			}

			if (tPurchase.txx_BankAccount != null)
			{
				strBuyer = tPurchase.txx_BankAccount.AccountName;
			}
			else
			{
				strBuyer = "";
			}

			strAmount = tPurchase.Amount.ToString("C2");

			strPurchase = Strings.concatStrings(strBuyer, strShop, " - ");
			strPurchase = Strings.concatStrings(strPurchase, strAmount, " - ");
			strPurchase = Strings.concatStrings(strDate, strPurchase, ", ");
			strPurchase = Strings.concatStrings(strPurchase, tPurchase.Description, ", ");

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tPurchase.Occurrence,
				CSS = "center",
				Tooltip = strPurchase
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tPurchase.txx_BankAccount,
				CSS = "left hideable",
				Tooltip = strPurchase
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tPurchase.txx_Shop,
				CSS = "left",
				Tooltip = strPurchase
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tPurchase.Amount,
				CSS = "right",
				Tooltip = strPurchase
			});

			return drBody;
		}

		public CYearChart GetYearCompareChartInfo(int pv_intYear)
		{
			var cYearChart = new CYearChart();

			cYearChart.name = pv_intYear.ToString();

			cYearChart.data = new List<object>() { pv_intYear.ToString(), _purchaseManagement.getSumByYear(pv_intYear) };

			return cYearChart;
		}

		public CDisplayTable Search(CSearchPurchase pv_spSearch, string actionMain, string controller)
		{
			return GetDisplayTable(GetSearchExpression(pv_spSearch), actionMain, controller);
		}

		public Expression<Func<t_Purchase, bool>> GetSearchExpression(CSearchPurchase pv_spSearch)
		{
			pv_spSearch.Description = Base.convertString(pv_spSearch.Description).ToLower();
			pv_spSearch.From = Base.convertDate(pv_spSearch.From);
			pv_spSearch.To = Base.convertDate(pv_spSearch.To);
			pv_spSearch.Where = Base.convertString(pv_spSearch.Where).ToLower();
			pv_spSearch.Who = Base.convertString(pv_spSearch.Who).ToLower();

			return x => (((pv_spSearch.To <= m_datNull) || (x.Occurrence <= pv_spSearch.To))
									&& ((pv_spSearch.From <= m_datNull) || (x.Occurrence >= pv_spSearch.From))
									&& ((pv_spSearch.Where.Length < 1) || (x.txx_Shop.Name.ToLower().Contains(pv_spSearch.Where)))
									&& ((pv_spSearch.Who.Length < 1)
									|| (x.txx_BankAccount.AccountName.ToLower().Contains(pv_spSearch.Who))
									|| (x.txx_BankAccount.IBAN.ToLower().Contains(pv_spSearch.Who))
									|| (x.txx_BankAccount.BIC.ToLower().Contains(pv_spSearch.Who)))
									&& ((pv_spSearch.Description.Length < 1) || (x.Description.ToLower().Contains(pv_spSearch.Description)))
									&& ((pv_spSearch.Amount <= 0) || (x.Amount == pv_spSearch.Amount)));
		}
	}
}