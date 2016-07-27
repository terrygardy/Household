using System.Collections.Generic;

namespace Household.Models.DisplayTable
{
	public class CDisplayRow
	{
		public List<CDisplayColumn> Columns { get; set; }
		public string OnClickParam { get; set; }

		public CDisplayRow()
		{
			Columns = new List<CDisplayColumn>();
			OnClickParam = "";
		}
	}
}