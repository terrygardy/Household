using Household.Data.Context;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.UI.MainObjects
{
	[TestFixture]
	public class CTestUIPurchase : CTestUIFinance<t_Purchase>
	{
		private CTestPurchase TestObj { get; set; }

		public CTestUIPurchase() : base("purchases")
		{
			TestObj = new CTestPurchase();
		}

		public override void LoadTestData()
		{
			SendTextToElement("tbxDate", TestObj.TestOccurrence.ToShortDateString());
			SendTextToElement("tbxAmount", TestObj.TestAmount.ToString());
			SendTextToElement("tbxDescription", TestObj.TestDescription);
			SelectOptionDropDownList("cboBankAccount", TestObj.TestPayer.ID.ToString());
			SelectOptionDropDownList("cboShop", TestObj.TestShop.ID.ToString());
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxDescription", "Test umlauts ÜÄÖüäö");
		}

		public override t_Purchase GetTestEntity() { return TestObj.getTestEntity(false); }

		public override long GetTestId() { return GetTestEntity().ID; }

		public override void RemoveTestEntity() { TestObj.RemoveTestEntity(); }
	}
}
