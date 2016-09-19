using Household.Localisation.Main.MasterData;
using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using System.Collections.Generic;

namespace Household.Models.MasterData
{
	public class CIncomeModel
	{
		public List<txx_BankAccount> BankAccounts { get; set; }
		public List<txx_Company> Companies { get; set; }
		public List<txx_Day> Days { get; set; }
		public List<txx_Interval> Intervals { get; set; }
		public CIncomeData Income { get; set; }
		public string Name { get { return IncomeText.Income; } }

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