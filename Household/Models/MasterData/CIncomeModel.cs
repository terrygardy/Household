using Household.Localisation.Main.MasterData;
using Household.Data.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Household.Data.Models.Base;
using Household.BL.DATA.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Interfaces;

namespace Household.Models.MasterData
{
	public class CIncomeModel : IDataBase
	{
		[Display(Name = "BankAccount", ResourceType = typeof(BankAccountText))]
		public List<txx_BankAccount> BankAccounts { get; set; }
		[Display(Name = "Company", ResourceType = typeof(CompanyText))]
		public List<txx_Company> Companies { get; set; }
		[Display(Name = "Day", ResourceType = typeof(DayText))]
		public List<txx_Day> Days { get; set; }
		[Display(Name = "Interval", ResourceType = typeof(IntervalText))]
		public List<txx_Interval> Intervals { get; set; }
		[Display(Name = "Income", ResourceType = typeof(IncomeText))]
		public CIncomeData Income { get; set; }

		public long ID
		{
			get { return Income.ID; }
			set { }
		}

		public string EntityName => Income.EntityName;

		public string EntityTitle => Income.EntityTitle;

		public CIncomeModel(IIncomeManagement incomeManagement,
			IBankAccountManagement bankAccountManagement,
			ICompanyManagement companyManagement,
			IDayManagement dayManagement,
			IIntervalManagement intervalManagement,
			long pv_lngID)
		{
			Income = incomeManagement.getDataByID(pv_lngID);

			if (Income == null) Income = new CIncomeData();

			BankAccounts = bankAccountManagement.getBankAccounts().ToList();
			Companies = companyManagement.getCompanies().ToList();
			Days = dayManagement.getDays().ToList();
			Intervals = intervalManagement.getIntervals().ToList();
		}
	}
}