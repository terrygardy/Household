using Helpers.Exceptions;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MasterData
{
	[TestFixture]
	public class CTestDay
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

			Assert.That(0, Is.EqualTo(0));
		}

		public void RemoveTestEntity()
		{
			var xxDay = getTestEntity(getTestObject(), false);

			if (xxDay != null) DeleteDay();

			xxDay = getTestEntity(getTestObject(), false, TestDayEdit);

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
			var xxDay = getTestEntity(toDay);

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
				var cDay = getTestEntity(toDay, true, pv_intDay);
				long lngResult;

				lngResult = toDay.delete(cDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(pv_intDay.ToString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(pv_intDay.ToString(), ex.Message));
			}
		}

		private CDay getTestObject()
		{
			try
			{
				return new CDay(Models.Db.CDbContext.getInstance());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public txx_Day getTestEntity() { return getTestEntity(getTestObject()); }

		public txx_Day getTestEntity(bool pv_blnWithAssert) { return getTestEntity(getTestObject(), pv_blnWithAssert); }

		public txx_Day getTestEntity(CDay pv_toDay) { return getTestEntity(pv_toDay, true, TestDay); }

		public txx_Day getTestEntity(CDay pv_toDay, bool pv_blnWithAssert) { return getTestEntity(pv_toDay, pv_blnWithAssert, TestDay); }

		public txx_Day getTestEntity(CDay pv_toDay, bool pv_blnWithAssert, int pv_intDay)
		{
			try
			{
				return pv_toDay.getEntities(x => x.Day == pv_intDay, x => x.Day, x => x.Day)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestDay.ToString(), ex.Message));
			}

			return null;
		}
	}
}