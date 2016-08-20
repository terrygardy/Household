using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.DATA.t;

namespace Household.BL.Functions.t
{
	public class CIncome : CModelBase<t_Income, DateTime, string, CIncomeData>
	{
		public CIncome() { }

		protected override Expression<Func<t_Income, DateTime>> getStandardOrderBy()
		{
			return x => x.StartDate;
		}

		protected override Expression<Func<t_Income, string>> getStandardThenBy()
		{
			return x => x.txx_BankAccount.AccountName;
		}

		protected override Expression<Func<t_Income, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		public List<t_Income> getIncomes()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
