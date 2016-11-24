using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.Data.Db;
using System.Linq;
using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Interfaces;

namespace Household.BL.Management.t.Implementations
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
			var today = DateTime.Today;
			var minDate = Data.Common.DbTools.MinDate;
			var startDate = new DateTime(today.Year, today.Month, 1);
			var endDate = startDate.AddMonths(1).AddDays(-1);
			var monthlyIntervalId = _intervalManagement.getIntervals(x => x.Name.Equals("monthly", StringComparison.OrdinalIgnoreCase)).Select(y => y.ID).FirstOrDefault();
			var yearlyIntervalId = _intervalManagement.getIntervals(x => x.Name.Equals("yearly", StringComparison.OrdinalIgnoreCase)).Select(y => y.ID).FirstOrDefault();
			var sumIncomes = _incomeManagement.getIncomes(x => x.Interval_ID == monthlyIntervalId
															&& x.StartDate <= today
															&& (x.EndDate <= minDate || x.EndDate >= today)).Sum(y => y.Amount);
			var sumPurchases = _purchaseManagement.getPurchases(p => p.Occurrence >= startDate && p.Occurrence <= endDate).Sum(x => x.Amount);
			var sumExpensesMonthly = _expenseManagement.getExpenses(x => x.Interval_ID == monthlyIntervalId
																	&& x.StartDate <= today
																	&& (x.EndDate <= minDate || x.EndDate >= today)).Sum(y => y.Amount);
			var sumExpensesYearly = _expenseManagement.getExpenses(x => x.Interval_ID == yearlyIntervalId
																	&& x.StartDate <= today
																	&& (x.EndDate <= minDate || x.EndDate >= today))
																	.Select(e => e.Amount / 12).Sum();

			return sumIncomes - (sumPurchases + sumExpensesMonthly + sumExpensesYearly);
		}
	}
}
