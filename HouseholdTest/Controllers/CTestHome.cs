using Household.Controllers;
using NUnit.Framework;

namespace Household.Test.Controllers
{
	[TestFixture]
	public class CTestHome : CTestBaseController<HomeController>
	{
		[Test]
		public void Index()
		{
			BaseTestActionResult(x => x.Index());
		}
	}
}
