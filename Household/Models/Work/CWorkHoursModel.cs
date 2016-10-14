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
using Household.Models.Interfaces;

namespace Household.Models.Work
{
	public class CWorkHoursModel : ISearchModel<t_WorkDay, CSearchWorkDay>
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);
		private TimeSpan m_tsNull = new TimeSpan(0, 0, 0);

		public CSearchWorkDay SearchModel { get; set; } = new CSearchWorkDay();

		public CWorkHoursModel()
		{
			SearchModel.WorkDayFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
		}

		public CDisplayTable GetDisplayTable() => GetDisplayTable(null);
		
		public List<CDisplayRow> CreateTableHead(string action, string controller)
		{
			var drHead = new CDisplayRow()
			{
				OnClickAction = action,
				OnClickController = controller
			};

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
			dcColumn.CSS = "hideable";
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = $"{WorkText.Worked} [h]";
			dcColumn.Tooltip = dcColumn.Content;
			drHead.Columns.Add(dcColumn);

			return new List<CDisplayRow> { drHead };
		}

		public List<CDisplayRow> CreateTableFooter(string action, string controller, int workDaysCount, decimal workedHoursSum)
		{
			var drFeet = new List<CDisplayRow>();
			var drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {workDaysCount}",
				CSS = "right",
				Tooltip = $"{GeneralText.Count}: {workDaysCount}",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{WorkText.TotalHoursWorked}: {workedHoursSum.ToString("N2")}",
				CSS = "right",
				Tooltip = $"{WorkText.TotalHoursWorked}: {workedHoursSum.ToString("N2")}",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			string averageHours;

			try
			{
				averageHours = (workedHoursSum / workDaysCount).ToString("N2");
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

			drFoot = new CDisplayRow();

			var overtimeWorked = workedHoursSum - (workDaysCount * 8);

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{WorkText.Overtime}: {overtimeWorked.ToString("N2")}",
				CSS = "right",
				Tooltip = $"{WorkText.Overtime}: {overtimeWorked.ToString("N2")}",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			return drFeet;
		}

		public List<CDisplayRow> CreateTableBody(string action, string controller, List<t_WorkDay> lstWorkDays) {
			var lstRows = new List<CDisplayRow>();

			foreach (var tWorkDay in lstWorkDays)
			{
				lstRows.Add(CreateBodyRow(action, controller, tWorkDay));
			}

			return lstRows;
		}

		public CDisplayRow CreateBodyRow(string action, string controller, t_WorkDay tWorkDay) {
			var strDay = Base.convertShortDateString(tWorkDay.WorkDay, "...");
			var strBegin = Base.convertShortTimeString(tWorkDay.Begin, "...");
			var strEnd = Base.convertShortTimeString(tWorkDay.End, "...");
			var strTooltip = $"{strDay}: {GeneralText.FromLower} {strBegin}";
			var drBody = new CDisplayRow()
			{
				OnClickParam = tWorkDay.ID.ToString(),
				OnClickAction = action,
				OnClickController = controller
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
				CSS = "right hideable",
				Tooltip = strTooltip
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tWorkDay.HoursWorked.ToString("N2"),
				CSS = "right",
				Tooltip = strTooltip
			});

			return drBody;
		}

		public CDisplayTable GetDisplayTable(Expression<Func<t_WorkDay, bool>> exSearch)
		{
			var cWorkDay = new CWorkDayManagement();
			var lstWorkDays = cWorkDay.getWorkingDays(exSearch);
			var action = "WorkDay";
			var controller = "Work";
			var dtTable = new CDisplayTable()
			{
				AddAction = action,
				AddController = controller
			};

			dtTable.Head = CreateTableHead(action, controller);
			dtTable.Body = CreateTableBody(action, controller, lstWorkDays);
			dtTable.Foot = CreateTableFooter(action, controller, lstWorkDays.Count(), Convert.ToDecimal(lstWorkDays.Sum(w => w.HoursWorked)));

			return dtTable;
		}

		public CDisplayTable Search(CSearchWorkDay pv_swSearch)
		{
			return GetDisplayTable(GetSearchExpression(pv_swSearch));
		}

		public Expression<Func<t_WorkDay, bool>> GetSearchExpression(CSearchWorkDay pv_swSearch) {
			pv_swSearch.WorkDayFrom = Base.convertDate(pv_swSearch.WorkDayFrom);
			pv_swSearch.WorkDayTo = Base.convertDate(pv_swSearch.WorkDayTo);
			pv_swSearch.Begin = Base.convertTime(pv_swSearch.Begin);
			pv_swSearch.End = Base.convertTime(pv_swSearch.End);
			pv_swSearch.BreakDuration = Base.convertDec(pv_swSearch.BreakDuration);

			return x => (((pv_swSearch.WorkDayFrom <= m_datNull) || (x.WorkDay >= pv_swSearch.WorkDayFrom))
									&& ((pv_swSearch.WorkDayTo <= m_datNull) || (x.WorkDay <= pv_swSearch.WorkDayTo))
									&& ((pv_swSearch.Begin <= m_tsNull) || (x.Begin >= pv_swSearch.Begin))
									&& ((pv_swSearch.End <= m_tsNull) || (x.End <= pv_swSearch.End))
									&& ((pv_swSearch.BreakDuration <= 0) || (x.BreakDuration == pv_swSearch.BreakDuration)));
		}
	}
}