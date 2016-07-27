namespace Household.Models.Chart
{
	public class CChartSeriesBasicInfo<T>
	{
		public string name { get; set; }
		public T data { get; set; }

		public CChartSeriesBasicInfo()
		{
			name = "";
		}
	}
}