using Household.BL.Functions.t;
using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Finance;
using Household.Models.Search;

namespace Household.Controllers
{
	public class PurchasesController : Controller
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		[HttpPost]
		public PartialViewResult Purchases()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CPurchasesModel(CDbContext.getInstance()).getDisplayTable(), Title = "Purchases" });
		}

		[HttpPost]
		public PartialViewResult Purchase(long id)
		{
			return PartialView("Purchase", new CPurchaseModel(CDbContext.getInstance(), id));
		}

		[HttpPost]
		public string Save([System.Web.Http.FromBody]CPurchaseData Purchase)
		{
			string strMessage = "";

			try
			{
				new CPurchase(CDbContext.getInstance()).save(Purchase);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Purchase.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CPurchase(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]CSearchPurchase Search)
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CPurchasesModel(CDbContext.getInstance()).search(Search), Title = "Purchases" });
		}
	}
}