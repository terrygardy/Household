using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.Functions.txx;
using Household.BL.DATA.txx;

namespace Household.Controllers
{
	public class ShopController : Controller
	{
		[HttpPost]
		public string Save([System.Web.Http.FromBody]CShopData Shop)
		{
			string strMessage = "";

			try
			{
				new CShop(CDbContext.getInstance()).save(Shop);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Shop.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CShop(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}