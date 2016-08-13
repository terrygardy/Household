using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using GARTE.TypeHandling;
using Household.BL.DATA.t;

namespace Household.BL.Functions.t
{
	public class CIncome : CModelBase<t_Income, DateTime, string, CIncomeData>
	{
		public CIncome() { }

		public override void validate(t_Income pv_cEntity)
		{
			DateTime datEnd;

			if (pv_cEntity.StartDate <= MinDate) throw new ValidationException(Income.EnterStartDate);
			if (pv_cEntity.Interval_ID < 1) throw new ValidationException(Income.EnterInterval);
			if (pv_cEntity.Payee_ID < 1) throw new ValidationException(Income.EnterPayee);
			if ((pv_cEntity.Company_ID < 1) && (string.IsNullOrEmpty(pv_cEntity.Description))) throw new ValidationException(Income.EnterCompanyOrDescription);
			if (pv_cEntity.Amount <= 0) throw new ValidationException(Income.EnterAmount);
			if (pv_cEntity.Day_ID < 1) throw new ValidationException(Income.EnterDay);

			datEnd = Base.convertDate(pv_cEntity.EndDate);

			if ((datEnd > MinDate) && (datEnd < pv_cEntity.StartDate)) throw new ValidationException(Income.EndDateInvalid);
		}

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
