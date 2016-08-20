using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIInterval : CTestUIMasterData<txx_Interval, CTestInterval>
	{
		public CTestUIInterval() : base("intervals")
		{ }

		public override void LoadTestData()
		{
			SendTextToElement("tbxName", TestObj.TestName);
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxName", "Test umlauts ÜÄÖüäö");
		}
	}
}
