using Helpers.Exceptions;
using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MainObjects
{
	[TestFixture]
	public class CTestWorkDay
	{
		public DateTime TestWorkDay { get { return new DateTime(1900, 1, 1); } }
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

			Assert.That(0, Is.EqualTo(0));
		}

		public void RemoveTestEntity()
		{
			var toWorkDay = getTestObject();
			var xxWorkDay = getTestEntity(toWorkDay, false);

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
					Begin = new TimeSpan(0,0,0),
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
				var cWorkDay = getTestEntity(toWorkDay);
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
				var cWorkDay = getTestEntity(toWorkDay);
				long lngResult;

				lngResult = toWorkDay.delete(cWorkDay);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestWorkDay.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestWorkDay.ToShortDateString(), ex.Message));
			}
		}

		private CWorkDay getTestObject()
		{
			try
			{
				return new CWorkDay();
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public t_WorkDay getTestEntity() { return getTestEntity(getTestObject(), true); }

		public t_WorkDay getTestEntity(bool pv_blnWithAsserts) { return getTestEntity(getTestObject(), pv_blnWithAsserts); }

		public t_WorkDay getTestEntity(CWorkDay pv_toWorkDay) { return getTestEntity(pv_toWorkDay, true); }

		public t_WorkDay getTestEntity(CWorkDay pv_toWorkDay, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toWorkDay.getWorkingDays(x => x.WorkDay == TestWorkDay && x.Begin == TestBegin
													&& x.End == TestEnd && x.BreakDuration == TestBreakDuration)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestWorkDay.ToShortDateString(), ex.Message));
			}

			return null;
		}
	}
}