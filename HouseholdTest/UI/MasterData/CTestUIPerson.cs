using Household.Data.Context;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIPerson : CTestUIMasterData<t_Person>
	{
		private CTestPerson TestObj { get; set; }

		public CTestUIPerson() : base("people")
		{
			TestObj = new CTestPerson();
		}

		public override void LoadTestData()
		{
			SendTextToElement("tbxSurname", TestObj.TestName);
			SendTextToElement("tbxForename", TestObj.TestForename);
		}

		public override t_Person GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		public override void LoadEditData()
		{
			SendTextToElement("tbxForename", "Test umlauts ÜÄÖüäö");
		}
	}
}
