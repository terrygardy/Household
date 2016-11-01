using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.Data.Models.Base;

namespace Household.Models.Work
{
	public class CWorkDayModel : IDataBase
	{
		public CWorkDayData WorkDay { get; set; }

		public long ID
		{
			get { return WorkDay.ID; }
			set { WorkDay.ID = value; }
		}

		public string EntityName => WorkDay.EntityName;

		public string EntityTitle => WorkDay.EntityTitle;

		public CWorkDayModel(long pv_lngID)
		{
			WorkDay = new CWorkDayManagement().getDataByID(pv_lngID);

			if (WorkDay == null) WorkDay = new CWorkDayData();
		}
	}
}