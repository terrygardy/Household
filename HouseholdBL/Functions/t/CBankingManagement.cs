using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.Data.Db;
using Household.BL.Functions.Management.t;
using System.Linq;
using Household.BL.Functions.Management.txx;

namespace Household.BL.Functions.t
{
	public class CBankingManagement : IBankingManagement
	{
		private readonly IDb _db;
		private readonly IPurchaseManagement _purchaseManagement;
		private readonly IIntervalManagement _intervalManagement;
		private readonly IIncomeManagement _incomeManagement;
		private readonly IExpenseManagement _expenseManagement;

		public CBankingManagement(IDb db, IPurchaseManagement purchaseManagement,
			IIntervalManagement intervalManagement, IIncomeManagement incomeManagement,
			IExpenseManagement expenseManagement)
		{
			_db = db;
			_purchaseManagement = purchaseManagement;
			_intervalManagement = intervalManagement;
			_incomeManagement = incomeManagement;
			_expenseManagement = expenseManagement;
		}

		public IEnumerable<t_BankBalance> getBankBalances()
		{
			return getBankBalances(null);
		}

		public IEnumerable<t_BankBalance> getBankBalances(Expression<Func<t_BankBalance, bool>> pv_exWhere)
		{
			return _db.getEntities(pv_exWhere, b => b.ReferenceDate, b => b.Balance);
		}

		public decimal getCurrentBankBalance()
		{
			var startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
			var endDate = startDate.AddMonths(1).AddDays(-1);
			var intervalId = _intervalManagement.getIntervals(x => x.Name.Equals("monthly", StringComparison.OrdinalIgnoreCase)).Select(y => y.ID).FirstOrDefault();
			var sumIncomes = _incomeManagement.getIncomes(x => x.Interval_ID == intervalId
															&& x.StartDate <= DateTime.Today
															&& (x.EndDate <= Data.Common.DbTools.MinDate || x.EndDate >= DateTime.Today)).Sum(y => y.Amount);
			var sumPurchases = _purchaseManagement.getPurchases(p => p.Occurrence >= startDate && p.Occurrence <= endDate).Sum(x => x.Amount);
			var sumExpensesMonthly = _expenseManagement.getExpenses(x => x.Interval_ID == intervalId
																	&& x.StartDate <= DateTime.Today
																	&& (x.EndDate <= Data.Common.DbTools.MinDate || x.EndDate >= DateTime.Today)).Sum(y => y.Amount);

			return sumIncomes - (sumPurchases + sumExpensesMonthly);
		}
	}
}
