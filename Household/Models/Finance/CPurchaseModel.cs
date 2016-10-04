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
	public class CPurchaseModel
	{
		[Display(Name = "BankAccount", ResourceType = typeof(BankAccountText))]
		public List<txx_BankAccount> BankAccounts { get; set; }
		[Display(Name = "Shop", ResourceType = typeof(ShopText))]
		public List<txx_Shop> Shops { get; set; }
		[Display(Name = "Purchase", ResourceType = typeof(PurchaseText))]
		public CPurchaseData Purchase { get; set; }

		public CPurchaseModel(long pv_lngID)
		{
			Purchase = new CPurchaseManagement().getDataByID(pv_lngID);

			if (Purchase == null) Purchase = new CPurchaseData();

			BankAccounts = new CBankAccountManagement().getBankAccounts();
			Shops = new CShopManagement().getShops();
		}
	}
}