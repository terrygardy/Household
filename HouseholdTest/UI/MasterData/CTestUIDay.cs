using Household.Data.Context;
using Household.Test.MasterData;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIDay : CTestUIMasterData<txx_Day, CTestDay>
	{
		public CTestUIDay(): base("days")
		{ }
		
		public override void LoadTestData()
		{
			SendTextToElement("tbxDay", TestObj.TestDay.ToString());
		}
		
		public override void LoadEditData()
		{
			SendTextToElement("tbxDay", TestObj.TestDayEdit.ToString());
		}
	}
}