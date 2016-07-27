using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIDay : CTestUIMasterData<txx_Day>
	{
		private CTestDay TestObj { get; set; }

		public CTestUIDay(): base("days")
		{
			TestObj = new CTestDay();
		}
		
		public override void LoadTestData()
		{
			SendTextToElement("tbxDay", TestObj.TestDay.ToString());
		}

		public override txx_Day GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		public override void LoadEditData()
		{
			SendTextToElement("tbxDay", TestObj.TestDayEdit.ToString());
		}
	}
}