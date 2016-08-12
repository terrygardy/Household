using Household.BL.Functions.t;
using WebHelpers;
using System.Web.Mvc;
using Household.Models.MasterData;
using Household.Models.Db;
using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Finance;

namespace Household.Controllers
{
	public class ExpensesController : Controller
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		[HttpPost]
		public PartialViewResult Expenses()
		{
			return PartialView(m_strMasterDataUrl, new CMasterData() { DisplayTable = new CExpensesModel(CDbContext.getInstance()).getDisplayTable(), Title = "Expenses" });
		}

		[HttpPost]
		public PartialViewResult Expense(long id)
		{
			return PartialView(new CExpenseModel(CDbContext.getInstance(), id));
		}

		[HttpPost]
		public string Save([System.Web.Http.FromBody]CExpenseData Expense)
		{
			string strMessage = "";

			try
			{
				new CExpense(CDbContext.getInstance()).save(Expense);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return JSON.serialiseObject(new CReturn() { ID = Expense.ID, Message = strMessage });
		}

		[HttpPost]
		public string Delete(long id)
		{
			string strMessage = "";

			try
			{
				new CExpense(CDbContext.getInstance()).deleteByID(id);
			}
			catch (Exception ex)
			{
				strMessage = ex.Message;
			}

			return strMessage;
		}
	}
}