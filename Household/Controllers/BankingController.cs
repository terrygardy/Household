using Household.BL.Management.t.Interfaces;
using Household.Controllers.Base;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class BankingController : BaseController
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