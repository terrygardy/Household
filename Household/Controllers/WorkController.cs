using Household.Models;
using Household.Models.Db;
using Household.Models.Work;
using System.Web.Mvc;

namespace Household.Controllers
{
    public class WorkController : Controller
    {
		private string m_strMasterDataUrl = "../Shared/MasterData";

		// GET: Work
		public ActionResult Work()
        {
            return View();
        }

		[HttpPost]
		public PartialViewResult WorkHours() {
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult WorkHoursList()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CWorkHoursModel(CDbContext.getInstance()).getDisplayTable(), Title = "Work Hours" });
		}
	}
}