using Household.BL.Functions.t;
using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using System;
using Household.BL.DATA.t;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class IncomeController : CRUDController<t_Income, CIncome, DateTime, string, CIncomeData>
	{
		protected override long GetDataID(CIncomeData data)
		{
			return data.ID;
		}
	}
}