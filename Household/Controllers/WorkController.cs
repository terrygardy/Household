using System;
using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.Models;
using Household.Models.Work;
using System.Web.Mvc;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.Models.Search;

namespace Household.Controllers
{
	public class WorkController : CRUDController<t_WorkDay, CWorkDay, DateTime, TimeSpan, CWorkDayData>
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		protected override long GetDataID(CWorkDayData data)
		{
			return data.ID;
		}

		public ActionResult Work()
		{
			return View();
		}

		[HttpPost]
		public PartialViewResult WorkHours()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult WorkHoursList()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CWorkHoursModel().getDisplayTable(), Title = "Work Hours" });
		}

		[HttpPost]
		public PartialViewResult WorkDay(long id)
		{
			return PartialView(new CWorkDayModel(id));
		}

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]CSearchWorkDay Search)
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CWorkHoursModel().search(Search), Title = "Work Hours" });
		}
	}
}