using Household.BL.DATA.t.Implementations;
using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.BL.Management.txx.Interfaces;
using Household.Factory;
using Household.Localisation.Main.MasterData;
using Household.Models;
using Household.Models.MasterData;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class MasterDataController : Controller
	{
		private readonly IPersonManagement _personManagement;
		private readonly IBankAccountManagement _bankAccountManagement;
		private readonly IDayManagement _dayManagement;
		private readonly ICompanyManagement _companyManagement;
		private readonly IIntervalManagement _intervalManagement;
		private readonly IShopManagement _shopManagement;
		private readonly IIncomeManagement _incomeManagement;

		public MasterDataController(IPersonManagement personManagement,
			IBankAccountManagement bankAccountManagement,
			IDayManagement dayManagement,
			ICompanyManagement companyManagement,
			IIntervalManagement intervalManagement,
			IShopManagement shopManagement,
			IIncomeManagement incomeManagement)
		{
			_personManagement = personManagement;
			_bankAccountManagement = bankAccountManagement;
			_dayManagement = dayManagement;
			_companyManagement = companyManagement;
			_intervalManagement = intervalManagement;
			_shopManagement = shopManagement;
			_incomeManagement = incomeManagement;
		}

		[HttpPost]
		public PartialViewResult People()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = PersonText.People
			});

			cData.DisplayTable = new CPeopleModel(_personManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult Person(long id)
		{
			var objPerson = _personManagement.getDataByID(id);

			if (objPerson == null) objPerson = new CPersonData();

			return PartialView("DatabaseEntry", objPerson);
		}

		[HttpPost]
		public PartialViewResult BankAccounts()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = BankAccountText.BankAccounts
			});

			cData.DisplayTable = new CBankAccountsModel(_bankAccountManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult BankAccount(long id)
		{
			var objBankAccount = _bankAccountManagement.getDataByID(id);

			if (objBankAccount == null) objBankAccount = new CBankAccountData();

			return PartialView("DatabaseEntry", objBankAccount);
		}

		[HttpPost]
		public PartialViewResult Companies()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = CompanyText.Companies
			});

			cData.DisplayTable = new CCompaniesModel(_companyManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult Company(long id)
		{
			var objCompany = _companyManagement.getDataByID(id);

			if (objCompany == null) objCompany = new CCompanyData();

			return PartialView("DatabaseEntry", objCompany);
		}

		[HttpPost]
		public PartialViewResult Days()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = DayText.Days
			});

			cData.DisplayTable = new CDaysModel(_dayManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult Day(long id)
		{
			var objDay = _dayManagement.getDataByID(id);

			if (objDay == null) objDay = new CDayData();

			return PartialView("Day", objDay);
		}

		[HttpPost]
		public PartialViewResult Intervals()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = IntervalText.Intervals
			});

			cData.DisplayTable = new CIntervalsModel(_intervalManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult Interval(long id)
		{
			var objInterval = _intervalManagement.getDataByID(id);

			if (objInterval == null) objInterval = new CIntervalData();

			return PartialView("DatabaseEntry", objInterval);
		}

		[HttpPost]
		public PartialViewResult Shops()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = ShopText.Shops
			});

			cData.DisplayTable = new CShopsModel(_shopManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult Shop(long id)
		{
			var objShop = _shopManagement.getDataByID(id);

			if (objShop == null) objShop = new CShopData();

			return PartialView("DatabaseEntry", objShop);
		}

		[HttpPost]
		public PartialViewResult Incomes()
		{
			var cData = new CMasterData();

			cData.BreadCrumbs.Add(BreadCrumbFactory.GetHomeIndex());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceFinance());
			cData.BreadCrumbs.Add(BreadCrumbFactory.GetFinanceMasterData());

			cData.BreadCrumbs.Add(new CBreadCrumb()
			{
				Text = IncomeText.Income
			});

			cData.DisplayTable = new CIncomesModel(_incomeManagement, _companyManagement).getDisplayTable();

			return PartialView("_MasterData", cData);
		}

		[HttpPost]
		public PartialViewResult Income(long id)
		{
			return PartialView("DatabaseEntry", new CIncomeModel(_incomeManagement, _bankAccountManagement, _companyManagement, _dayManagement, _intervalManagement, id));
		}
	}
}