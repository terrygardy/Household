using System;
using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.Models;
using Household.Models.Db;
using Household.Models.Work;
using System.Web.Mvc;
using WebHelpers;
using Household.Models.MasterData;

namespace Household.Controllers
{
    public class WorkController : Controller
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		public ActionResult Work()
        {
            return View();
        }

		[HttpPost]
		public PartialViewResult WorkHours() {
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult WorkHoursList()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CWorkHoursModel(CDbContext.getInstance()).getDisplayTable(), Title = "Work Hours" });
		}

		[HttpPost]
		public PartialViewResult WorkDay(long id)
		{
			return PartialView(new CWorkDayModel(CDbContext.getInstance(), id));
		}

		[HttpPost]
		public string Save([System.Web.Http.FromBody]CWorkDayData WorkDay)
		{
			string strMessage = "";

			try
			{
				new CWorkDay(CDbContext.getInstance()).save(WorkDay);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = WorkDay.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CWorkDay(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}