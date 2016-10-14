using Household.Localisation.Common;
using Household.Localisation.Main.Finance;
using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using GARTE.TypeHandling;

namespace Household.Models.Finance
{
	public class CExpensesModel
	{
		public CDisplayTable getDisplayTable()
		{
			var cExpense = new CExpenseManagement();
			var lstExpenses = cExpense.getExpenses();
			var action = "Expense";
			var controller = "Expenses";
			var dtTable = new CDisplayTable()
			{
				AddAction = action,
				AddController = controller
			};
			var drHead = new CDisplayRow()
			{
				OnClickAction = action,
				OnClickController = controller
			};
			var drFoot = new CDisplayRow()
			{
				OnClickAction = action,
				OnClickController = controller
			}; ;
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = GeneralText.From;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = GeneralText.Until;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = GeneralText.Who;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = ExpenseText.Source;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = ExpenseText.Amount;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tExpense in lstExpenses)
			{
				var strStartDate = Base.convertShortDateString(tExpense.StartDate, "...");
				var strEndDate = Base.convertShortDateString(tExpense.EndDate);
				var strDate = $"{GeneralText.FromLower} {strStartDate}";
				string strExpense, strSpender, strCompany, strAmount, strDay, strInterval;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tExpense.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
				};

				if (tExpense.Company_ID > 0)
				{
					strCompany = tExpense.txx_Company.Name;
				}
				else
				{
					strCompany = "";
				}

				if (tExpense.BankAccount_ID > 0)
				{
					strSpender = tExpense.txx_BankAccount.AccountName;
				}
				else
				{
					strSpender = "";
				}

				if (tExpense.PaymentDay_ID > 0)
				{
					strDay = tExpense.txx_Day.ToString();
				}
				else
				{
					strDay = "";
				}

				if (tExpense.Interval_ID > 0)
				{
					strInterval = tExpense.txx_Interval.ToString();
				}
				else
				{
					strInterval = "";
				}

				strDate = Strings.concatStrings(strDate, strEndDate, $" {GeneralText.UntilLower} ");

				strAmount = tExpense.Amount.ToString("C2");

				strExpense = strSpender;
				strExpense = Strings.concatStrings(strExpense, strCompany, " - ");
				strExpense = Strings.concatStrings(strExpense, strAmount, " - ");
				strExpense = Strings.concatStrings(strExpense, strDay, $" - {GeneralText.OnLower} ");
				strExpense = Strings.concatStrings(strExpense, strInterval, " ");
				strExpense = Strings.concatStrings(strExpense, tExpense.Description, ", ");
				strExpense = Strings.concatStrings(strDate, strExpense, ", ");

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tExpense.StartDate,
					CSS = "center",
					Tooltip = strExpense
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tExpense.EndDate,
					CSS = "center",
					Tooltip = strExpense
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strSpender,
					CSS = "left",
					Tooltip = strExpense
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strCompany,
					CSS = "left",
					Tooltip = strExpense
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tExpense.Amount,
					CSS = "right",
					Tooltip = strExpense
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {lstExpenses.Count.ToString()}",
				CSS = "right",
				ColumnSpan = 5
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}