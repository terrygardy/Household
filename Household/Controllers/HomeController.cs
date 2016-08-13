using Household.Models.Environment;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public void SetEnvironment()
		{
			new CEnvironment();
		}
	}
}