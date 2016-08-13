using Household.BL.Functions.t;
using System.Web.Mvc;
using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Finance;
using Household.Models.Search;
using Household.Data.Context;
using Household.Controllers.Base;

namespace Household.Controllers
{
	public class PurchasesController : CRUDController<t_Purchase, CPurchase, DateTime, string, CPurchaseData>
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		protected override long GetDataID(CPurchaseData data)
		{
			return data.ID;
		}

		[HttpPost]
		public PartialViewResult Purchases()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CPurchasesModel().getDisplayTable(), Title = "Purchases" });
		}

		[HttpPost]
		public PartialViewResult Purchase(long id)
		{
			return PartialView("Purchase", new CPurchaseModel(id));
		}

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]CSearchPurchase Search)
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CPurchasesModel().search(Search), Title = "Purchases" });
		}
	}
}