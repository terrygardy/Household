using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using System.Collections.Generic;

namespace Household.Models.Finance
{
	public class CExpenseModel
	{
		public List<txx_BankAccount> BankAccounts { get; set; }
		public List<txx_Company> Companies { get; set; }
		public List<txx_Interval> Intervals { get; set; }
		public List<txx_Day> Days { get; set; }
		public CExpenseData Expense { get; set; }

		public CExpenseModel(long pv_lngID)
		{
			Expense = new CExpenseManagement().getDataByID(pv_lngID);

			if (Expense == null) Expense = new CExpenseData();

			BankAccounts = new CBankAccountManagement().getBankAccounts();
			Companies = new CCompanyManagement().getCompanies();
			Intervals = new CIntervalManagement().getIntervals();
			Days = new CDayManagement().getDays();
		}
	}
}