using Household.BL.DATA.txx.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Management.txx.Interfaces
{
	public interface IBankAccountManagement : IManagementBase<txx_BankAccount, CBankAccountData>
	{
		IEnumerable<txx_BankAccount> getBankAccounts();
	}
}