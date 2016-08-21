using System;

namespace Household.Models.Search
{
	public class CSearchWorkDay
	{
		public DateTime WorkDayFrom { get; set; }
		public DateTime WorkDayTo { get; set; }
		public TimeSpan Begin { get; set; }
		public TimeSpan End { get; set; }
		public decimal BreakDuration { get; set; }
	}
}