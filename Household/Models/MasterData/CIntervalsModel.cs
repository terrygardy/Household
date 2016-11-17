using Household.Localisation.Main.MasterData;
using Household.Localisation.Common;
using Household.Models.DisplayTable;
using Household.BL.Functions.Management.txx;
using System.Linq;

namespace Household.Models.MasterData
{
	public class CIntervalsModel
	{
		private readonly IIntervalManagement _intervalManagement;

		public CIntervalsModel(IIntervalManagement intervalManagement)
		{
			_intervalManagement = intervalManagement;
		}

		public CDisplayTable getDisplayTable()
		{
			var lstIntervals = _intervalManagement.getIntervals();
			var action = "Interval";
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
				Content = $"{GeneralText.Count}: {lstIntervals.Count().ToString()}",
				CSS = "right",
				ColumnSpan = 1
			});

			dtTable.Foot.Add(drFoot);

			return dtTable;
		}
	}
}