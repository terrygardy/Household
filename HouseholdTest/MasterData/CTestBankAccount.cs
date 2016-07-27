using Helpers.Exceptions;
using Household.BL.DATA.txx;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MasterData
{
	[TestFixture]
	public class CTestBankAccount
	{
		public string TestAccountName { get { return "NewBankAccountForTest"; } }
		public string TestIBAN { get { return "1234567890123456789012"; } }
		public string TestBIC { get { return "12345678901"; } }
		public string TestBank { get { return "Household"; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadBankAccount();
			NewBankAccount();
			EditBankAccount();
			DeleteBankAccount();

			Assert.That(0, Is.EqualTo(0));
		}

		public void RemoveTestEntity()
		{
			var toBankAccount = getTestObject();
			var xxBankAccount = getTestEntity(toBankAccount, false);

			if (xxBankAccount != null) DeleteBankAccount();
		}

		public void BadBankAccount()
		{
			BadAccountName();
			BadIBAN();
			BadBIC();
		}

		public void BadAccountName()
		{
			var toBankAccount = getTestObject();

			try
			{
				toBankAccount.save(new CBankAccountData() { AccountName = " ", IBAN = TestIBAN, BIC = TestBIC });

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

		public void BadIBAN()
		{
			var toBankAccount = getTestObject();

			try
			{
				toBankAccount.save(new CBankAccountData() { AccountName = TestAccountName, IBAN = TestIBAN.Substring(0, TestIBAN.Length - 1), BIC = TestBIC });

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

		public void BadBIC()
		{
			var toBankAccount = getTestObject();

			try
			{
				toBankAccount.save(new CBankAccountData() { AccountName = TestAccountName, IBAN = TestIBAN, BIC = TestBIC.Substring(0, TestBIC.Length - 1) });

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

		public void NewBankAccount()
		{
			var toBankAccount = getTestObject();

			try
			{
				var lngResult = toBankAccount.save(new CBankAccountData() { AccountName = TestAccountName, IBAN = TestIBAN, BIC = TestBIC });

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestIBAN, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestIBAN, ex.Message));
			}
		}

		public void EditBankAccount()
		{
			var toBankAccount = getTestObject();

			try
			{
				var cBankAccount = getTestEntity(toBankAccount);
				long lngResult;

				cBankAccount.BankName = TestBank;

				lngResult = toBankAccount.save(cBankAccount);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestIBAN, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestIBAN, ex.Message));
			}
		}

		public void DeleteBankAccount()
		{
			var toBankAccount = getTestObject();

			try
			{
				var cBankAccount = getTestEntity(toBankAccount);
				long lngResult;

				lngResult = toBankAccount.delete(cBankAccount);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestIBAN, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestIBAN, ex.Message));
			}
		}

		public CBankAccount getTestObject()
		{
			try
			{
				return new CBankAccount(Models.Db.CDbContext.getInstance());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public txx_BankAccount getTestEntity() { return getTestEntity(getTestObject()); }

		public txx_BankAccount getTestEntity(bool pv_blnWithAssert) { return getTestEntity(getTestObject(), pv_blnWithAssert); }

		public txx_BankAccount getTestEntity(CBankAccount pv_toBankAccount) { return getTestEntity(pv_toBankAccount, true); }

		public txx_BankAccount getTestEntity(CBankAccount pv_toBankAccount, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toBankAccount.getEntities(x => x.AccountName == TestAccountName,
													x => x.IBAN, x => x.IBAN)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestIBAN, ex.Message));
			}

			return null;
		}
	}
}