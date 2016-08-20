using Household.Data.Context;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.UI.MainObjects
{
	[TestFixture]
	public class CTestUIWorkDay : CTestUIWork<t_WorkDay, CTestWorkDay>
	{
		public CTestUIWorkDay() : base("workHours")
		{ }

		public override void LoadTestData()
		{
			SendTextToElement("tbxWorkDay", TestObj.TestWorkDay.ToShortDateString());
			SendTextToElement("tbxBegin", $"{TestObj.TestBegin.Hours:00}:{TestObj.TestBegin.Minutes:00}");
			SendTextToElement("tbxEnd", $"{TestObj.TestEnd.Hours:00}:{TestObj.TestEnd.Minutes:00}");
			SendTextToElement("tbxBreakDuration", TestObj.TestBreakDuration.ToString());
		}

		public override void LoadEditData()
		{
			SendTextToElement("tbxBreakDuration", "2");
		}
	}
}
