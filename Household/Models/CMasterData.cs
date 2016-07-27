using Household.Models.DisplayTable;
using System.Collections.Generic;

namespace Household.Models
{
	public class CMasterData
	{
		public string Title { get; set; }
		public CDisplayTable DisplayTable { get; set; }
		public List<CBreadCrumb> BreadCrumbs { get; set; }

		public CMasterData() {
			Title = "";
			DisplayTable = new CDisplayTable();
			BreadCrumbs = new List<CBreadCrumb>();
		}
	}
}