using Household.BL.Functions.Management.txx;
using Household.Models.Finance;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class FinanceController : Controller
	{
		private readonly IShopManagement _shopManagement;

		public FinanceController(IShopManagement shopManagement)
		{
			_shopManagement = shopManagement;
		}

		// GET: Finance
		public ActionResult Finance()
		{
			return View();
		}

		public PartialViewResult MasterData()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Purchases()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Expenses()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Reports()
		{
			return PartialView(new CReportsModel(_shopManagement, true));
		}
	}
}