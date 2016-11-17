using System.Web.Mvc;
using Household.BL.DATA.t;
using Household.Models.Finance;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.t;
using Household.Models.Search;
using System.Linq;
using Household.Localisation.Main.Finance;
using System;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class ExpensesController : SearchableController<t_Expense, IExpenseManagement, CExpenseData, CExpensesModel, CSearchExpense>
	{
		private readonly IBankAccountManagement _bankAccountManagement;
		private readonly ICompanyManagement _companyManagement;
		private readonly IIntervalManagement _intervalManagement;
		private readonly IDayManagement _dayManagement;

		public ExpensesController(IExpenseManagement management,
			IBankAccountManagement bankAccountManagement,
			ICompanyManagement companyManagement,
			IIntervalManagement intervalManagement,
			IDayManagement dayManagement)
			: base(management, nameof(Expense))
		{
			_bankAccountManagement = bankAccountManagement;
			_companyManagement = companyManagement;
			_intervalManagement = intervalManagement;
			_dayManagement = dayManagement;
		}

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
			return PartialView("DatabaseEntry", new CExpenseModel(Management, _bankAccountManagement, _companyManagement, _intervalManagement, _dayManagement, id));
		}

		[HttpPost]
		public override PartialViewResult GetTableFooter(CSearchExpense search)
		{
			var searchModel = getSearchClass();
			var expenses = Management.getExpenses(searchModel.GetSearchExpression(search));

			var footerModel = searchModel.CreateTableFooter(ActionName, ControllerName, expenses.Count(), expenses.Sum(x => x.Amount));

			return PartialView("_MasterDataHeaderFooterPartial", footerModel);
		}

		protected override CExpensesModel getSearchClass()
		{
			return new CExpensesModel(Management);
		}
	}
}