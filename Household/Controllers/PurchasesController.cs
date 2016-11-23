using System.Web.Mvc;
using System;
using Household.Models.Finance;
using Household.Models.Search;
using Household.Data.Context;
using Household.Controllers.Base;
using System.Linq;
using Household.Localisation.Main.Finance;
using Household.BL.DATA.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Interfaces;

namespace Household.Controllers
{
	public class PurchasesController : SearchableController
		<t_Purchase, IPurchaseManagement, CPurchaseData, CPurchasesModel, CSearchPurchase>
	{
		private readonly IBankAccountManagement _bankAccountManagement;
		private readonly IShopManagement _shopManagement;

		public PurchasesController(IPurchaseManagement management,
			IBankAccountManagement bankAccountManagement,
			IShopManagement shopManagement)
			: base(management, nameof(Purchase))
		{
			_bankAccountManagement = bankAccountManagement;
			_shopManagement = shopManagement;
		}

		protected override string GetSearchTitle()
		{
			return PurchaseText.Purchases;
		}

		[HttpPost]
		public PartialViewResult Purchases()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Purchase(long id)
		{
			var model = new CPurchaseModel(Management, _bankAccountManagement, _shopManagement, id);

			if (model.Purchase.ID == 0)
			{
				if (model.Purchase.Occurrence <= new DateTime(1753, 1, 1)) model.Purchase.Occurrence = DateTime.Today;
			}

			return PartialView("DatabaseEntry", model);
		}

		[HttpPost]
		public override PartialViewResult GetTableFooter(CSearchPurchase search)
		{
			var searchModel = getSearchClass();
			var purchases = Management.getPurchases(searchModel.GetSearchExpression(search));

			var footerModel = searchModel.CreateTableFooter(ActionName, ControllerName, purchases.Count(), purchases.Sum(x => x.Amount));

			return PartialView("_MasterDataHeaderFooterPartial", footerModel);
		}

		protected override CPurchasesModel getSearchClass()
		{
			return new CPurchasesModel(Management);
		}
	}
}