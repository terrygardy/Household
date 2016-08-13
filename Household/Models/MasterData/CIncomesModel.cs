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
			var cIncome = new CIncome();
			var lstIncomes = cIncome.getIncomes();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Income",
				OnClickController = "MasterData"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();
			var cCompany = new CCompany();

			dcColumn.Content = "Start";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "End";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Amount";
			dcColumn.CSS = "right";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Company";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tIncome in lstIncomes)
			{
				var strIncome = tIncome.StartDate.ToShortDateString();
				var strEndDate = "";
				var strAmount = tIncome.Amount.ToString("C");
				var strCompany = "unknown";
				var drBody = new CDisplayRow()
				{
					OnClickParam = tIncome.ID.ToString()
				};

				if ((tIncome.Company_ID != null) && (tIncome.Company_ID > 0)) strCompany = cCompany.getDataByID((long)tIncome.Company_ID).Name;

				if ((tIncome.EndDate != null) && (tIncome.EndDate > DatNULL))
				{
					strEndDate = ((DateTime)tIncome.EndDate).ToShortDateString();
					strIncome += " - " + strEndDate;
				}

				strIncome += ", " + strAmount + ", from " + strCompany;

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tIncome.StartDate.ToShortDateString(),
					CSS = "center",
					Tooltip = strIncome
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strEndDate,
					CSS = "center",
					Tooltip = strIncome
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strAmount,
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
				Content = "Count: " + lstIncomes.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstIncomes.Count.ToString(),
				ColumnSpan = 4
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}