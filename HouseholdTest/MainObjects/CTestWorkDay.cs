using Helpers.Exceptions;
using Household.BL.Management.t.Implementations;
using Household.Data.Context;
using Household.Data.Db;
using Household.Test.Base;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Household.Test.MainObjects
{
	[TestFixture]
	public class CTestWorkDay : ITestBase<t_WorkDay>
	{
		public DateTime TestWorkDay { get { return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); } }
		public TimeSpan TestBegin { get { return new TimeSpan(8, 0, 0); } }
		public TimeSpan TestEnd { get { return new TimeSpan(17, 0, 0); } }
		public int TestBreakDuration { get { return 1; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadWorkDay();
			NewWorkDay();
			EditWorkDay();
			DeleteWorkDay();
		}

		public void RemoveTestEntity()
		{
			var toWorkDay = getTestObject();
			var xxWorkDay = GetTestEntity(toWorkDay, false);

			if (xxWorkDay != null) DeleteWorkDay();
		}

		public void BadWorkDay()
		{
			BadDay();
			BadBegin();
			BadEnd();
			BadBreak();
		}

		public void BadDay()
		{
			var toWorkDay = getTestObject();

			try
			{
				toWorkDay.save(new t_WorkDay()
				{
					WorkDay = new DateTime(1753, 1, 1),
					Begin = TestBegin,
					End = TestEnd,
					BreakDuration = TestBreakDuration
				});

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

		public void BadBegin()
		{
			var toWorkDay = getTestObject();

			try
			{
				toWorkDay.save(new t_WorkDay()
				{
					WorkDay = TestWorkDay,
					Begin = new TimeSpan(0, 0, 0),
					End = TestEnd,
					BreakDuration = TestBreakDuration
				});

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

		public void BadEnd()
		{
			var toWorkDay = getTestObject();

			try
			{
				toWorkDay.save(new t_WorkDay()
				{
					WorkDay = TestWorkDay,
					Begin = TestBegin,
					End = new TimeSpan(0, 0, 0),
					BreakDuration = TestBreakDuration
				});

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

		public void BadBreak()
		{
			var toWorkDay = getTestObject();

			try
			{
				toWorkDay.save(new t_WorkDay()
				{
					WorkDay = TestWorkDay,
					Begin = TestBegin,
					End = TestEnd,
					BreakDuration = -1
				});

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

		public void NewWorkDay()
		{
			var toWorkDay = getTestObject();

			try
			{
				var lngResult = toWorkDay.save(new t_WorkDay()
				{
					WorkDay = TestWorkDay,
					Begin = TestBegin,
					End = TestEnd,
					BreakDuration = TestBreakDuration
				});

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestWorkDay.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestWorkDay.ToShortDateString(), ex.Message));
			}
		}

		public void EditWorkDay()
		{
			var toWorkDay = getTestObject();

			try
			{
				var cWorkDay = GetTestEntity(toWorkDay);
				long lngResult;

				cWorkDay.BreakDuration = 2;

				lngResult = toWorkDay.save(cWorkDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestWorkDay.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestWorkDay.ToShortDateString(), ex.Message));
			}
		}

		public void DeleteWorkDay()
		{
			var toWorkDay = getTestObject();

			try
			{
				var cWorkDay = GetTestEntity(toWorkDay);
				long lngResult;

				lngResult = toWorkDay.delete(cWorkDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestWorkDay.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestWorkDay.ToShortDateString(), ex.Message));
			}
		}

		private CWorkDayManagement getTestObject()
		{
			try
			{
				return new CWorkDayManagement(new CDbDefault());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public t_WorkDay GetTestEntity() { return GetTestEntity(getTestObject(), true); }

		public t_WorkDay GetTestEntity(bool pv_blnWithAsserts) { return GetTestEntity(getTestObject(), pv_blnWithAsserts); }

		public t_WorkDay GetTestEntity(CWorkDayManagement pv_toWorkDay) { return GetTestEntity(pv_toWorkDay, true); }

		public t_WorkDay GetTestEntity(CWorkDayManagement pv_toWorkDay, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toWorkDay.getWorkingDays(x => x.WorkDay == TestWorkDay && x.Begin == TestBegin
													&& x.End == TestEnd).FirstOrDefault();
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestWorkDay.ToShortDateString(), ex.Message));
			}

			return null;
		}
	}
}