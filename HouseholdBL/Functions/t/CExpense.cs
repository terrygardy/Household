using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Linq.Expressions;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using Household.BL.DATA.t;
using System.Collections.Generic;

namespace Household.BL.Functions.t
{
	public class CExpense : CModelBase<t_Expense, DateTime, string, CExpenseData>
	{
		public CExpense() { }

		public override void validate(t_Expense pv_cEntity)
		{
			if (pv_cEntity.StartDate <= MinDate) throw new ValidationException(Expense.EnterStartDate);
			if ((pv_cEntity.EndDate > MinDate) && (pv_cEntity.EndDate < pv_cEntity.StartDate)) throw new ValidationException(Expense.EnterEndDate);
			if (pv_cEntity.Interval_ID < 1) throw new ValidationException(Expense.EnterInterval);
			if (pv_cEntity.PaymentDay_ID < 1) throw new ValidationException(Expense.EnterDay);
			if (pv_cEntity.BankAccount_ID < 1) throw new ValidationException(Expense.EnterBankAccount);
			if ((pv_cEntity.Company_ID < 1) && (string.IsNullOrEmpty(pv_cEntity.Description))) throw new ValidationException(Expense.EnterCompanyOrDescription);
			if (pv_cEntity.Amount < 1) throw new ValidationException(Expense.EnterAmount);
		}

		protected override Expression<Func<t_Expense, DateTime>> getStandardOrderBy()
		{
			return x => x.StartDate;
		}

		protected override Expression<Func<t_Expense, string>> getStandardThenBy()
		{
			return x => x.txx_BankAccount.AccountName;
		}

		protected override Expression<Func<t_Expense, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		public List<t_Expense> getExpenses()
		{
			return base.getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
