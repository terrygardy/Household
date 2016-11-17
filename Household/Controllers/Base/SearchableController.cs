using Household.Data.Models.Base;
using Household.Models;
using Household.Models.Interfaces;
using System.Web.Mvc;

namespace Household.Controllers.Base
{
	public abstract class SearchableController<TClass, TBL, Tdata, TSearch, TSearchModel> : CRUDController<TClass, TBL, Tdata>
		where TClass : class, new()
		where Tdata : class, IDataBase , new()
		where TBL : IManagementBase<TClass, Tdata>
		where TSearch : ISearchModel<TClass, TSearchModel>
	{
		protected readonly string ActionName;

		public SearchableController(TBL management, string action) : base(management)
		{
			ActionName = action;
		}

		protected abstract string GetSearchTitle();
		protected abstract TSearch getSearchClass();

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]TSearchModel search)
		{
			return PartialView(MasterDataViewUrl, new CMasterData() { DisplayTable = getSearchClass().Search(search, ActionName, ControllerName), Title = GetSearchTitle() });
		}

		[HttpPost]
		public PartialViewResult GetTableBodyRow(long id)
		{
			var entity = Management.getModelByID(id);
			var bodyRowModel = getSearchClass().CreateBodyRow(ActionName, ControllerName, entity);

			return PartialView("_MasterDataBodyRowPartial", bodyRowModel);
		}

		[HttpPost]
		public abstract PartialViewResult GetTableFooter(TSearchModel search);
	}
}