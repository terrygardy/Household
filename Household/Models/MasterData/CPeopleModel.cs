using Household.BL.Functions.t;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CPeopleModel
	{
		public CPeopleModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cPerson = new CPerson();
			var lstPeople = cPerson.getPeople();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Person",
				OnClickController = "MasterData"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Surname";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Forename";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tPerson in lstPeople)
			{
				var strPerson = tPerson.Surname;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tPerson.ID.ToString()
				};

				if (!string.IsNullOrEmpty(tPerson.Forename)) strPerson += ", " + tPerson.Forename;

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tPerson.Surname,
					CSS = "left",
					Tooltip = strPerson
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tPerson.Forename,
					CSS = "left",
					Tooltip = strPerson
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstPeople.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstPeople.Count.ToString(),
				ColumnSpan = 2
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}