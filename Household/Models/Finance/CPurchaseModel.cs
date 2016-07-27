using Household.BL.DATA.t;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using System.Collections.Generic;

namespace Household.Models.Finance
{
	public class CPurchaseModel
	{
		public List<txx_BankAccount> BankAccounts { get; set; }
		public List<txx_Shop> Shops { get; set; }
		public CPurchaseData Purchase { get; set; }

		public CPurchaseModel(Database pv_dbHousehold, long pv_lngID)
		{
			Purchase = new CPurchase(pv_dbHousehold).getDataByID(pv_lngID);

			if (Purchase == null) Purchase = new CPurchaseData();

			BankAccounts = new CBankAccount(pv_dbHousehold).getBankAccounts();
			Shops = new CShop(pv_dbHousehold).getShops();
		}
	}
}