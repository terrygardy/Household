using Household.BL.Management.t.Interfaces;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class BankingController : Controller
	{
		private readonly IBankingManagement _bankingManagement;

		public BankingController(IBankingManagement bankingManagement)
		{
			_bankingManagement = bankingManagement;
		}

		public PartialViewResult GetCurrentBankBalance()
		{
			return PartialView("_CurrentBankBalancePartial", _bankingManagement.getCurrentBankBalance());
		}
	}
}