using System.Web.Mvc;
using System;
using Household.BL.DATA.t;
using Household.Models.Finance;
using Household.Models.Search;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Functions.Management.t;
using System.Linq;
using Household.Localisation.Main.Finance;

namespace Household.Controllers
{
	public class PurchasesController : SearchableController
		<t_Purchase, IPurchaseManagement, DateTime, string, CPurchaseData, CPurchasesModel, CSearchPurchase>
	{
		public PurchasesController(IPurchaseManagement management)
			: base(management, "Purchase", "Purchases")
		{ }

		protected override string GetSearchTitle()
		{
			return PurchaseText.Purchases;
		}

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

			return PartialView(model);
		}

		[HttpPost]
		public override PartialViewResult GetTableFooter(CSearchPurchase search)
		{
			var searchModel = new CPurchasesModel();
			var purchases = Management.getPurchases(searchModel.GetSearchExpression(search));

			var footerModel = searchModel.CreateTableFooter(ActionName, ControllerName, purchases.Count, purchases.Sum(x => x.Amount));

			return PartialView("_MasterDataHeaderFooterPartial", footerModel);
		}
	}
}