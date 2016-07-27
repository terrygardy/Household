using System.Collections.Generic;

namespace Household.Models.DisplayTable
{
	public class CDisplayTable
	{
		public List<CDisplayRow> Head { get; set; }
		public List<CDisplayRow> Body { get; set; }
		public List<CDisplayRow> Foot { get; set; }
		public string CSS { get; set; }
		public string OnClickAction { get; set; }
		public string OnClickController { get; set; }

		public CDisplayTable()
		{
			Head = new List<CDisplayRow>();
			Body = new List<CDisplayRow>();
			Foot = new List<CDisplayRow>();
			CSS = "";
			OnClickAction = "";
			OnClickController = "";
		}
	}
}