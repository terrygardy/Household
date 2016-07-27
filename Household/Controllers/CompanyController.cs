using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.Functions.txx;
using Household.BL.DATA.txx;

namespace Household.Controllers
{
	public class CompanyController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CCompanyData Company)
		{
			string strMessage = "";

			try
			{
				new CCompany(CDbContext.getInstance()).save(Company);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Company.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CCompany(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}