using System.Web.Mvc;

namespace Household.Controllers
{
	public class BankingController : Controller
	{
		public PartialViewResult GetCurrentBankBalance()
		{
			//todo.tg: create label with current balance on finance pages
			return PartialView("_CurrentBankBalancePartial");
		}
	}
}