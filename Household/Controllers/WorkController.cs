using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Work;
using System.Web.Mvc;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.Models.Search;
using Household.BL.Functions.Management.t;
using Household.Localisation.Main.Work;

namespace Household.Controllers
{
	public class WorkController : CRUDController<t_WorkDay, IWorkDayManagement, DateTime, TimeSpan, CWorkDayData>
	{
		private const string c_MasterData = "_MasterData";

		public WorkController(IWorkDayManagement management)
			: base(management)
		{ }

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
			return PartialView(new CWorkHoursModel());
		}

		[HttpPost]
		public PartialViewResult WorkHoursList()
		{
			var model = new CWorkHoursModel();

			return PartialView(c_MasterData, new CMasterData() { DisplayTable = model.search(model.Search), Title = WorkText.WorkHours });
		}

		[HttpPost]
		public PartialViewResult WorkDay(long id)
		{
			var model = new CWorkDayModel(id);

			if (model.WorkDay.ID == 0)
			{

				if (model.WorkDay.WorkDay <= new DateTime(1753, 1, 1)) model.WorkDay.WorkDay = DateTime.Today;
				if (model.WorkDay.Begin.Hours == 0 && model.WorkDay.Begin.Minutes == 0) model.WorkDay.Begin = new TimeSpan(8, 0, 0);
				if (model.WorkDay.End.Hours == 0 && model.WorkDay.End.Minutes == 0) model.WorkDay.End = new TimeSpan(17, 30, 0);
				if (model.WorkDay.BreakDuration == 0) model.WorkDay.BreakDuration = 1;
			}

			return PartialView(model);
		}

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]CSearchWorkDay Search)
		{
			return PartialView(c_MasterData, new CMasterData() { DisplayTable = new CWorkHoursModel().search(Search), Title = WorkText.WorkHours });
		}
	}
}