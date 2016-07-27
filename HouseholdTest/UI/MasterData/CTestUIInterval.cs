using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIInterval : CTestUIMasterData<txx_Interval>
	{
		private CTestInterval TestObj { get; set; }

		public CTestUIInterval() : base("intervals")
		{
			TestObj = new CTestInterval();
		}
		
		public override void LoadTestData()
		{
			SendTextToElement("tbxName", TestObj.TestName);
		}

		public override txx_Interval GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		public override void LoadEditData()
		{
			SendTextToElement("tbxName", "Test umlauts ÜÄÖüäö");
		}
	}
}
