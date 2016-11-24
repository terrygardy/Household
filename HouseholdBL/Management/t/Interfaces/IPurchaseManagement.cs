using Household.BL.DATA.t.Implementations;
using Household.BL.Returns;
using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Management.t.Interfaces
{
	public interface IPurchaseManagement : IManagementBase<t_Purchase, CPurchaseData>
	{
		IEnumerable<CShopChartInfo> getPurchaseInfoForShopChart(long pv_lngShop, int pv_intYear);

		decimal getSumByYear(int pv_intYear);

		IEnumerable<t_Purchase> getPurchases();

		IEnumerable<t_Purchase> getPurchases(Expression<Func<t_Purchase, bool>> pv_exWhere);
	}
}