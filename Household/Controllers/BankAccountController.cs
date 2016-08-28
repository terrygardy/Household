using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Controllers.Base;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class BankAccountController : CRUDController<txx_BankAccount, IBankAccountManagement, string, string, CBankAccountData>
	{
		public BankAccountController(IBankAccountManagement management) : base(management) { }

		protected override long GetDataID(CBankAccountData data)
		{
			return data.ID;
		}
	}
}