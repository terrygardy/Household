using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Models.Search;
using Household.Models.Work;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.Search.MainObjects
{
	[TestFixture]
	public class CTestSearchWorkDay
	{
		[Test]
		public void Search()
		{
			var cTest = new CTestWorkDay();
			t_WorkDay tWorkDay;

			try
			{
				var cSearch = new CSearchWorkDay();
				CWorkHoursModel cModel;
				int intRows;

				cTest.RemoveTestEntity();
				cTest.NewWorkDay();
				tWorkDay = cTest.GetTestEntity();

				cSearch.WorkDayFrom = tWorkDay.WorkDay;
				cSearch.WorkDayTo = tWorkDay.WorkDay;
				cSearch.Begin = tWorkDay.Begin;
				cSearch.End = tWorkDay.End;
				cSearch.BreakDuration = tWorkDay.BreakDuration;

				cModel = new CWorkHoursModel();
				intRows = cModel.Search(cSearch, "WorkDay", "Work").Body.Count;

				Assert.That(intRows == 1);
			}
			finally
			{
				cTest.RemoveTestEntity();
				tWorkDay = null;
			}
		}

		[Test]
		public void EmptySearch()
		{
			int intRowsExpected = new CWorkDayManagement().getWorkingDays().Count;
			int intRowsFound = new CWorkHoursModel().Search(new CSearchWorkDay(), "WorkDay", "Work").Body.Count;

			Assert.That(intRowsExpected == intRowsFound);
		}
	}
}
