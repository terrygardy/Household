using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUICompany : CTestUIMasterData<txx_Company>
	{
		private CTestCompany TestObj { get; set; }

		public CTestUICompany() : base("companies")
		{
			TestObj = new CTestCompany();
		}

		public override void LoadTestData()
		{
			SendTextToElement("tbxName", TestObj.TestName);
			SendTextToElement("tbxDescription", TestObj.TestDescription);
		}

		public override txx_Company GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		public override void LoadEditData()
		{
			SendTextToElement("tbxDescription", "Test umlauts ÜÄÖüäö");
		}
	}
}
