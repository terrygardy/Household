using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Household.BL.Returns;
using Household.BL.Management.t.Interfaces;
using Household.Data.Db;
using Household.BL.DATA.t.Implementations;

namespace Household.BL.Management.t.Implementations
{
	public class CPurchaseManagement : CManagementBase<t_Purchase, DateTime, string, CPurchaseData>, IPurchaseManagement
	{
		public CPurchaseManagement(IDb db)
		: base(db) { }

		protected override Expression<Func<t_Purchase, DateTime>> getStandardOrderBy()
		{
			return x => x.Occurrence;
		}

		protected override Expression<Func<t_Purchase, string>> getStandardThenBy()
		{
			return x => x.txx_Shop.Name;
		}

		public IEnumerable<CShopChartInfo> getPurchaseInfoForShopChart(long shopID, int year)
		{
			return Db.GetGenericRepository<t_Purchase>().Where(x => x.Shop_ID == shopID && x.Occurrence.Year == year)
										.GroupBy(x => x.Occurrence.Month)
										.Select(x =>
											new CShopChartInfo
											{
												Integer = x.Key,
												Decimal = x.Sum(w => w.Amount)
											})
											.OrderBy(x => x.Integer);
		}

		public decimal getSumByYear(int pv_intYear)
		{
			var lstPurchases = getEntities(x => x.Occurrence.Year == pv_intYear, getStandardOrderBy(), getStandardThenBy());

			if (lstPurchases.Any())
			{
				return lstPurchases.Sum(x => x.Amount);
			}
			else
			{
				return 0;
			}
		}

		public IEnumerable<t_Purchase> getPurchases()
		{
			return getPurchases(null);
		}

		public IEnumerable<t_Purchase> getPurchases(Expression<Func<t_Purchase, bool>> whereClause)
		{
			return getEntities(whereClause, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
