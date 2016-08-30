using Household.BL.DATA.txx;
using Household.BL.Functions.Management.txx;
using Household.Controllers;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestShopController : CTestBaseController<ShopController>
	{
		public CTestShopController()
		{
			Controller = new ShopController(CreateSubstitute<IShopManagement>());
		}

		[Test]
		public void Delete()
		{			
			Assert.That(Controller.Delete(0), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			CReturn rResult;

			rResult = JSON.deserialiseObject<CReturn>(Controller.Save(new CShopData { Name = CreateFixture<string>() }));

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
