using Household.BL.Functions.t;
using System.Web.Mvc;
using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Finance;
using Household.Controllers.Base;
using Household.Data.Context;

namespace Household.Controllers
{
	public class ExpensesController : CRUDController<t_Expense, CExpense, DateTime, string, CExpenseData>
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		protected override long GetDataID(CExpenseData data)
		{
			return data.ID;
		}

		[HttpPost]
		public PartialViewResult Expenses()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CExpensesModel().getDisplayTable(), Title = "Expenses" });
		}

		[HttpPost]
		public PartialViewResult Expense(long id)
		{
			return PartialView(new CExpenseModel(id));
		}
	}
}