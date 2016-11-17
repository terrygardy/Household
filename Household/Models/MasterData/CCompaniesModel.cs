using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using Household.BL.Functions.Management.txx;
using System.Linq;

namespace Household.Models.MasterData
{
	public class CCompaniesModel
	{
		private readonly ICompanyManagement _companyManagement;

		public CCompaniesModel(ICompanyManagement companyManagement)
		{
			_companyManagement = companyManagement;
		}

		public CDisplayTable getDisplayTable()
		{
			var lstCompanies = _companyManagement.getCompanies();
			var action = "Company";
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

			dcColumn.Content = CompanyText.Name;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = CompanyText.Description;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var txxCompany in lstCompanies)
			{
				var strCompany = txxCompany.Name;
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxCompany.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
				};

				if (!string.IsNullOrEmpty(txxCompany.Description)) strCompany += ", " + txxCompany.Description;

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxCompany.Name,
					CSS = "left",
					Tooltip = strCompany
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = txxCompany.Description,
					CSS = "left",
					Tooltip = strCompany
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {lstCompanies.Count().ToString()}",
				CSS = "right",
				ColumnSpan = 2
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}