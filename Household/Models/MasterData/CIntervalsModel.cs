﻿using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CIntervalsModel
	{
		private Database DbHousehold { get; set; }

		public CIntervalsModel(Database pv_dbHousehold) { DbHousehold = pv_dbHousehold; }

		public CDisplayTable getDisplayTable()
		{
			var cInterval = new CInterval(DbHousehold);
			var lstIntervals = cInterval.getIntervals();
			var dtTable = new CDisplayTable()
			{
				OnClickAction = "Interval",
				OnClickController = "MasterData"
			};
			var drHead = new CDisplayRow();
			var drFoot = new CDisplayRow();

			drHead.Columns.Add(new CDisplayColumn()
			{
				Content = "Interval",
				CSS = "left",
				Tooltip = "Interval"
			});

			dtTable.Head.Add(drHead);

			foreach (var txxInterval in lstIntervals)
			{
				var strInterval = txxInterval.Name;
				var drBody = new CDisplayRow()
				{
					OnClickParam = txxInterval.ID.ToString()
				};

				drBody.Columns.Add(new CDisplayColumn()
				{
					Content = strInterval,
					CSS = "left",
					Tooltip = strInterval
				});

				dtTable.Body.Add(drBody);
			}

			drFoot.Columns.Add(new CDisplayColumn()
			{
				Content = "Count: " + lstIntervals.Count.ToString(),
				CSS = "right",
				Tooltip = "Count: " + lstIntervals.Count.ToString(),
				ColumnSpan = 1
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}