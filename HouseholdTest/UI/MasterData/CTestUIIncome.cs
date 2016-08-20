using Household.Data.Context;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.UI.MasterData
{
	[TestFixture]
	public class CTestUIIncome : CTestUIMasterData<t_Income, CTestIncome>
	{
		public CTestUIIncome() : base("incomes")
		{ }

		public override void LoadTestData()
		{
			SendTextToElement("tbxStart", TestObj.TestStartDate.ToShortDateString());
			SendTextToElement("tbxEnd", TestObj.TestEndDate.ToShortDateString());
			SendTextToElement("tbxAmount", TestObj.TestAmount.ToString());
			SendTextToElement("tbxDescription", TestObj.TestDescription);
			SelectOptionDropDownList("cboBankAccount", TestObj.TestPayee.ID.ToString());
			SelectOptionDropDownList("cboCompany", TestObj.TestCompany.ID.ToString());
			SelectOptionDropDownList("cboDay", TestObj.TestDay.ID.ToString());
			SelectOptionDropDownList("cboInterval", TestObj.TestInterval.ID.ToString());
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxDescription", "Test umlauts ÜÄÖüäö");
		}
	}
}
