using Household.BL.DATA.t;
using Household.BL.Returns;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Functions.Management.t
{
	public interface IPurchaseManagement : IManagementBase<t_Purchase, DateTime, string, CPurchaseData>
	{
		List<CShopChartInfo> getPurchaseInfoForShopChart(long pv_lngShop, int pv_intYear);

		decimal getSumByYear(int pv_intYear);

		List<t_Purchase> getPurchases();

		List<t_Purchase> getPurchases(Expression<Func<t_Purchase, bool>> pv_exWhere);
	}
}