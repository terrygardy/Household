using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using System;
using Household.Data.Models.Base;

namespace Household.Controllers.Base
{
	public abstract class CRUDController<TClass, TBL, Tdata> : Controller
		where TClass : class, new()
		where Tdata : class, IDataBase, new()
		where TBL : IManagementBase<TClass, Tdata>
	{
		protected readonly TBL Management;
		protected string MasterDataViewUrl => "_MasterData";
		protected string ControllerName;

		protected CRUDController(TBL management)
		{
			Management = management;
			var typeName = this.GetType().Name;
			ControllerName = typeName.Substring(0, typeName.IndexOf("Controller"));
		}

		[HttpPost]
		public string Save([System.Web.Http.FromBody]Tdata Data)
		{
			var strMessage = "";

			try
			{
				Management.save(Data);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Data.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			var strMessage = "";

			try
			{
				Management.deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}

		[HttpPost]
		public PartialViewResult Preview(long id)
		{
			return PartialView($"~/Views/Shared/Previews/_{ControllerName}PreviewPartial.cshtml", Management.getDataByID(id));
		}
	}
}