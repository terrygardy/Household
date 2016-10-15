using Household.Data.Models.Base;
using Household.Models;
using Household.Models.Interfaces;
using System.Web.Mvc;

namespace Household.Controllers.Base
{
	public abstract class SearchableController<TClass, TBL, Tob, Ttb, Tdata, TSearch, TSearchModel> : CRUDController<TClass, TBL, Tob, Ttb, Tdata>
		where TClass : class, new()
		where Tdata : class, new()
		where TBL : IManagementBase<TClass, Tob, Ttb, Tdata>
		where TSearch : ISearchModel<TClass, TSearchModel>, new()
	{
		protected readonly string ActionName;
		protected readonly string ControllerName;

		public SearchableController(TBL management, string action, string controller, string previewViewName) : base(management, previewViewName)
		{
			ActionName = action;
			ControllerName = controller;
		}

		protected abstract string GetSearchTitle();

		[HttpPost]
		public PartialViewResult Search([System.Web.Http.FromBody]TSearchModel search)
		{
			return PartialView(MasterDataViewUrl, new CMasterData() { DisplayTable = new TSearch().Search(search, ActionName, ControllerName), Title = GetSearchTitle() });
		}

		[HttpPost]
		public PartialViewResult GetTableBodyRow(long id)
		{
			var entity = Management.getModelByID(id);
			var bodyRowModel = new TSearch().CreateBodyRow(ActionName, ControllerName, entity);

			return PartialView("_MasterDataBodyRowPartial", bodyRowModel);
		}

		[HttpPost]
		public abstract PartialViewResult GetTableFooter(TSearchModel search);
	}
}