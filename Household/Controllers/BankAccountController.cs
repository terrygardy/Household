using Household.BL.Functions.txx;
using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Controllers.Base;

namespace Household.Controllers
{
	public class BankAccountController : CRUDController<txx_BankAccount, CBankAccount, string, string, CBankAccountData>
	{
		protected override long GetDataID(CBankAccountData data)
		{
			return data.ID;
		}
	}
}