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

		public CIncomeModel(Database pv_dbHousehold, long pv_lngID)
		{
			Income = new CIncome(pv_dbHousehold).getDataByID(pv_lngID);

			if (Income == null) Income = new CIncomeData();

			BankAccounts = new CBankAccount(pv_dbHousehold).getBankAccounts();
			Companies = new CCompany(pv_dbHousehold).getCompanies();
			Days = new CDay(pv_dbHousehold).getDays();
			Intervals = new CInterval(pv_dbHousehold).getIntervals();
		}
	}
}