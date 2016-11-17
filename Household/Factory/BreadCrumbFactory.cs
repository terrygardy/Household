using Household.Controllers;
using Household.Localisation.Common;
using Household.Localisation.Main.Finance;
using Household.Localisation.Main.MasterData;
using Household.Models;

namespace Household.Factory
{
	public static class BreadCrumbFactory
	{
		public static CBreadCrumb GetHomeIndex()
		{
			return new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = nameof(HomeController.Index),
				Text = GeneralText.Home
			};
		}

		public static CBreadCrumb GetFinanceFinance()
		{
			return new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = nameof(FinanceController.Finance),
				Text = FinanceText.Finance
			};
		}

		public static CBreadCrumb GetFinanceMasterData()
		{
			return new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = nameof(FinanceController.MasterData),
				Text = MasterDataText.MasterData
			};
		}
	}
}