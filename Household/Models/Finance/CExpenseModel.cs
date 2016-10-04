using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Localisation.Main.Finance;
using Household.Localisation.Main.MasterData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Household.Models.Finance
{
	public class CExpenseModel
	{
		[Display(Name = "BankAccount", ResourceType = typeof(BankAccountText))]
		public List<txx_BankAccount> BankAccounts { get; set; }
		[Display(Name = "Company", ResourceType = typeof(CompanyText))]
		public List<txx_Company> Companies { get; set; }
		[Display(Name = "Interval", ResourceType = typeof(IntervalText))]
		public List<txx_Interval> Intervals { get; set; }
		[Display(Name = "Day", ResourceType = typeof(DayText))]
		public List<txx_Day> Days { get; set; }
		[Display(Name = "Expense", ResourceType = typeof(ExpenseText))]
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