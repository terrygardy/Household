using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Data.Db;

namespace Household.BL.Management.txx.Implementations
{
	public class CBankAccountManagement : CManagementBase<txx_BankAccount, string, string, CBankAccountData>, IBankAccountManagement
	{
		public CBankAccountManagement(IDb db)
			: base(db) { }

		public string formatIBAN(string pv_strIBAN) { return pv_strIBAN.ToUpper(); }

		protected override Expression<Func<txx_BankAccount, string>> getStandardOrderBy()
		{
			return x => x.AccountName;
		}

		protected override Expression<Func<txx_BankAccount, string>> getStandardThenBy()
		{
			return x => x.BankName;
		}

		protected override void deleteAllowed(txx_BankAccount pv_cEntity)
		{
			if (Db.GetGenericRepository<t_Income>().Where(x => x.Payee_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(BankAccount.InUseIncome);
			if (Db.GetGenericRepository<t_Purchase>().Where(x => x.Payer_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(BankAccount.InUsePurchase);
			if (Db.GetGenericRepository<t_Expense>().Where(x => x.BankAccount_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(BankAccount.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		public IEnumerable<txx_BankAccount> getBankAccounts()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}