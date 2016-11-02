using System;

namespace Household.Models.Search
{
	public class CSearchExpense
	{
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Company { get; set; }
		public string Who { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}