using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using Household.BL.Functions.Management.t;
using System.Linq;

namespace Household.Models.MasterData
{
	public class CPeopleModel
	{
		private readonly IPersonManagement _personManagement;

		public CPeopleModel(IPersonManagement personManagement) {
			_personManagement = personManagement;
		}

		public CDisplayTable getDisplayTable()
		{
			var lstPeople = _personManagement.getPeople();
			var action = "Person";
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

			dcColumn.Content = PersonText.Surname;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = PersonText.Forename;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tPerson in lstPeople)
			{
				var strPerson = tPerson.Surname;
				var drBody = new CDisplayRow()
				{
					OnClickParam = tPerson.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
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
				Content = $"{GeneralText.Count}: {lstPeople.Count().ToString()}",
				CSS = "right",
				ColumnSpan = 2
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}