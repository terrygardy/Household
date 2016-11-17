using Household.BL.Functions.txx;
using Household.Controllers;
using Household.Data.Db;
using NUnit.Framework;

namespace Household.Test.Controllers
{
	[TestFixture]
	public class CTestHome : CTestBaseController<HomeController>
	{
		public CTestHome()
		{
			Controller = new HomeController(new CShopManagement(new CDbDefault()));
		}

		[Test]
		public void Index()
		{
			BaseTestActionResult(x => x.Index());
		}
	}
}