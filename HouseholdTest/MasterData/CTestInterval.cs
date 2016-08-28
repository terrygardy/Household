using Helpers.Exceptions;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Base;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MasterData
{
	[TestFixture]
	public class CTestInterval : ITestBase<txx_Interval>
	{
		public string TestName { get { return "NewIntervalForTest"; } }
		public string TestDescription { get { return TextBase.TestDescription; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadInterval();
			NewInterval();
			EditInterval();
			DeleteInterval();
		}

		public void RemoveTestEntity()
		{
			var toInterval = getTestObject();
			var xxInterval = GetTestEntity(toInterval, false);

			if (xxInterval != null) DeleteInterval();
		}

		public void BadInterval()
		{
			var toInterval = getTestObject();

			try
			{
				toInterval.save(new txx_Interval() { Name = " " });

				Assert.Fail();
			}
			catch (Exception ex)
			{
				if (typeof(ValidationException) != ex.GetType())
				{
					Assert.Fail(TextBase.getErrorSave(MethodBase.GetCurrentMethod().Name, ex.Message));
				}
			}
		}

		public void NewInterval()
		{
			var toInterval = getTestObject();

			try
			{
				var lngResult = toInterval.save(new txx_Interval() { Name = TestName });

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestName, ex.Message));
			}
		}

		public void EditInterval()
		{
			var toInterval = getTestObject();

			try
			{
				var cInterval = GetTestEntity(toInterval);
				long lngResult;

				cInterval.Name = TestDescription;

				lngResult = toInterval.save(cInterval);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestName, TextBase.ErrorUnknown));

				cInterval.Name = TestName;

				lngResult = toInterval.save(cInterval);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestName, ex.Message));
			}
		}

		public void DeleteInterval()
		{
			var toInterval = getTestObject();

			try
			{
				var cInterval = GetTestEntity(toInterval);
				long lngResult;

				lngResult = toInterval.delete(cInterval);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestName, ex.Message));
			}
		}

		public CIntervalManagement getTestObject()
		{
			try
			{
				return new CIntervalManagement();
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public txx_Interval GetTestEntity() { return GetTestEntity(getTestObject()); }

		public txx_Interval GetTestEntity(bool pv_blnWithAssert) { return GetTestEntity(getTestObject(), pv_blnWithAssert); }

		public txx_Interval GetTestEntity(CIntervalManagement pv_toInterval) { return GetTestEntity(pv_toInterval, true); }

		public txx_Interval GetTestEntity(CIntervalManagement pv_toInterval, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toInterval.getEntities(x => x.Name == TestName, x => x.Name, x => x.Name)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestName, ex.Message));
			}

			return null;
		}
	}
}