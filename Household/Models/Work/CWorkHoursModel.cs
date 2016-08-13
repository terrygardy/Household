using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using Household.Data.Context;
using GARTE.TypeHandling;

namespace Household.Models.Work
{
	public class CWorkHoursModel
	{
		private Database DbHousehold { get; set; }

		public CWorkHoursModel(Database pv_dbHousehold) { DbHousehold = pv_dbHousehold; }

		public CDisplayTable getDisplayTable()
		{
			var cWorkDay = new CWorkDay(DbHousehold);
			var lstWorkDays = cWorkDay.getWorkingDays();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "WorkDay",
				OnClickController = "Work"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Day";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Begin";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "End";
			dcColumn.CSS = "center";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Break [h]";
			dcColumn.CSS = "right";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Worked [h]";
			dcColumn.CSS = "right";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tWorkDay in lstWorkDays)
			{
				var strDay = Base.convertShortDateString(tWorkDay.WorkDay, "...");
				var strBegin = Base.convertShortTimeString(tWorkDay.Begin, "...");
				var strEnd = Base.convertShortTimeString(tWorkDay.End, "...");
				var strTooltip = $"{strDay}: from {strBegin}";
				var drBody = new CDisplayRow()
				{
					OnClickParam = tWorkDay.ID.ToString()
				};

				strTooltip = Strings.concatStrings(strTooltip, strEnd, " until ");

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strDay,
					CSS = "center",
					Tooltip = strTooltip
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strBegin,
					CSS = "center",
					Tooltip = strTooltip
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strEnd,
					CSS = "center",
					Tooltip = strTooltip
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tWorkDay.BreakDuration.ToString(),
					CSS = "right",
					Tooltip = strTooltip
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tWorkDay.HoursWorked.ToString(),
					CSS = "right",
					Tooltip = strTooltip
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstWorkDays.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstWorkDays.Count.ToString(),
				ColumnSpan = 5
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}