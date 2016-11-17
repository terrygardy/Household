using Household.BL.Functions.txx;
using Household.Controllers;
using Household.Data.Db;
using Household.Models.Finance;
using NUnit.Framework;

namespace Household.Test.Controllers
{
	[TestFixture]
	public class CTestFinance : CTestBaseController<FinanceController>
	{
		public CTestFinance()
		{
			Controller = new FinanceController(new CShopManagement(new CDbDefault()));
		}

		[Test]
		public void Finance()
		{
			BaseTestActionResult(x => x.Finance());
		}

		[Test]
		public void Expenses()
		{
			BaseTestPartialViewResult(x => x.Expenses());
		}

		[Test]
		public void MasterData()
		{
			BaseTestPartialViewResult(x => x.MasterData());
		}

		[Test]
		public void Purchases()
		{
			BaseTestPartialViewResult(x => x.Purchases());
		}

		[Test]
		public void Reports()
		{
			BaseTestPartialViewResult(x => x.Reports());
		}

		[Test]
		public void ReportsModel()
		{
			Assert.That(Controller.Reports().Model.GetType(), Is.EqualTo(typeof(CReportsModel)));
		}

		[Test]
		public void ReportsShopsFilled()
		{
			Assert.That((Controller.Reports().Model as CReportsModel).Shops, Is.Not.Null);
		}
	}
}
