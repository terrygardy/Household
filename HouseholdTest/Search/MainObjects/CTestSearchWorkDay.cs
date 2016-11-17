using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Data.Db;
using Household.Models.Search;
using Household.Models.Work;
using Household.Test.MainObjects;
using NUnit.Framework;
using System.Linq;

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

				cModel = new CWorkHoursModel(new CWorkDayManagement(new CDbDefault()));
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
			var workDayManagement = new CWorkDayManagement(new CDbDefault());
			int intRowsExpected = workDayManagement.getWorkingDays().Count();
			int intRowsFound = new CWorkHoursModel(workDayManagement).Search(new CSearchWorkDay(), "WorkDay", "Work").Body.Count;

			Assert.That(intRowsExpected == intRowsFound);
		}
	}
}