using System;
using Household.BL.DATA.t;
using Household.Models.Work;
using System.Web.Mvc;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.Models.Search;
using Household.BL.Functions.Management.t;
using Household.Localisation.Main.Work;
using System.Linq;

namespace Household.Controllers
{
	public class WorkController : SearchableController
		<t_WorkDay, IWorkDayManagement, CWorkDayData, CWorkHoursModel, CSearchWorkDay>
	{
		public WorkController(IWorkDayManagement management)
			: base(management, nameof(WorkDay))
		{ }

		protected override string GetSearchTitle()
		{
			return WorkText.WorkHours;
		}

		public ActionResult Work()
		{
			return View();
		}

		[HttpPost]
		public PartialViewResult WorkHours()
		{
			return PartialView(getSearchClass());
		}

		[HttpPost]
		public PartialViewResult WorkHoursList()
		{
			return Search(getSearchClass().SearchModel);
		}

		[HttpPost]
		public PartialViewResult WorkDay(long id)
		{
			var model = new CWorkDayModel(Management, id);

			if (model.WorkDay.ID == 0)
			{

				if (model.WorkDay.WorkDay <= new DateTime(1753, 1, 1)) model.WorkDay.WorkDay = DateTime.Today;
				if (model.WorkDay.Begin.Hours == 0 && model.WorkDay.Begin.Minutes == 0) model.WorkDay.Begin = new TimeSpan(8, 0, 0);
				if (model.WorkDay.End.Hours == 0 && model.WorkDay.End.Minutes == 0) model.WorkDay.End = new TimeSpan(17, 30, 0);
				if (model.WorkDay.BreakDuration == 0) model.WorkDay.BreakDuration = 1;
			}

			return PartialView("DatabaseEntry", model);
		}

		[HttpPost]
		public override PartialViewResult GetTableFooter(CSearchWorkDay search)
		{
			var searchModel = getSearchClass();
			var days = Management.getWorkingDays(searchModel.GetSearchExpression(search));

			var footerModel = searchModel.CreateTableFooter(ActionName, ControllerName, days.Count(), days.Sum(x => x.HoursWorked));

			return PartialView("_MasterDataHeaderFooterPartial", footerModel);
		}

		protected override CWorkHoursModel getSearchClass()
		{
			return new CWorkHoursModel(Management);
		}
	}
}