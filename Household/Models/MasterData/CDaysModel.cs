﻿using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using System.Linq;
using Household.BL.Management.txx.Interfaces;

namespace Household.Models.MasterData
{
	public class CDaysModel
	{
		private readonly IDayManagement _dayManagement;

		public CDaysModel(IDayManagement dayManagement)
		{
			_dayManagement = dayManagement;
		}

		public CDisplayTable getDisplayTable()
		{
			var lstDays = _dayManagement.getDays();
			var action = "Day";
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

			drHead.Columns.Add(new CDisplayColumn()
			{
				Content = DayText.Day,
				Tooltip = DayText.Day
			});

			dtTable.Head.Add(drHead);

			foreach (var txxDay in lstDays)
			{
				var strDay = txxDay.Day.ToString();
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxDay.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
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
				Content = $"{GeneralText.Count}: {lstDays.Count().ToString()}",
				CSS = "right",
				ColumnSpan = 1
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}