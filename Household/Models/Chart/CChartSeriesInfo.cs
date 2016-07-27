using System.Collections.Generic;

namespace Household.Models.Chart
{
	public class CChartSeriesInfo : CChartSeriesBasicInfo<List<object>>
	{
		public CChartSeriesInfo() { data = new List<object>(); }
	}
}