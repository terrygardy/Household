using Household.BL.Functions.txx;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CCompaniesModel
	{
		public CCompaniesModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cCompany = new CCompany();
			var lstCompanies = cCompany.getCompanies();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Company",
				OnClickController = "MasterData"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Name";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Description";
			dcColumn.CSS = "left";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var txxCompany in lstCompanies)
			{
				var strCompany = txxCompany.Name;
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxCompany.ID.ToString()
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
				Content = "Count: " + lstCompanies.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstCompanies.Count.ToString(),
				ColumnSpan = 2
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}