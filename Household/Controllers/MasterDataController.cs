using Household.BL.DATA.t;
using Household.BL.DATA.txx;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.BL.Interfaces.t;
using Household.BL.Interfaces.txx;
using Household.Models;
using Household.Models.MasterData;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class MasterDataController : Controller
	{
		private string m_strMasterDataUrl = "../Shared/MasterData";

		[HttpPost]
		public PartialViewResult People()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "People"
			});

			cData.DisplayTable = new CPeopleModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult Person(long id)
		{
			IPerson objPerson = new CPerson().getDataByID(id);

			if (objPerson == null) objPerson = new CPersonData();

			return PartialView("Person", objPerson);
		}

		[HttpPost]
		public PartialViewResult BankAccounts()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "Bank Accounts"
			});

			cData.DisplayTable = new CBankAccountsModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult BankAccount(long id)
		{
			IBankAccount objBankAccount = new CBankAccount().getDataByID(id);

			if (objBankAccount == null) objBankAccount = new CBankAccountData();

			return PartialView("BankAccount", objBankAccount);
		}

		[HttpPost]
		public PartialViewResult Companies()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "Companies"
			});

			cData.DisplayTable = new CCompaniesModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult Company(long id)
		{
			ICompany objCompany = new CCompany().getDataByID(id);

			if (objCompany == null) objCompany = new CCompanyData();

			return PartialView("Company", objCompany);
		}

		[HttpPost]
		public PartialViewResult Days()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "Days"
			});

			cData.DisplayTable = new CDaysModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult Day(long id)
		{
			var objDay = new CDay().getDataByID(id);

			if (objDay == null) objDay = new CDayData();

			return PartialView("Day", objDay);
		}

		[HttpPost]
		public PartialViewResult Intervals()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "Intervals"
			});

			cData.DisplayTable = new CIntervalsModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult Interval(long id)
		{
			IInterval objInterval = new CInterval().getDataByID(id);

			if (objInterval == null) objInterval = new CIntervalData();

			return PartialView("Interval", objInterval);
		}

		[HttpPost]
		public PartialViewResult Shops()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "Shops"
			});

			cData.DisplayTable = new CShopsModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult Shop(long id)
		{
			IShop objShop = new CShop().getDataByID(id);

			if (objShop == null) objShop = new CShopData();

			return PartialView("Shop", objShop);
		}

		[HttpPost]
		public PartialViewResult Incomes()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Home",
				ActionName = "Index",
				Text = "Home"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "Finance",
				Text = "Finance"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				ActionController = "Finance",
				ActionName = "MasterData",
				Text = "Master Data"
			});

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = "Income"
			});

			cData.DisplayTable = new CIncomesModel().getDisplayTable();

			return PartialView(m_strMasterDataUrl, cData);
		}

		[HttpPost]
		public PartialViewResult Income(long id)
		{
			return PartialView("Income", new CIncomeModel(id));
		}
	}
}