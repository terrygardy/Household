﻿using Helpers.Exceptions;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MasterData
{
	[TestFixture]
	public class CTestCompany
	{
		public string TestName { get { return "NewCompanyForTest"; } }
		public string TestDescription { get { return TextBase.TestDescription; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadCompany();
			NewCompany();
			EditCompany();
			DeleteCompany();

			Assert.That(0, Is.EqualTo(0));
		}

		public void RemoveTestEntity()
		{
			var toCompany = getTestObject();
			var xxCompany = getTestEntity(toCompany, false);

			if (xxCompany != null) DeleteCompany();
		}

		public void BadCompany()
		{
			var toCompany = getTestObject();

			try
			{
				toCompany.save(new txx_Company() { Name = " " });

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

		public void NewCompany()
		{
			var toCompany = getTestObject();

			try
			{
				var lngResult = toCompany.save(new txx_Company() { Name = TestName });

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestName, ex.Message));
			}
		}

		public void EditCompany()
		{
			var toCompany = getTestObject();

			try
			{
				var cCompany = getTestEntity(toCompany);
				long lngResult;

				cCompany.Description = TestDescription;

				lngResult = toCompany.save(cCompany);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestName, ex.Message));
			}
		}

		public void DeleteCompany()
		{
			var toCompany = getTestObject();

			try
			{
				var cCompany = getTestEntity(toCompany);
				long lngResult;

				lngResult = toCompany.delete(cCompany);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestName, ex.Message));
			}
		}

		private CCompany getTestObject()
		{
			try
			{
				return new CCompany();
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public txx_Company getTestEntity() { return getTestEntity(getTestObject()); }

		public txx_Company getTestEntity(bool pv_blnWithAssert) { return getTestEntity(getTestObject(), pv_blnWithAssert); }

		public txx_Company getTestEntity(CCompany pv_toCompany) { return getTestEntity(pv_toCompany, true); }

		public txx_Company getTestEntity(CCompany pv_toCompany, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toCompany.getEntities(x => x.Name == TestName, x => x.Name, x => x.Name)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestName, ex.Message));
			}

			return null;
		}
	}
}