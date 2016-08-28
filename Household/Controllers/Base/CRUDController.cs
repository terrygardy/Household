using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using System;
using Household.Data.Models.Base;

namespace Household.Controllers.Base
{
	public abstract class CRUDController<TClass, TBL, Tob, Ttb, Tdata> : Controller
		where TClass : class, new()
		where Tdata : class, new()
		where TBL : IManagementBase<TClass, Tob, Ttb, Tdata>
	{
		protected readonly TBL _management;

		protected CRUDController(TBL management) {
			_management = management;
		}

		protected abstract long GetDataID(Tdata data);

		[HttpPost]
		public string Save([System.Web.Http.FromBody]Tdata Data)
		{
			string strMessage = "";

			try
			{
				_management.save(Data);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = GetDataID(Data), Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				_management.deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}