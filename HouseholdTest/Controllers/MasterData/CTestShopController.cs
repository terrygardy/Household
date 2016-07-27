using Household.BL.DATA.txx;
using Household.Controllers;
using Household.Data.Context;
using Household.Models.MasterData;
using NUnit.Framework;
using WebHelpers;

namespace Household.Test.Controllers.MasterData
{
	[TestFixture]
	public class CTestShopController : CTestBaseController<ShopController>
	{
		[Test]
		public void Delete()
		{
			var cShopTest = new Test.MasterData.CTestShop();
			txx_Shop xxShop;

			cShopTest.NewShop();

			xxShop = cShopTest.getTestEntity();

			Assert.That(new ShopController().Delete(xxShop.ID), Is.EqualTo(""));
		}

		[Test]
		public void Save()
		{
			var cShopTest = new Test.MasterData.CTestShop();
			CReturn rResult;

			cShopTest.RemoveTestEntity();

			rResult = JSON.deserialiseObject<CReturn>(new ShopController().Save(new CShopData()
			{
				Name = cShopTest.TestName
			}));

			cShopTest.RemoveTestEntity();

			Assert.That(rResult.Message, Is.EqualTo(""));
		}
	}
}
