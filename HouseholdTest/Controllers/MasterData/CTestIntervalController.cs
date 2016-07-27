using Household.BL.DATA.txx;
using Household.Controllers;
using Household.Data.Context;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestIntervalController : CTestBaseController<IntervalController>
	{
		[Test]
		public void Delete()
		{
			var cIntervalTest = new Test.MasterData.CTestInterval();
			txx_Interval xxInterval;

			cIntervalTest.NewInterval();

			xxInterval = cIntervalTest.getTestEntity();

			Assert.That(new IntervalController().Delete(xxInterval.ID), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var cIntervalTest = new Test.MasterData.CTestInterval();
			CReturn rResult;

			cIntervalTest.RemoveTestEntity();

			rResult = JSON.deserialiseObject<CReturn>(new IntervalController().Save(new CIntervalData()
			{
				Name = cIntervalTest.TestName
			}));

			cIntervalTest.RemoveTestEntity();

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
