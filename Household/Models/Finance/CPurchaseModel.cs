using Household.BL.DATA.Base;
using Household.BL.DATA.t;
using Household.BL.Functions.Management.t;
using Household.BL.Functions.Management.txx;
using Household.Data.Context;
using Household.Localisation.Main.Finance;
using Household.Localisation.Main.MasterData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Household.Models.Finance
{
	public class CPurchaseModel : IDataBase
	{
		[Display(Name = "BankAccount", ResourceType = typeof(BankAccountText))]
		public List<txx_BankAccount> BankAccounts { get; set; }
		[Display(Name = "Shop", ResourceType = typeof(ShopText))]
		public List<txx_Shop> Shops { get; set; }
		[Display(Name = "Purchase", ResourceType = typeof(PurchaseText))]
		public CPurchaseData Purchase { get; set; }

		public long ID
		{
			get { return Purchase.ID; }
			set { }
		}

		public string EntityName => Purchase.EntityName;

		public string EntityTitle => Purchase.EntityTitle;

		public CPurchaseModel(IPurchaseManagement purchaseManagement,
			IBankAccountManagement bankAccountManagement,
			IShopManagement shopManagement,
			long pv_lngID)
		{
			Purchase = purchaseManagement.getDataByID(pv_lngID);

			if (Purchase == null) Purchase = new CPurchaseData();

			BankAccounts = bankAccountManagement.getBankAccounts().ToList();
			Shops = shopManagement.getShops().ToList();
		}
	}
}