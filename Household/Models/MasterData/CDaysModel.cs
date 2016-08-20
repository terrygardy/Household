using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CDaysModel
	{
		

		public CDaysModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cDay = new CDay();
			var lstDays = cDay.getDays();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Day",
				OnClickController = "MasterData"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();

			drHead.Columns.Add(new CDisplayColumn()
			{
				Content = "Day",
				Tooltip = "Day"
			});

			dtTable.Head.Add(drHead);

			foreach (var txxDay in lstDays)
			{
				var strDay = txxDay.Day.ToString();
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxDay.ID.ToString()
				};

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strDay,
					CSS = "left",
					Tooltip = strDay
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstDays.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstDays.Count.ToString(),
				ColumnSpan = 1
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}