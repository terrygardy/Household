using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using Household.Data.Context;
using GARTE.TypeHandling;

namespace Household.Models.Finance
{
	public class CExpensesModel
	{
		private Database DbHousehold { get; set; }

		public CExpensesModel(Database pv_dbHousehold) { DbHousehold = pv_dbHousehold; }

		public CDisplayTable getDisplayTable()
		{
			var cExpense = new CExpense(DbHousehold);
			var lstExpenses = cExpense.getExpenses();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Expense",
				OnClickController = "Expenses"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "From";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Until";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Who";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Source";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Amount";
			dcColumn.CSS = "right";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tExpense in lstExpenses)
			{
				var strStartDate = Base.convertShortDateString(tExpense.StartDate, "...");
				var strEndDate = Base.convertShortDateString(tExpense.EndDate);
				var strDate = "from " + strStartDate;
				string strExpense, strSpender, strCompany, strAmount, strDay, strInterval;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tExpense.ID.ToString()
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

				strDate = Strings.concatStrings(strDate, strEndDate, " until ");

				strAmount = tExpense.Amount.ToString("C2");

				strExpense = strSpender;
				strExpense = Strings.concatStrings(strExpense, strCompany, " - ");
				strExpense = Strings.concatStrings(strExpense, strAmount, " - ");
				strExpense = Strings.concatStrings(strExpense, strDay, " - on ");
				strExpense = Strings.concatStrings(strExpense, strInterval, " ");
				strExpense = Strings.concatStrings(strExpense, tExpense.Description, ", ");
				strExpense = Strings.concatStrings(strDate, strExpense, ", ");

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strStartDate,
					CSS = "center",
					Tooltip = strExpense
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strEndDate,
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
					Content = strAmount,
					CSS = "right",
					Tooltip = strExpense
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstExpenses.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstExpenses.Count.ToString(),
				ColumnSpan = 5
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}