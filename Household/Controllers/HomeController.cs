using Household.BL.Management.txx.Interfaces;
using Household.Models.Environment;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class HomeController : Controller
	{
		private readonly IShopManagement _shopManagement;

		public HomeController(IShopManagement shopManagement)
		{
			_shopManagement = shopManagement;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public void SetEnvironment()
		{
			new CEnvironment(_shopManagement);
		}
	}
}