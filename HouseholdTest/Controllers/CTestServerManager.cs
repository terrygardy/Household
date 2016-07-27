using Household.Controllers;
using NUnit.Framework;

namespace Household.Test.Controllers
{
	[TestFixture]
	public class CTestServerManager : CTestBaseController<ServerManagerController>
	{
		[Test]
		public void ServerManager()
		{
			BaseTestActionResult(x => x.ServerManager());
		}
	}
}
