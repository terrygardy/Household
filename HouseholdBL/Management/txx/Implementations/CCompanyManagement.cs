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
	public class CCompanyManagement : CManagementBase<txx_Company, string, string, CCompanyData>, ICompanyManagement
	{
		public CCompanyManagement(IDb db)
		: base(db) { }

		protected override void deleteAllowed(txx_Company pv_cEntity)
		{
			if (Db.GetGenericRepository<t_Income>().Where(x => x.Company_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Company.InUseIncome);
			if (Db.GetGenericRepository<t_Expense>().Where(x => x.Company_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Company.InUseExpense);

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

		public IEnumerable<txx_Company> getCompanies()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}