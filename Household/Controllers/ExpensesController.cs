using System.Web.Mvc;
using System;
using Household.BL.DATA.t;
using Household.Models;
using Household.Models.Finance;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.t;
using Household.Models.Search;
using System.Linq;
using Household.Localisation.Main.Finance;

namespace Household.Controllers
{
	public class ExpensesController : SearchableController<t_Expense, IExpenseManagement, DateTime, string, CExpenseData, CExpensesModel, CSearchExpense>
	{
		public ExpensesController(IExpenseManagement management)
			: base(management, "Expense")
		{ }

		protected override string GetSearchTitle()
		{
			return ExpenseText.Expenses;
		}

		[HttpPost]
		public PartialViewResult Expenses()
		{
			return PartialView();
		}

		[HttpPost]
		public PartialViewResult Expense(long id)
		{
			return PartialView("DatabaseEntry", new CExpenseModel(id));
		}

		[HttpPost]
		public override PartialViewResult GetTableFooter(CSearchExpense search)
		{
			var searchModel = new CExpensesModel();
			var expenses = Management.getExpenses(searchModel.GetSearchExpression(search));

			var footerModel = searchModel.CreateTableFooter(ActionName, ControllerName, expenses.Count, expenses.Sum(x => x.Amount));

			return PartialView("_MasterDataHeaderFooterPartial", footerModel);
		}
	}
}