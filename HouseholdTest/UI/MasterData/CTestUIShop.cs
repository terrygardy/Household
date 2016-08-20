using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIShop : CTestUIMasterData<txx_Shop, CTestShop>
	{
		public CTestUIShop() : base("shops")
		{ }

		public override void LoadTestData()
		{
			SendTextToElement("tbxName", TestObj.TestName);
			SendTextToElement("tbxDescription", TestObj.TestDescription);
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxDescription", "Test umlauts ÜÄÖüäö");
		}
	}
}