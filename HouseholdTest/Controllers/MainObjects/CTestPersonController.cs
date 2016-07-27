using Household.BL.DATA.t;
using Household.Controllers;
using Household.Data.Context;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MainObjects
{
	[TestFixture]
	public class CTestPersonController : CTestBaseController<PersonController>
	{
		[Test]
		public void Delete()
		{
			var cPersonTest = new Test.MainObjects.CTestPerson();
			t_Person xxPerson;

			cPersonTest.NewPerson();

			xxPerson = cPersonTest.getTestEntity();

			Assert.That(new PersonController().Delete(xxPerson.ID), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var cPersonTest = new Test.MainObjects.CTestPerson();
			CReturn rResult;

			cPersonTest.RemoveTestEntity();

			rResult = JSON.deserialiseObject<CReturn>(new PersonController().Save(new CPersonData()
			{
				Surname = cPersonTest.TestName
			}));

			cPersonTest.RemoveTestEntity();

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
