using Household.BL.DATA.txx;
using Household.Controllers;
using Household.Data.Context;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestCompanyController : CTestBaseController<CompanyController>
	{
		[Test]
		public void Delete()
		{
			var cCompanyTest = new Test.MasterData.CTestCompany();
			txx_Company xxCompany;

			cCompanyTest.NewCompany();

			xxCompany = cCompanyTest.getTestEntity();

			Assert.That(new CompanyController().Delete(xxCompany.ID), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var cCompanyTest = new Test.MasterData.CTestCompany();
			CReturn rResult;

			cCompanyTest.RemoveTestEntity();

			rResult = JSON.deserialiseObject<CReturn>(new CompanyController().Save(new CCompanyData()
			{
				Name = cCompanyTest.TestName
			}));

			cCompanyTest.RemoveTestEntity();

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
