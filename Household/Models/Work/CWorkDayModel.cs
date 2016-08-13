using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.Data.Context;

namespace Household.Models.Work
{
	public class CWorkDayModel
	{
		public CWorkDayData WorkDay { get; set; }

		public CWorkDayModel(Database pv_dbHousehold, long pv_lngID)
		{
			WorkDay = new CWorkDay(pv_dbHousehold).getDataByID(pv_lngID);

			if (WorkDay == null) WorkDay = new CWorkDayData();
		}
	}
}