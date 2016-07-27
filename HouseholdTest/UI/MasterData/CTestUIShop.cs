using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIShop : CTestUIMasterData<txx_Shop>
	{
		private CTestShop TestObj { get; set; }

		public CTestUIShop(): base("shops")
		{
			TestObj = new CTestShop();
		}

		public override void LoadTestData()
		{
			SendTextToElement("tbxName", TestObj.TestName);
			SendTextToElement("tbxDescription", TestObj.TestDescription);
		}

		public override txx_Shop GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		public override void LoadEditData()
		{
			SendTextToElement("tbxDescription", "Test umlauts ÜÄÖüäö");
		}
	}
}