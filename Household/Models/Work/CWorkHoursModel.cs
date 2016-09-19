using Household.Localisation.Main.Work;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using Household.BL.Functions.t;
using GARTE.TypeHandling;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Household.Data.Context;
using Household.Models.Search;

namespace Household.Models.Work
{
	public class CWorkHoursModel
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);
		private TimeSpan m_tsNull = new TimeSpan(0, 0, 0);

		public CWorkHoursModel() { }

		public CDisplayTable getDisplayTable()
		{
			return getDisplayTable(null);
		}

		public CDisplayTable getDisplayTable(Expression<Func<t_WorkDay, bool>> exSearch)
		{
			var cWorkDay = new CWorkDayManagement();
			var lstWorkDays = cWorkDay.getWorkingDays(exSearch);
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "WorkDay",
				OnClickController = "Work"
			};
			var drHead = new CDisplayRow();
			var drFeet = new List<CDisplayRow>();
			var dcColumn = new CDisplayColumn();

			dcColumn.Content = WorkText.WorkDay;
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = WorkText.Begin;
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = WorkText.End;
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = $"{WorkText.Break} [h]";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = $"{WorkText.Worked} [h]";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			dtTable.Head.Add(drHead);

			foreach (var tWorkDay in lstWorkDays)
			{
				var strDay = Base.convertShortDateString(tWorkDay.WorkDay, "...");
				var strBegin = Base.convertShortTimeString(tWorkDay.Begin, "...");
				var strEnd = Base.convertShortTimeString(tWorkDay.End, "...");
				var strTooltip = $"{strDay}: {GeneralText.FromLower} {strBegin}";
				var drBody = new CDisplayRow()
				{
					OnClickParam = tWorkDay.ID.ToString()
				};

				strTooltip = Strings.concatStrings(strTooltip, strEnd, $" {GeneralText.UntilLower} ");

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
				Content = $"{GeneralText.Count}: {countDays.ToString()}",
				CSS = "right",
				Tooltip = $"{GeneralText.Count}: {countDays.ToString()}",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			var hoursWorked = lstWorkDays.Sum(x => x.HoursWorked);

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{WorkText.TotalHoursWorked}: {hoursWorked.ToString("N2")}",
				CSS = "right",
				Tooltip = $"{WorkText.TotalHoursWorked}: {hoursWorked.ToString("N2")}",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();


			string averageHours;

			try
			{
				averageHours = (hoursWorked / (decimal)countDays).ToString("N2");
			}
			catch (Exception)
			{
				averageHours = "0";
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{WorkText.AverageHoursWorked}: {averageHours}",
				CSS = "right",
				Tooltip = $"{WorkText.AverageHoursWorked}: {averageHours}",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			dtTable.Foot = drFeet;

			return dtTable;
		}

		public CDisplayTable search(CSearchWorkDay pv_swSearch)
		{
			pv_swSearch.WorkDayFrom = Base.convertDate(pv_swSearch.WorkDayFrom);
			pv_swSearch.WorkDayTo = Base.convertDate(pv_swSearch.WorkDayTo);
			pv_swSearch.Begin = Base.convertTime(pv_swSearch.Begin);
			pv_swSearch.End = Base.convertTime(pv_swSearch.End);
			pv_swSearch.BreakDuration = Base.convertDec(pv_swSearch.BreakDuration);

			return getDisplayTable(x => (((pv_swSearch.WorkDayFrom <= m_datNull) || (x.WorkDay >= pv_swSearch.WorkDayFrom))
									&& ((pv_swSearch.WorkDayTo <= m_datNull) || (x.WorkDay <= pv_swSearch.WorkDayTo))
									&& ((pv_swSearch.Begin <= m_tsNull) || (x.Begin >= pv_swSearch.Begin))
									&& ((pv_swSearch.End <= m_tsNull) || (x.End <= pv_swSearch.End))
									&& ((pv_swSearch.BreakDuration <= 0) || (x.BreakDuration == pv_swSearch.BreakDuration))));
		}
	}
}