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
	public class CCompany : CModelBase<txx_Company, string, string, CCompanyData>
	{
		public CCompany() { }

		protected override void deleteAllowed(txx_Company pv_cEntity)
		{
			if (Database.t_Income.Where(x => x.Company_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Company.InUseIncome);
			if (Database.t_Expense.Where(x => x.Company_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Company.InUseExpense);

			base.deleteAllowed(pv_cEntity);
		}

		protected override Expression<Func<txx_Company, string>> getStandardOrderBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<txx_Company, string>> getStandardThenBy()
		{
			return x => x.Description;
		}

		protected override Expression<Func<txx_Company, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		public List<txx_Company> getCompanies()
		{
			return getEntities<string, string>(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
