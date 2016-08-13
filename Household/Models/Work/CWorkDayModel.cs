using Household.BL.DATA.t;
using Household.BL.Functions.t;

namespace Household.Models.Work
{
	public class CWorkDayModel
	{
		public CWorkDayData WorkDay { get; set; }

		public CWorkDayModel(long pv_lngID)
		{
			WorkDay = new CWorkDay().getDataByID(pv_lngID);

			if (WorkDay == null) WorkDay = new CWorkDayData();
		}
	}
}