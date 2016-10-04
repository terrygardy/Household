using System.Collections.Generic;

namespace Household.Models.DisplayTable
{
	public class CDisplayRow
	{
		public List<CDisplayColumn> Columns { get; set; } = new List<CDisplayColumn>();
		public string OnClickParam { get; set; } = "";
		public string OnClickAction { get; set; } = "";
		public string OnClickController { get; set; } = "";
	}
}