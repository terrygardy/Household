using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.Functions.txx;
using Household.BL.DATA.txx;

namespace Household.Controllers
{
	public class BankAccountController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CBankAccountData BankAccount)
		{
			string strMessage = "";

			try
			{
				new CBankAccount(CDbContext.getInstance()).save(BankAccount);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = BankAccount.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CBankAccount(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}