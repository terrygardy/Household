using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Management.txx.Interfaces;
using Household.BL.DATA.txx.Implementations;

namespace Household.Controllers
{
	public class BankAccountController : CRUDController<txx_BankAccount, IBankAccountManagement, CBankAccountData>
	{
		public BankAccountController(IBankAccountManagement management) : base(management) { }
	}
}