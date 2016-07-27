using Household.BL.DATA.txx;
using Household.Controllers;
using Household.Data.Context;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestDayController : CTestBaseController<DayController>
	{
		[Test]
		public void Delete()
		{
			var cDayTest = new Test.MasterData.CTestDay();
			txx_Day xxDay;

			cDayTest.NewDay();

			xxDay = cDayTest.getTestEntity();

			Assert.That(new DayController().Delete(xxDay.ID), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var cDayTest = new Test.MasterData.CTestDay();
			CReturn rResult;

			cDayTest.RemoveTestEntity();

			rResult = JSON.deserialiseObject<CReturn>(new DayController().Save(new CDayData()
			{
				Day = cDayTest.TestDay
			}));

			cDayTest.RemoveTestEntity();

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
