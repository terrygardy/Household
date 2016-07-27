using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIBankAccount : CTestUIMasterData<txx_BankAccount>
	{
		private CTestBankAccount TestObj { get; set; }

		public CTestUIBankAccount() : base("bankAccounts")
		{
			TestObj = new CTestBankAccount();
		}

		public override void LoadTestData()
		{
			SendTextToElement("tbxAccountName", TestObj.TestAccountName);
			SendTextToElement("tbxIBAN", TestObj.TestIBAN);
			SendTextToElement("tbxBIC", TestObj.TestBIC);
			SendTextToElement("tbxBankName", TestObj.TestBank);
		}

		public override txx_BankAccount GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		public override void LoadEditData()
		{
			SendTextToElement("tbxBankName", "Test umlauts ÜÄÖüäö");
		}
	}
}