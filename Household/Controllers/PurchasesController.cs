using System.Web.Mvc;
using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Finance;
using Household.Models.Search;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Functions.Management.t;

namespace Household.Controllers
{
	public class PurchasesController : CRUDController<t_Purchase, IPurchaseManagement, DateTime, string, CPurchaseData>
	{
		public PurchasesController(IPurchaseManagement management)
			: base(management)
		{ }

		protected override long GetDataID(CPurchaseData data)
		{
			return data.ID;
		}

		[HttpPost]
		public PartialViewResult Purchases()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Purchase(long id)
		{
			var model = new CPurchaseModel(id);

			if (model.Purchase.ID == 0)
			{
				if (model.Purchase.Occurrence <= new DateTime(1753, 1, 1)) model.Purchase.Occurrence = DateTime.Today;
			}

			return PartialView("Purchase", model);
		}

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]CSearchPurchase Search)
		{
			return PartialView("_MasterData", new CMasterData() { DisplayTable = new CPurchasesModel().search(Search), Title = "Purchases" });
		}
	}
}