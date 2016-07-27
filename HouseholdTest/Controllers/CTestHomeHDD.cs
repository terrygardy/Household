using NUnit.Framework;
using Household.Controllers;

namespace Household.Test.Controllers
{
	[TestFixture]
	public class CTestHomeHDD : CTestBaseController<HomeHDDController>
	{
		[Test]
		public void HomeHDD()
		{
			BaseTestActionResult(x => x.HomeHDD());
		}
	}
}
