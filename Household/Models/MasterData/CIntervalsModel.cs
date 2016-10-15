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
			var action = "Interval";
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
					OnClickParam = txxInterval.ID.ToString(),
					OnClickAction = action,
					OnClickController = controller
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
				ColumnSpan = 1
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}