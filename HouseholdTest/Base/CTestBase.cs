using Helpers.Exceptions;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;

namespace Household.Test.Base
{
	[TestFixture]
	public class CTestBase<T>
		where T : class
	{
		private string TestName { get { return "NewShopForTest"; } }

		[Test]
		public void MainTest()
		{

			var toShop = getTestObject();
			var xxShop = getTestShop(toShop, false);

			if (xxShop != null) DeleteShop();

			BadShop();
			NewShop();
			EditShop();
			DeleteShop();

			Assert.That(0 == 0);
		}

		public void BadShop()
		{
			var toShop = getTestObject();

			try
			{
				toShop.save(new txx_Shop() { Name = "" });

				Assert.Fail();
			}
			catch (Exception ex)
			{
				if (typeof(ValidationException) != ex.GetType())
				{
					Assert.Fail(TextBase.getErrorSave("Empty", ex.Message));
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
				var cShop = getTestShop(toShop);
				long lngResult;

				cShop.Description = TextBase.TestDescription;

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
			CShop toShop = getTestObject();

			try
			{
				var cShop = getTestShop(toShop);
				long lngResult;

				lngResult = toShop.delete(cShop);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestName, ex.Message));
			}
		}

		private T getTestObject()
		{
			try
			{
				return new T(Models.Db.CDbContext.getInstance());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		private txx_Shop getTestShop(CShop pv_toShop) { return getTestShop(pv_toShop, true); }

		private txx_Shop getTestShop(CShop pv_toShop, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toShop.getEntities(x => x.Name == TestName, x => x.Name, x => x.Name)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestName, ex.Message));
			}

			return null;
		}
	}
}