using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.Functions.txx;
using Household.BL.DATA.txx;

namespace Household.Controllers
{
	public class DayController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CDayData Day)
		{
			string strMessage = "";

			try
			{
				new CDay(CDbContext.getInstance()).save(Day);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Day.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CDay(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}