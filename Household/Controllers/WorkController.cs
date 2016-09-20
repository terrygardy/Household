﻿using System;
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
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult WorkHoursList()
		{
			return PartialView("_MasterData", new CMasterData() { DisplayTable = new CWorkHoursModel().getDisplayTable(), Title = WorkText.WorkHours });
		}

		[HttpPost]
		public PartialViewResult WorkDay(long id)
		{
			return PartialView(new CWorkDayModel(id));
		}

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]CSearchWorkDay Search)
		{
			return PartialView("_MasterData", new CMasterData() { DisplayTable = new CWorkHoursModel().search(Search), Title = WorkText.WorkHours });
		}
	}
}