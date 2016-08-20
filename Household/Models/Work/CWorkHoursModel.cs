using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using GARTE.TypeHandling;
using System.Linq;
using System.Collections.Generic;

namespace Household.Models.Work
{
	public class CWorkHoursModel
	{
		public CWorkHoursModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cWorkDay = new CWorkDay();
			var lstWorkDays = cWorkDay.getWorkingDays();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "WorkDay",
				OnClickController = "Work"
			};
			var drHead = new CDisplayRow();
			var drFeet = new List<CDisplayRow>();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = "Day";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Begin";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "End";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Break [h]";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = "Worked [h]";
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
					Content = tWorkDay.BreakDuration.ToString("N2"),
					CSS = "right",
					Tooltip = strTooltip
				});

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = tWorkDay.HoursWorked.ToString("N2"),
					CSS = "right",
					Tooltip = strTooltip
				});

				dtTable.Body.Add(drBody);
			}

			var countDays = lstWorkDays.Count;
			var drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + countDays.ToString(),
				CSS = "right",
				Tooltip = "Count: " + countDays.ToString(),
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			var hoursWorked = lstWorkDays.Sum(x => x.HoursWorked);

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Total Hours Worked: " + hoursWorked.ToString("N2"),
				CSS = "right",
				Tooltip = "Total Hours Worked: " + hoursWorked.ToString("N2"),
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			var averageHours = (hoursWorked / (decimal)countDays).ToString("N2");

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Average Hours Worked: " + averageHours,
				CSS = "right",
				Tooltip = "Average Hours Worked: " + averageHours,
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			dtTable.Foot = drFeet;

			return dtTable;
		}
	}
}