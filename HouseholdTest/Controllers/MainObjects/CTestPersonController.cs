using Household.BL.DATA.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.Controllers;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MainObjects
{
	[TestFixture]
	public class CTestPersonController : CTestBaseController<PersonController>
	{
		public CTestPersonController()
		{
			Controller = new PersonController(CreateSubstitute<IPersonManagement>());
		}

		[Test]
		public void Delete()
		{
			Assert.That(Controller.Delete(0), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var rResult = JSON.deserialiseObject<CReturn>(Controller.Save(new CPersonData { Surname = CreateFixture<string>() }));

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}