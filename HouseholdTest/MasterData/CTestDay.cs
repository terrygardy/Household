using Helpers.Exceptions;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Data.Db;
using Household.Test.Base;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Household.Test.MasterData
{
	[TestFixture]
	public class CTestDay : ITestBase<txx_Day>
	{
		public int TestDay { get { return 6; } }
		public int TestDayEdit { get { return 7; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadDay();
			NewDay();
			EditDay();
			DeleteDay();
		}

		public void RemoveTestEntity()
		{
			var xxDay = GetTestEntity(getTestObject(), false);

			if (xxDay != null) DeleteDay();

			xxDay = GetTestEntity(getTestObject(), false, TestDayEdit);

			if (xxDay != null) DeleteDay(TestDayEdit);
		}

		public void BadDay()
		{
			var toDay = getTestObject();

			try
			{
				toDay.save(new txx_Day() { Day = 0 });

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

		public void NewDay()
		{
			var toDay = getTestObject();

			try
			{
				var lngResult = toDay.save(new txx_Day() { Day = TestDay });

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestDay.ToString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestDay.ToString(), ex.Message));
			}
		}

		public void EditDay()
		{
			var toDay = getTestObject();
			var xxDay = GetTestEntity(toDay);

			try
			{
				long lngResult;

				xxDay.Day = TestDayEdit;

				lngResult = toDay.save(xxDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestDayEdit.ToString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestDayEdit.ToString(), ex.Message));
			}

			try
			{
				long lngResult;

				xxDay.Day = TestDay;

				lngResult = toDay.save(xxDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestDay.ToString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestDay.ToString(), ex.Message));
			}
		}

		public void DeleteDay() { DeleteDay(TestDay); }

		public void DeleteDay(int pv_intDay)
		{
			var toDay = getTestObject();

			try
			{
				var cDay = GetTestEntity(toDay, true, pv_intDay);
				long lngResult;

				lngResult = toDay.delete(cDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(pv_intDay.ToString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(pv_intDay.ToString(), ex.Message));
			}
		}

		private CDayManagement getTestObject()
		{
			try
			{
				return new CDayManagement(new CDbDefault());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public txx_Day GetTestEntity() { return GetTestEntity(getTestObject()); }

		public txx_Day GetTestEntity(bool pv_blnWithAssert) { return GetTestEntity(getTestObject(), pv_blnWithAssert); }

		public txx_Day GetTestEntity(CDayManagement pv_toDay) { return GetTestEntity(pv_toDay, true, TestDay); }

		public txx_Day GetTestEntity(CDayManagement pv_toDay, bool pv_blnWithAssert) { return GetTestEntity(pv_toDay, pv_blnWithAssert, TestDay); }

		public txx_Day GetTestEntity(CDayManagement pv_toDay, bool pv_blnWithAssert, int pv_intDay)
		{
			try
			{
				return pv_toDay.getEntities(x => x.Day == pv_intDay, x => x.Day, x => x.Day).FirstOrDefault();
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestDay.ToString(), ex.Message));
			}

			return null;
		}
	}
}