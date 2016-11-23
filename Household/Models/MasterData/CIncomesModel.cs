using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using System;
using System.Linq;
using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Interfaces;

namespace Household.Models.MasterData
{
	public class CIncomesModel
	{
		private DateTime DatNULL { get { return new DateTime(1753, 1, 1, 0, 0, 0); } }
		private readonly IIncomeManagement _incomeManagement;
		private readonly ICompanyManagement _companyManagement;

		public CIncomesModel(IIncomeManagement incomeManagement,
			ICompanyManagement companyManagement)
		{
			_incomeManagement = incomeManagement;
			_companyManagement = companyManagement;
		}

		public CDisplayTable getDisplayTable()
		{
			var lstIncomes = _incomeManagement.getIncomes();
			var action = "Income";
			var controller = "MasterData";
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
			};
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = IncomeText.Start;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = IncomeText.End;
			dcColumn.CSS = "hideable";
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

				if (tIncome.txx_Company != null) strCompany = _companyManagement.getDataByID((long)tIncome.Company_ID).Name;

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
					CSS = "center hideable",
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
					Content = tIncome.txx_Company,
					CSS = "left",
					Tooltip = strIncome
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {lstIncomes.Count().ToString()}",
				CSS = "right",
				ColumnSpan = 4
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}