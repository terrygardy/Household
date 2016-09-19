using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.BL.Functions.txx;
using Household.Models.DisplayTable;

namespace Household.Models.MasterData
{
	public class CIntervalsModel
	{
		public CIntervalsModel() { }

		public CDisplayTable getDisplayTable()
		{
			var cInterval = new CIntervalManagement();
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
				Content = IntervalText.Interval,
				Tooltip = IntervalText.Interval
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
				Content = $"{GeneralText.Count}: {lstIntervals.Count.ToString()}",
				CSS = "right",
				Tooltip = $"{GeneralText.Count}: {lstIntervals.Count.ToString()}",
				ColumnSpan = 1
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}