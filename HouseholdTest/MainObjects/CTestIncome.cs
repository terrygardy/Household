using Helpers.Exceptions;
using Household.BL.Management.t.Implementations;
using Household.BL.Management.txx.Implementations;
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
	public class CTestIncome : ITestBase<t_Income>
	{
		private txx_Interval m_xxInterval;
		private txx_Day m_xxDay;
		private txx_BankAccount m_xxPayee;
		private txx_Company m_xxCompany;

		public DateTime TestStartDate { get { return new DateTime(1900, 1, 1); } }
		public DateTime TestEndDate { get { return TestStartDate.AddDays(2); } }
		public decimal TestAmount { get { return 567; } }
		public string TestDescription { get { return TextBase.TestDescription; } }
		public txx_Interval TestInterval { get { return m_xxInterval; } }
		public txx_Day TestDay { get { return m_xxDay; } }
		public txx_BankAccount TestPayee { get { return m_xxPayee; } }
		public txx_Company TestCompany { get { return m_xxCompany; } }
		private readonly IDb _db;

		public CTestIncome()
		{
			_db = new CDbDefault();
			m_xxInterval = new CIntervalManagement(_db).getIntervals().FirstOrDefault();
			m_xxDay = new CDayManagement(_db).getDays().FirstOrDefault();
			m_xxPayee = new CBankAccountManagement(_db).getBankAccounts().FirstOrDefault();
			m_xxCompany = new CCompanyManagement(_db).getCompanies().FirstOrDefault();
		}

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadIncome();
			NewIncome();
			EditIncome();
			DeleteIncome();


		}

		public void RemoveTestEntity()
		{
			var toIncome = getTestObject();
			var xxIncome = GetTestEntity(toIncome, false);

			if (xxIncome != null) DeleteIncome();
		}

		public void BadIncome()
		{
			BadStartDate();
			BadEndDate();
			BadAmount();
			BadPayee();
			BadCompany();
			BadInterval();
			BadDay();
		}

		public void BadStartDate()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = new DateTime(1753, 1, 1),
					Amount = TestAmount,
					Payee_ID = TestPayee.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					Day_ID = TestDay.ID
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

		public void BadEndDate()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					EndDate = TestStartDate.AddDays(-2),
					Amount = TestAmount,
					Payee_ID = TestPayee.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					Day_ID = TestDay.ID
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

		public void BadAmount()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					Amount = 0,
					Payee_ID = TestPayee.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					Day_ID = TestDay.ID
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

		public void BadPayee()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					Payee_ID = 0,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					Day_ID = TestDay.ID
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

		public void BadCompany()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					Payee_ID = TestPayee.ID,
					Company_ID = 0,
					Interval_ID = TestInterval.ID,
					Day_ID = TestDay.ID
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

		public void BadInterval()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					Payee_ID = TestPayee.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = 0,
					Day_ID = TestDay.ID
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

		public void BadDay()
		{
			var toIncome = getTestObject();

			try
			{
				toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					Payee_ID = TestPayee.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					Day_ID = 0
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

		public void NewIncome()
		{
			var toIncome = getTestObject();

			try
			{
				var lngResult = toIncome.save(new t_Income()
				{
					StartDate = TestStartDate,
					EndDate = TestEndDate,
					Amount = TestAmount,
					Payee_ID = TestPayee.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					Day_ID = TestDay.ID
				});

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(MethodBase.GetCurrentMethod().Name + "- " + TestStartDate.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(MethodBase.GetCurrentMethod().Name + "- " + TestStartDate.ToShortDateString(), ex.Message));
			}
		}

		public void EditIncome()
		{
			var toIncome = getTestObject();

			try
			{
				var cIncome = GetTestEntity(toIncome);
				long lngResult;

				cIncome.Description = TestDescription;

				lngResult = toIncome.save(cIncome);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestStartDate.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestStartDate.ToShortDateString(), ex.Message));
			}
		}

		public void DeleteIncome()
		{
			var toIncome = getTestObject();

			try
			{
				var cIncome = GetTestEntity(toIncome);
				long lngResult;

				lngResult = toIncome.delete(cIncome);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestStartDate.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestStartDate.ToShortDateString(), ex.Message));
			}
		}

		private CIncomeManagement getTestObject()
		{
			try
			{
				return new CIncomeManagement(_db);
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public t_Income GetTestEntity(CIncomeManagement pv_toIncome) { return GetTestEntity(pv_toIncome, true); }

		public t_Income GetTestEntity() { return GetTestEntity(getTestObject(), true); }

		public t_Income GetTestEntity(bool pv_blnWithAssert) { return GetTestEntity(getTestObject(), pv_blnWithAssert); }

		public t_Income GetTestEntity(CIncomeManagement pv_toIncome, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toIncome.getEntities(x => x.StartDate == TestStartDate && x.EndDate == TestEndDate && x.Amount == TestAmount
													&& x.Payee_ID == TestPayee.ID && x.Company_ID == TestCompany.ID
													&& x.Interval_ID == TestInterval.ID && x.Day_ID == TestDay.ID,
												x => x.StartDate, x => x.StartDate).FirstOrDefault();
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestStartDate.ToShortDateString(), ex.Message));
			}

			return null;
		}
	}
}