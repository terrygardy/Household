using Household.BL.DATA.txx;
using Household.BL.Functions.Management.txx;
using Household.Controllers;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestDayController : CTestBaseController<DayController>
	{
		public CTestDayController()
		{
			Controller = new DayController(CreateSubstitute<IDayManagement>());
		}

		[Test]
		public void Delete()
		{
			Assert.That(Controller.Delete(0), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var rResult = JSON.deserialiseObject<CReturn>(Controller.Save(new CDayData { Day = CreateFixture<int>() }));

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}