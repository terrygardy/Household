using Helpers.Exceptions;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Base;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MainObjects
{
	[TestFixture]
	public class CTestExpense : ITestBase<t_Expense>
	{
		private txx_Interval m_xxInterval;
		private txx_Day m_xxDay;
		private txx_BankAccount m_xxBankAccount;
		private txx_Company m_xxCompany;

		public DateTime TestStartDate { get { return new DateTime(1900, 1, 1); } }
		public DateTime TestEndDate { get { return TestStartDate.AddDays(2); } }
		public decimal TestAmount { get { return 1000000; } }
		public txx_Interval TestInterval { get { return m_xxInterval; } }
		public txx_Day TestPaymentDay { get { return m_xxDay; } }
		public txx_BankAccount TestBankAccount { get { return m_xxBankAccount; } }
		public txx_Company TestCompany { get { return m_xxCompany; } }

		public CTestExpense()
		{
			m_xxInterval = new CIntervalManagement().getIntervals()[0];
			m_xxDay = new CDayManagement().getDays()[0];
			m_xxBankAccount = new CBankAccountManagement().getBankAccounts()[0];
			m_xxCompany = new CCompanyManagement().getCompanies()[0];
		}

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadExpense();
			NewExpense();
			EditExpense();
			DeleteExpense();		
		}

		public void RemoveTestEntity()
		{
			var toExpense = getTestObject();
			var xxExpense = GetTestEntity(toExpense, false);

			if (xxExpense != null) DeleteExpense();
		}

		public void BadExpense()
		{
			BadStartDate();
			BadEndDate();
			BadAmount();
			BadBankAccount();
			BadCompany();
			BadInterval();
			BadPaymentDay();
		}

		public void BadStartDate()
		{
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = new DateTime(1753, 1, 1),
					Amount = TestAmount,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = TestPaymentDay.ID
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
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					EndDate = TestStartDate.AddDays(-2),
					Amount = TestAmount,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = TestPaymentDay.ID
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
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					Amount = 0,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = TestPaymentDay.ID
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

		public void BadBankAccount()
		{
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					BankAccount_ID = 0,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = TestPaymentDay.ID
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
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = 0,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = TestPaymentDay.ID
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
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = 0,
					PaymentDay_ID = TestPaymentDay.ID
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

		public void BadPaymentDay()
		{
			var toExpense = getTestObject();

			try
			{
				toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					Amount = TestAmount,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = 0
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

		public void NewExpense()
		{
			var toExpense = getTestObject();

			try
			{
				var lngResult = toExpense.save(new t_Expense()
				{
					StartDate = TestStartDate,
					EndDate = TestEndDate,
					Amount = TestAmount,
					BankAccount_ID = TestBankAccount.ID,
					Company_ID = TestCompany.ID,
					Interval_ID = TestInterval.ID,
					PaymentDay_ID = TestPaymentDay.ID,
					Description = "Test"
				});

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestStartDate.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestStartDate.ToShortDateString(), ex.Message));
			}
		}

		public void EditExpense()
		{
			var toExpense = getTestObject();

			try
			{
				var cExpense = GetTestEntity(toExpense);
				long lngResult;

				cExpense.Description = TextBase.TestDescription;

				lngResult = toExpense.save(cExpense);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestStartDate.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestStartDate.ToShortDateString(), ex.Message));
			}
		}

		public void DeleteExpense()
		{
			var toExpense = getTestObject();

			try
			{
				var cExpense = GetTestEntity(toExpense);
				long lngResult;

				lngResult = toExpense.delete(cExpense);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestStartDate.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestStartDate.ToShortDateString(), ex.Message));
			}
		}

		private CExpenseManagement getTestObject()
		{
			try
			{
				return new CExpenseManagement();
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public t_Expense GetTestEntity(bool withAssert) { return GetTestEntity(getTestObject(), withAssert); }

		public t_Expense GetTestEntity(CExpenseManagement pv_toExpense) { return GetTestEntity(pv_toExpense, true); }

		public t_Expense GetTestEntity(CExpenseManagement pv_toExpense, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toExpense.getEntities(x => x.StartDate == TestStartDate && x.EndDate == TestEndDate && x.Amount == TestAmount
													&& x.BankAccount_ID == TestBankAccount.ID && x.Company_ID == TestCompany.ID
													&& x.Interval_ID == TestInterval.ID && x.PaymentDay_ID == TestPaymentDay.ID,
												x => x.StartDate, x => x.StartDate)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestStartDate.ToShortDateString(), ex.Message));
			}

			return null;
		}
	}
}