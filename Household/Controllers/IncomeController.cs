using Household.BL.Functions.t;
using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.DATA.t;

namespace Household.Controllers
{
	public class IncomeController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CIncomeData Income)
		{
			string strMessage = "";

			try
			{
				new CIncome(CDbContext.getInstance()).save(Income);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Income.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CIncome(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}