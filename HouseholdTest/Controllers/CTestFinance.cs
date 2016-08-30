using Household.Controllers;
using Household.Models.Finance;
using NUnit.Framework;

namespace Household.Test.Controllers
{
	[TestFixture]
	public class CTestFinance : CTestBaseController<FinanceController>
	{
		public CTestFinance()
		{
			Controller = new FinanceController();
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
			Assert.That(new FinanceController().Reports().Model.GetType(), Is.EqualTo(typeof(CReportsModel)));
		}

		[Test]
		public void ReportsShopsFilled()
		{
			Assert.That((new FinanceController().Reports().Model as CReportsModel).Shops, Is.Not.Null);
		}
	}
}
