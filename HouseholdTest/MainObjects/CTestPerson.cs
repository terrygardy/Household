﻿using Helpers.Exceptions;
using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MainObjects
{
	[TestFixture]
	public class CTestPerson
	{
		public string TestName { get { return "NewPersonForTest"; } }
		public string TestForename { get { return TextBase.TestDescription; } }

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadPerson();
			NewPerson();
			EditPerson();
			DeletePerson();

			Assert.That(0, Is.EqualTo(0));
		}

		public void RemoveTestEntity() {
			var toPerson = getTestObject();
			var xxPerson = getTestEntity(toPerson, false);

			if (xxPerson != null) DeletePerson();
		}

		public void BadPerson()
		{
			var toPerson = getTestObject();

			try
			{
				toPerson.save(new t_Person() { Surname = " " });

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

		public void NewPerson()
		{
			var toPerson = getTestObject();

			try
			{
				var lngResult = toPerson.save(new t_Person() { Surname = TestName });

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestName, ex.Message));
			}
		}

		public void EditPerson()
		{
			var toPerson = getTestObject();

			try
			{
				var cPerson = getTestEntity(toPerson);
				long lngResult;

				cPerson.Forename = TestForename;

				lngResult = toPerson.save(cPerson);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestName, ex.Message));
			}
		}

		public void DeletePerson()
		{
			var toPerson = getTestObject();

			try
			{
				var cPerson = getTestEntity(toPerson);
				long lngResult;

				lngResult = toPerson.delete(cPerson);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestName, TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestName, ex.Message));
			}
		}

		private CPerson getTestObject()
		{
			try
			{
				return new CPerson(Models.Db.CDbContext.getInstance());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public t_Person getTestEntity() { return getTestEntity(getTestObject()); }

		public t_Person getTestEntity(bool pv_blnWithAssert) { return getTestEntity(getTestObject(), pv_blnWithAssert); }

		public t_Person getTestEntity(CPerson pv_toPerson) { return getTestEntity(pv_toPerson, true); }

		public t_Person getTestEntity(CPerson pv_toPerson, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toPerson.getEntities(x => x.Surname == TestName, x => x.Surname, x => x.Surname)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestName, ex.Message));
			}

			return null;
		}
	}
}