using Helpers.Exceptions;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Data.Db;
using Household.Test.Base;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace Household.Test.MasterData
{
	[TestFixture]
	public class CTestShop : ITestBase<txx_Shop>
	{
		public string TestName { get { return "NewShopForTest"; } }
		public string TestDescription { get { return TextBase.TestDescription; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadShop();
			NewShop();
			EditShop();
			DeleteShop();

			
		}

		public void RemoveTestEntity() {
			var toShop = getTestObject();
			var xxShop = GetTestEntity(toShop, false);

			if (xxShop != null) DeleteShop();
		}

		public void BadShop()
		{
			var toShop = getTestObject();

			try
			{
				toShop.save(new txx_Shop() { Name = " " });

				Assert.Fail();
			}
			catch (Exception ex)
			{
				if (typeof(ValidationException) != ex.GetType())
				{
					Assert.Fail(TextBase.getErrorSave(MethodBase.GetCurrentMethod().Name, ex.Message));
				}
			}
		}

		public void NewShop()
		{
			var toShop = getTestObject();

			try
			{
				var lngResult = toShop.save(new txx_Shop() { Name = TestName });

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestName, ex.Message));
			}
		}

		public void EditShop()
		{
			var toShop = getTestObject();

			try
			{
				var cShop = GetTestEntity(toShop);
				long lngResult;

				cShop.Description = TestDescription;

				lngResult = toShop.save(cShop);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestName, ex.Message));
			}
		}

		public void DeleteShop()
		{
			var toShop = getTestObject();

			try
			{
				var cShop = GetTestEntity(toShop);
				long lngResult;

				lngResult = toShop.delete(cShop);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestName, ex.Message));
			}
		}

		private CShopManagement getTestObject()
		{
			try
			{
				return new CShopManagement(new CDbDefault());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public txx_Shop GetTestEntity() { return GetTestEntity(getTestObject()); }

		public txx_Shop GetTestEntity(bool pv_blnWithAssert) { return GetTestEntity(getTestObject(), pv_blnWithAssert); }

		public txx_Shop GetTestEntity(CShopManagement pv_toShop) { return GetTestEntity(pv_toShop, true); }

		public txx_Shop GetTestEntity(CShopManagement pv_toShop, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toShop.getEntities(x => x.Name == TestName, x => x.Name, x => x.Name).FirstOrDefault();
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestName, ex.Message));
			}

			return null;
		}
	}
}