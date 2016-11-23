using Household.BL.DATA.txx.Implementations;
using Household.BL.Management.txx.Interfaces;
using Household.Controllers;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestCompanyController : CTestBaseController<CompanyController>
	{
		public CTestCompanyController()
		{
			Controller = new CompanyController(CreateSubstitute<ICompanyManagement>());
		}

		[Test]
		public void Delete()
		{
			Assert.That(Controller.Delete(0), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var rResult = JSON.deserialiseObject<CReturn>(Controller.Save(new CCompanyData { Name = CreateFixture<string>() }));

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}