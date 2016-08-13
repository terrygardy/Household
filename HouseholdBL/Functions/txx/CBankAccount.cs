using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx;

namespace Household.BL.Functions.txx
{
	public class CBankAccount : CModelBase<txx_BankAccount, string, string, CBankAccountData>
	{
		public CBankAccount() { }

		public override void validate(txx_BankAccount pv_cEntity)
		{
			if (string.IsNullOrWhiteSpace(pv_cEntity.AccountName)) { throw new ValidationException(BankAccount.EnterName); }

			if (!string.IsNullOrWhiteSpace(pv_cEntity.IBAN))
			{
				if (pv_cEntity.IBAN.Replace("-", "").Replace(" ", "").Length != 22) throw new ValidationException(BankAccount.IBANWrongLength);

				pv_cEntity.IBAN = formatIBAN(pv_cEntity.IBAN);

				if (getModel(x => string.Compare(x.IBAN, pv_cEntity.IBAN, true) == 0 && x.ID != pv_cEntity.ID) != null) { throw new ValidationException(BankAccount.IBANExists); }
			}

			if ((!string.IsNullOrWhiteSpace(pv_cEntity.BIC)) && (pv_cEntity.BIC.Length != 11)) { throw new ValidationException(BankAccount.BICWrongLength); }
		}

		public string formatIBAN(string pv_strIBAN) { return pv_strIBAN.ToUpper(); }

		protected override Expression<Func<txx_BankAccount, string>> getStandardOrderBy()
		{
			return x => x.AccountName;
		}

		protected override Expression<Func<txx_BankAccount, string>> getStandardThenBy()
		{
			return x => x.BankName;
		}

		protected override Expression<Func<txx_BankAccount, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		protected override void deleteAllowed(txx_BankAccount pv_cEntity)
		{
			if (Database.t_Income.Where(x => x.Payee_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(BankAccount.InUseIncome);
			if (Database.t_Purchase.Where(x => x.Payer_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(BankAccount.InUsePurchase);
			if (Database.t_Expense.Where(x => x.BankAccount_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(BankAccount.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		public List<txx_BankAccount> getBankAccounts()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
