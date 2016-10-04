using System.Collections.Generic;

namespace Household.Models.DisplayTable
{
	public class CDisplayTable
	{
		public List<CDisplayRow> Head { get; set; } = new List<CDisplayRow>();
		public List<CDisplayRow> Body { get; set; } = new List<CDisplayRow>();
		public List<CDisplayRow> Foot { get; set; } = new List<CDisplayRow>();
		public string CSS { get; set; } = "";
		public string AddController { get; set; } = "";
		public string AddAction { get; set; } = "";
	}
}