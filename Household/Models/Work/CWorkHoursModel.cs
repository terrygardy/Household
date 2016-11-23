using Household.Localisation.Main.Work;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using GARTE.TypeHandling;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using Household.Data.Context;
using Household.Models.Search;
using Household.Models.Interfaces;
using Household.BL.Management.t.Interfaces;

namespace Household.Models.Work
{
	public class CWorkHoursModel : ISearchModel<t_WorkDay, CSearchWorkDay>
	{
		private DateTime m_datNull = new DateTime(1753, 1, 1);
		private TimeSpan m_tsNull = new TimeSpan(0, 0, 0);
		private readonly IWorkDayManagement _workDayManagement;

		public CSearchWorkDay SearchModel { get; set; } = new CSearchWorkDay();

		public CWorkHoursModel(IWorkDayManagement workDayManagement)
		{
			_workDayManagement = workDayManagement;

			SearchModel.WorkDayFrom = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
		}

		public CDisplayTable GetDisplayTable(string actionMain, string controller) => GetDisplayTable(null, actionMain, controller);
		
		public List<CDisplayRow> CreateTableHead(string actionMain, string controller)
		{
			var drHead = new CDisplayRow()
			{
				OnClickAction = actionMain,
				OnClickController = controller
			};

			var dcColumn = new CDisplayColumn();
			dcColumn.Content = WorkText.WorkDay;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = WorkText.Begin;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = WorkText.End;
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = $"{WorkText.Break} [h]";
			dcColumn.CSS = "hideable";
			drHead.Columns.Add(dcColumn);

			dcColumn = new CDisplayColumn();
			dcColumn.Content = $"{WorkText.Worked} [h]";
			drHead.Columns.Add(dcColumn);

			return new List<CDisplayRow> { drHead };
		}

		public List<CDisplayRow> CreateTableFooter(string actionMain, string controller, int workDaysCount, decimal workedHoursSum)
		{
			var drFeet = new List<CDisplayRow>();
			var drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				CSS = "right hideable",
				ColumnSpan = 1
			});

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{GeneralText.Count}: {workDaysCount}",
				CSS = "right",
				ColumnSpan = 4
			});

			drFeet.Add(drFoot);

			drFoot = new CDisplayRow();

			drFoot.Columns.Add(new CDisplayColumn()
			{
				CSS = "right hideable",
				ColumnSpan = 1
			});

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{WorkText.TotalHoursWorked}: {workedHoursSum.ToString("N2")}",
				CSS = "right",
				ColumnSpan = 4
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
				ColumnSpan = 5
			});

			drFoot = new CDisplayRow();

			var overtimeWorked = workedHoursSum - (workDaysCount * 8);

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = $"{WorkText.Overtime}: {overtimeWorked.ToString("N2")}",
				CSS = "right",
				ColumnSpan = 5
			});

			drFeet.Add(drFoot);

			return drFeet;
		}

		public List<CDisplayRow> CreateTableBody(string actionMain, string controller, IEnumerable<t_WorkDay> lstWorkDays) {
			var lstRows = new List<CDisplayRow>();

			foreach (var tWorkDay in lstWorkDays)
			{
				lstRows.Add(CreateBodyRow(actionMain, controller, tWorkDay));
			}

			return lstRows;
		}

		public CDisplayRow CreateBodyRow(string actionMain, string controller, t_WorkDay tWorkDay) {
			var strDay = Base.convertShortDateString(tWorkDay.WorkDay, "...");
			var strBegin = Base.convertShortTimeString(tWorkDay.Begin, "...");
			var strEnd = Base.convertShortTimeString(tWorkDay.End, "...");
			var strTooltip = $"{strDay}: {GeneralText.FromLower} {strBegin}";
			var drBody = new CDisplayRow()
			{
				OnClickParam = tWorkDay.ID.ToString(),
				OnClickAction = actionMain,
				OnClickController = controller
			};

			strTooltip = Strings.concatStrings(strTooltip, strEnd, $" {GeneralText.UntilLower} ");

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tWorkDay.WorkDay,
				CSS = "center",
				Tooltip = strTooltip
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tWorkDay.Begin,
				CSS = "center",
				Tooltip = strTooltip
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tWorkDay.End,
				CSS = "center",
				Tooltip = strTooltip
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tWorkDay.BreakDuration,
				CSS = "right hideable",
				Tooltip = strTooltip
			});

			drBody.Columns.Add(new CDisplayColumn()
			{
				Content = tWorkDay.HoursWorked,
				CSS = "right",
				Tooltip = strTooltip
			});

			return drBody;
		}

		public CDisplayTable GetDisplayTable(Expression<Func<t_WorkDay, bool>> exSearch, string actionMain, string controller)
		{
			var lstWorkDays = _workDayManagement.getWorkingDays(exSearch);
			var dtTable = new CDisplayTable()
			{
				AddAction = actionMain,
				AddController = controller
			};

			dtTable.Head = CreateTableHead(actionMain, controller);
			dtTable.Body = CreateTableBody(actionMain, controller, lstWorkDays);
			dtTable.Foot = CreateTableFooter(actionMain, controller, lstWorkDays.Count(), Convert.ToDecimal(lstWorkDays.Sum(w => w.HoursWorked)));

			return dtTable;
		}

		public CDisplayTable Search(CSearchWorkDay pv_swSearch, string actionMain, string controller)
		{
			return GetDisplayTable(GetSearchExpression(pv_swSearch), actionMain, controller);
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