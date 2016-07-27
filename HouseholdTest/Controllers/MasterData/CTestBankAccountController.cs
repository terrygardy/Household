using Household.BL.DATA.txx;
using Household.Controllers;
using Household.Data.Context;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestBankAccountController : CTestBaseController<BankAccountController>
	{
		[Test]
		public void Delete()
		{
			var cBankTest = new Test.MasterData.CTestBankAccount();
			txx_BankAccount xxBankAccount;

			cBankTest.NewBankAccount();

			xxBankAccount = cBankTest.getTestEntity();

			Assert.That(new BankAccountController().Delete(xxBankAccount.ID), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var cBankTest = new Test.MasterData.CTestBankAccount();
			CReturn rResult;

			cBankTest.RemoveTestEntity();

			rResult = JSON.deserialiseObject<CReturn>(new BankAccountController().Save(new CBankAccountData()
			{
				AccountName = cBankTest.TestAccountName,
				IBAN = cBankTest.TestIBAN,
				BIC = cBankTest.TestBIC
			}));

			cBankTest.RemoveTestEntity();

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
