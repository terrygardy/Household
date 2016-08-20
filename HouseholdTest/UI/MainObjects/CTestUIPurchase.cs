using Household.Data.Context;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.UI.MainObjects
{
	[TestFixture]
	public class CTestUIPurchase : CTestUIFinance<t_Purchase, CTestPurchase>
	{
		public CTestUIPurchase() : base("purchases")
		{ }

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
	}
}
