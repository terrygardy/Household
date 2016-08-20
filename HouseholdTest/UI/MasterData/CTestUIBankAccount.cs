using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIBankAccount : CTestUIMasterData<txx_BankAccount, CTestBankAccount>
	{
		public CTestUIBankAccount() : base("bankAccounts")
		{ }

		public override void LoadTestData()
		{
			SendTextToElement("tbxAccountName", TestObj.TestAccountName);
			SendTextToElement("tbxIBAN", TestObj.TestIBAN);
			SendTextToElement("tbxBIC", TestObj.TestBIC);
			SendTextToElement("tbxBankName", TestObj.TestBank);
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxBankName", "Test umlauts ÜÄÖüäö");
		}
	}
}