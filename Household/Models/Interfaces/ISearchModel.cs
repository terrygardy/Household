using Household.Models.DisplayTable;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.Models.Interfaces
{
	public interface ISearchModel<TEntity, TSearchModel>
		where TEntity : class, new()
	{
		CDisplayTable GetDisplayTable(string actionMain, string controller);

		List<CDisplayRow> CreateTableHead(string actionMain, string controller);

		List<CDisplayRow> CreateTableFooter(string actionMain, string controller, int count, decimal sum);

		List<CDisplayRow> CreateTableBody(string actionMain, string controller, List<TEntity> lstEntities);

		CDisplayRow CreateBodyRow(string actionMain, string controller, TEntity tEntity);

		CDisplayTable GetDisplayTable(Expression<Func<TEntity, bool>> exSearch, string actionMain, string controller);

		CDisplayTable Search(TSearchModel pv_smSearch, string actionMain, string controller);
	}
}