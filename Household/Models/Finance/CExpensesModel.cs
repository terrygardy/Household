using Household.Localisation.Common;
using Household.Localisation.Main.Finance;
using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using GARTE.TypeHandling;
using Household.Models.Interfaces;
using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Household.Models.Search;

namespace Household.Models.Finance
{
	public class CExpensesModel : ISearchModel<t_Expense, CSearchExpense>
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);

		public CDisplayTable GetDisplayTable(string actionMain, string controller) => GetDisplayTable(null, actionMain, controller);

		public CDisplayTable GetDisplayTable(Expression<Func<t_Expense, bool>> exSearch, string actionMain, string controller)
		{
			var cExpense = new CExpenseManagement();
			var lstExpenses = cExpense.getExpenses(exSearch);
			var dtTable = new CDisplayTable()
			{
				AddAction = actionMain,
				AddController = controller
			};

			dtTable.Head = CreateTableHead(actionMain, controller);
			dtTable.Body = CreateTableBody(actionMain, controller, lstExpenses);
			dtTable.Foot = CreateTableFooter(actionMain, controller, lstExpenses.Count, lstExpenses.Sum(e => e.Amount));

			return dtTable;
		}

		public CDisplayRow CreateBodyRow(string actionMain, string controller, t_Expense tEntity)
		{
			var strStartDate = Base.convertShortDateString(tEntity.StartDate, "...");
			var strEndDate = Base.convertShortDateString(tEntity.EndDate);
			var strDate = $"{GeneralText.FromLower} {strStartDate}";
			string strExpense, strSpender, strCompany, strAmount, strDay, strInterval;
			var drBody = new CDisplayRow()
			{
				OnClickParam = tEntity.ID.ToString(),
				OnClickAction = actionMain,
				OnClickController = controller
			};

			if (tEntity.txx_Company != null)
			{
				strCompany = tEntity.txx_Company.Name;
			}
			else
			{
				strCompany = "";
			}

			if (tEntity.txx_BankAccount != null)
			{
				strSpender = tEntity.txx_BankAccount.AccountName;
			}
			else
			{
				strSpender = "";
			}

			if (tEntity.txx_Day != null)
			{
				strDay = tEntity.txx_Day.ToString();
			}
			else
			{
				strDay = "";
			}

			if (tEntity.txx_Interval != null)
			{
				strInterval = tEntity.txx_Interval.ToString();
			}
			else
			{
				strInterval = "";
			}

			strDate = Strings.concatStrings(strDate, strEndDate, $" {GeneralText.UntilLower} ");

			strAmount = tEntity.Amount.ToString("C2");

			strExpense = strSpender;
			strExpense = Strings.concatStrings(strExpense, strCompany, " - ");
			strExpense = Strings.concatStrings(strExpense, strAmount, " - ");
			strExpense = Strings.concatStrings(strExpense, strDay, $" - {GeneralText.OnLower} ");
			strExpense = Strings.concatStrings(strExpense, strInterval, " ");
			strExpense = Strings.concatStrings(strExpense, tEntity.Description, ", ");
			strExpense = Strings.concatStrings(strDate, strExpense, ", ");

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tEntity.StartDate,
				CSS = "center",
				Tooltip = strExpense
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tEntity.EndDate,
				CSS = "center hideable",
				Tooltip = strExpense
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tEntity.txx_BankAccount,
				CSS = "left hideable",
				Tooltip = strExpense
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tEntity.txx_Company,
				CSS = "left",
				Tooltip = strExpense
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tEntity.Amount,
				CSS = "right",
				Tooltip = strExpense
			});

			return drBody;
		}

		public List<CDisplayRow> CreateTableBody(string actionMain, string controller, List<t_Expense> lstEntities)
		{
			var lstBody = new List<CDisplayRow>();

			foreach (var tExpense in lstEntities)
			{
				lstBody.Add(CreateBodyRow(actionMain, controller, tExpense));
			}

			return lstBody;
		}

		public List<CDisplayRow> CreateTableFooter(string actionMain, string controller, int count, decimal sum)
		{
			var drFeet = new List<CDisplayRow>();
			var drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				CSS = "hideable",
				ColumnSpan = 2
			});

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {count.ToString()}",
				CSS = "right",
				ColumnSpan = 3
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			var sumExpenses = sum.ToString("C2");

			drFoot.Columns.Add(new CDisplayColumn()
			{
				CSS = "hideable",
				ColumnSpan = 2
			});

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Sum}: {sumExpenses}",
				CSS = "right",
				ColumnSpan = 3
			});

			drFeet.Add(drFoot);

			return drFeet;
		}

		public List<CDisplayRow> CreateTableHead(string actionMain, string controller)
		{
			var drHead = new CDisplayRow()
			{
				OnClickAction = actionMain,
				OnClickController = controller
			};

			var dcColumn = new CDisplayColumn();

			dcColumn.Content = GeneralText.From;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = GeneralText.Until;
			dcColumn.CSS = "hideable";
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = GeneralText.Who;
			dcColumn.CSS = "hideable";
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = ExpenseText.Source;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = ExpenseText.Amount;
			drHead.Columns.Add(dcColumn);

			return new List<CDisplayRow> { drHead };
		}

		public CDisplayTable Search(CSearchExpense pv_smSearch, string actionMain, string controller)
		{
			return GetDisplayTable(GetSearchExpression(pv_smSearch), actionMain, controller);
		}

		public Expression<Func<t_Expense, bool>> GetSearchExpression(CSearchExpense pv_spSearch)
		{
			pv_spSearch.Description = Base.convertString(pv_spSearch.Description).ToLower();
			pv_spSearch.StartDate = Base.convertDate(pv_spSearch.StartDate);
			pv_spSearch.EndDate = Base.convertDate(pv_spSearch.EndDate);
			pv_spSearch.Company = Base.convertString(pv_spSearch.Company).ToLower();
			pv_spSearch.Who = Base.convertString(pv_spSearch.Who).ToLower();

			return x => (((pv_spSearch.EndDate <= m_datNull) || (x.EndDate <= pv_spSearch.EndDate))
									&& ((pv_spSearch.StartDate <= m_datNull) || (x.StartDate >= pv_spSearch.StartDate))
									&& ((pv_spSearch.Company.Length < 1) || (x.txx_Company.Name.ToLower().Contains(pv_spSearch.Company)))
									&& ((pv_spSearch.Who.Length < 1)
									|| (x.txx_BankAccount.AccountName.ToLower().Contains(pv_spSearch.Who))
									|| (x.txx_BankAccount.IBAN.ToLower().Contains(pv_spSearch.Who))
									|| (x.txx_BankAccount.BIC.ToLower().Contains(pv_spSearch.Who)))
									&& ((pv_spSearch.Description.Length < 1) || (x.Description.ToLower().Contains(pv_spSearch.Description)))
									&& ((pv_spSearch.Amount <= 0) || (x.Amount == pv_spSearch.Amount)));
		}
	}
}