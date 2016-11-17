using Household.BL.DATA.t;
using Household.BL.Functions.Management.t;
using Household.BL.Functions.Management.txx;
using Household.Data.Context;
using Household.Data.Models.Base;
using Household.Localisation.Main.Finance;
using Household.Localisation.Main.MasterData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Household.Models.Finance
{
	public class CExpenseModel : IDataBase
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

		public long ID => Expense.ID;

		public string EntityName => Expense.EntityName;

		public string EntityTitle => Expense.EntityTitle;

		public CExpenseModel(IExpenseManagement expenseManagement,
			IBankAccountManagement bankAccountManagement,
			ICompanyManagement companyManagement,
			IIntervalManagement intervalManagement,
			IDayManagement dayManagement,
			long pv_lngID)
		{
			Expense = expenseManagement.getDataByID(pv_lngID);

			if (Expense == null) Expense = new CExpenseData();

			BankAccounts = bankAccountManagement.getBankAccounts().ToList();
			Companies = companyManagement.getCompanies().ToList();
			Intervals = intervalManagement.getIntervals().ToList();
			Days = dayManagement.getDays().ToList();
		}
	}
}