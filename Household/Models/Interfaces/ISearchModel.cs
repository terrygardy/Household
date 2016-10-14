using Household.Models.DisplayTable;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.Models.Interfaces
{
	public interface ISearchModel<TEntity, TSearchModel>
		where TEntity : class, new()
	{
		CDisplayTable GetDisplayTable();

		List<CDisplayRow> CreateTableHead(string action, string controller);

		List<CDisplayRow> CreateTableFooter(string action, string controller, int workDaysCount, decimal workedHoursSum);

		List<CDisplayRow> CreateTableBody(string action, string controller, List<TEntity> lstWorkDays);

		CDisplayRow CreateBodyRow(string action, string controller, TEntity tWorkDay);

		CDisplayTable GetDisplayTable(Expression<Func<TEntity, bool>> exSearch);

		CDisplayTable Search(TSearchModel pv_swSearch);
	}
}