using Household.Models.DisplayTable;
using Household.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.Interfaces;

namespace Household.Models.Search.Base
{
	public abstract class CSearchModelBase<TEntity, TSearchModel, TSearchManagement> : ISearchModel<TEntity, TSearchModel>
		where TEntity : class, new()
		where TSearchModel : new()
	{
		protected readonly TSearchManagement SearchManagement;
		protected DateTime m_datNull = new DateTime(1753, 1, 1);
		protected TimeSpan m_tsNull = new TimeSpan(0, 0, 0);
		public TSearchModel SearchModel { get; set; } = new TSearchModel();

		protected CSearchModelBase(TSearchManagement searchManagement)
		{
			SearchManagement = searchManagement;
		}

		public CDisplayTable GetDisplayTable(string actionMain, string controller) => GetDisplayTable(null, actionMain, controller);

		public abstract List<CDisplayRow> CreateTableHead(string action, string controller);

		public abstract List<CDisplayRow> CreateTableFooter(string action, string controller, int count);

		public abstract List<CDisplayRow> CreateTableBody(string action, string controller, ICollection<TEntity> lstEntities);

		public abstract CDisplayRow CreateBodyRow(string action, string controller, TEntity tEntity);

		public CDisplayTable GetDisplayTable(Expression<Func<TEntity, bool>> exSearch, string actionMain, string controller)
		{
			//var lstItems = SearchManagement.getSearchResults(exSearch);
			//var dtTable = new CDisplayTable()
			//{
			//	AddAction = actionMain,
			//	AddController = controller
			//};

			//dtTable.Head = CreateTableHead(actionMain, controller);
			//dtTable.Body = CreateTableBody(actionMain, controller, lstItems);
			//dtTable.Foot = CreateTableFooter(actionMain, controller, lstItems.Count);

			//return dtTable;

			return null;
		}

		public CDisplayTable Search(TSearchModel pv_smSearch, string actionMain, string controller)
		{
			return GetDisplayTable(GetSearchExpression(pv_smSearch), actionMain, controller);
		}

		public abstract Expression<Func<TEntity, bool>> GetSearchExpression(TSearchModel pv_swSearch);
	}
}