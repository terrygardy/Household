using Household.Data.Context;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIPerson : CTestUIMasterData<t_Person, CTestPerson>
	{
		public CTestUIPerson() : base("people")
		{ }

		public override void LoadTestData()
		{
			SendTextToElement("tbxSurname", TestObj.TestName);
			SendTextToElement("tbxForename", TestObj.TestForename);
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxForename", "Test umlauts ÜÄÖüäö");
		}
	}
}
