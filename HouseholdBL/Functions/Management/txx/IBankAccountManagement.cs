using Household.BL.DATA.txx;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Functions.Management.txx
{
	public interface IBankAccountManagement : IManagementBase<txx_BankAccount, CBankAccountData>
	{
		IEnumerable<txx_BankAccount> getBankAccounts();
	}
}
