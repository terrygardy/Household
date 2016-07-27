using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.Functions.txx;
using Household.BL.DATA.txx;

namespace Household.Controllers
{
	public class IntervalController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CIntervalData Interval)
		{
			string strMessage = "";

			try
			{
				new CInterval(CDbContext.getInstance()).save(Interval);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Interval.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CInterval(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}