using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Models.DisplayTable;
using System;

namespace Household.Models.MasterData
{
	public class CIncomesModel
	{
		private DateTime DatNULL { get { return new DateTime(1753, 1, 1, 0, 0, 0); } }

		public CIncomesModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cIncome = new CIncomeManagement();
			var lstIncomes = cIncome.getIncomes();
			var action = "Income";
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
			var cCompany = new CCompanyManagement();

			dcColumn.Content = IncomeText.Start;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = IncomeText.End;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = IncomeText.Amount;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = CompanyText.Company;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tIncome in lstIncomes)
			{
				var strIncome = tIncome.StartDate.ToShortDateString();
				var strEndDate = "";
				var strAmount = tIncome.Amount.ToString("C");
				var strCompany = GeneralText.UnknownLower;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tIncome.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
				};

				if ((tIncome.Company_ID != null) && (tIncome.Company_ID > 0)) strCompany = cCompany.getDataByID((long)tIncome.Company_ID).Name;

				if ((tIncome.EndDate != null) && (tIncome.EndDate > DatNULL))
				{
					strEndDate = ((DateTime)tIncome.EndDate).ToShortDateString();
					strIncome += " - " + strEndDate;
				}

				strIncome += $", {strAmount}, {GeneralText.FromLower} {strCompany}";

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tIncome.StartDate,
					CSS = "center",
					Tooltip = strIncome
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tIncome.EndDate,
					CSS = "center",
					Tooltip = strIncome
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tIncome.Amount,
					CSS = "right",
					Tooltip = strIncome
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strCompany,
					CSS = "left",
					Tooltip = strIncome
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {lstIncomes.Count.ToString()}",
				CSS = "right",
				ColumnSpan = 4
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}