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
		where TBL : CModelBase<TClass, Tob, Ttb, Tdata>, new()
	{
		protected abstract long GetDataID(Tdata data);

		[HttpPost]
		public string Save([System.Web.Http.FromBody]Tdata Data)
		{
			string strMessage = "";

			try
			{
				new TBL().save(Data);
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
				new TBL().deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}