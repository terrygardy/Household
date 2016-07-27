using System;

namespace Household.Models.Search
{
	public class CSearchPurchase
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }
		public string Where { get; set; }
		public string Who { get; set; }
		public decimal Amount { get; set; }
		public string Description { get; set; }
	}
}