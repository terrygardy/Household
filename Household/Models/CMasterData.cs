using Household.Models.DisplayTable;
using System.Collections.Generic;

namespace Household.Models
{
	public class CMasterData
	{
		public string Title { get; set; } = "";
		public CDisplayTable DisplayTable { get; set; } = new CDisplayTable();
		public List<CBreadCrumb> BreadCrumbs { get; set; } = new List<CBreadCrumb>();
	}
}