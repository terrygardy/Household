using Household.BL.Functions.t;
using WebHelpers;
using System;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using Household.BL.Interfaces.t;
using Household.BL.DATA.t;

namespace Household.Controllers
{
	public class PersonController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CPersonData Person)
		{
			string strMessage = "";

			try
			{
				new CPerson(CDbContext.getInstance()).save(Person);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Person.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CPerson(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}