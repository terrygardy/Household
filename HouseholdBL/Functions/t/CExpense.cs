﻿using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Linq.Expressions;
using Household.BL.DATA.t;
using System.Collections.Generic;

namespace Household.BL.Functions.t
{
	public class CExpense : CModelBase<t_Expense, DateTime, string, CExpenseData>
	{
		public CExpense() { }

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
