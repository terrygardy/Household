using Household.Localisation.Main.MasterData;
using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Household.BL.DATA.Base;

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

		public long ID => Income.ID;

		public string EntityName => Income.EntityName;

		public string EntityTitle => Income.EntityTitle;

		public CIncomeModel(long pv_lngID)
		{
			Income = new CIncomeManagement().getDataByID(pv_lngID);

			if (Income == null) Income = new CIncomeData();

			BankAccounts = new CBankAccountManagement().getBankAccounts();
			Companies = new CCompanyManagement().getCompanies();
			Days = new CDayManagement().getDays();
			Intervals = new CIntervalManagement().getIntervals();
		}
	}
}