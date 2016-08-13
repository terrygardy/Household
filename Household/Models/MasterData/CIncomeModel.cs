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

		public CIncomeModel(long pv_lngID)
		{
			Income = new CIncome().getDataByID(pv_lngID);

			if (Income == null) Income = new CIncomeData();

			BankAccounts = new CBankAccount().getBankAccounts();
			Companies = new CCompany().getCompanies();
			Days = new CDay().getDays();
			Intervals = new CInterval().getIntervals();
		}
	}
}