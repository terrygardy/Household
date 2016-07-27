﻿using Helpers.Exceptions;
using Household.BL.Functions.t;
using Household.BL.Functions.txx;
using Household.Data.Context;
using Household.Test.Text;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Household.Test.MainObjects
{
	[TestFixture]
	public class CTestPurchase
	{
		private txx_BankAccount m_xxPayer;
		private txx_Shop m_xxShop;

		public DateTime TestOccurrence { get { return new DateTime(1900, 1, 1); } }
		public decimal TestAmount { get { return 567; } }
		public string TestDescription { get { return TextBase.TestDescription; } }
		public txx_BankAccount TestPayer { get { return m_xxPayer; } }
		public txx_Shop TestShop { get { return m_xxShop; } }

		public CTestPurchase()
		{
			m_xxPayer = new CBankAccount(Models.Db.CDbContext.getInstance()).getBankAccounts()[0];
			m_xxShop = new CShop(Models.Db.CDbContext.getInstance()).getShops()[0];
		}

		[Test]
		public void MainTest()
		{
			RemoveTestEntity();
			BadPurchase();
			NewPurchase();
			EditPurchase();
			DeletePurchase();

			Assert.That(0, Is.EqualTo(0));
		}

		public void RemoveTestEntity()
		{
			var toPurchase = getTestObject();
			var xxPurchase = getTestEntity(toPurchase, false);

			if (xxPurchase != null) DeletePurchase();
		}

		public void BadPurchase()
		{
			BadOccurrence();
			FutureOccurrence();
			BadAmount();
			BadPayer();
			BadShop();
		}

		public void BadOccurrence()
		{
			var toPurchase = getTestObject();

			try
			{
				toPurchase.save(new t_Purchase()
				{
					Occurrence = new DateTime(1753, 1, 1),
					Amount = TestAmount,
					Payer_ID = TestPayer.ID,
					Shop_ID = TestShop.ID
				});

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

		public void FutureOccurrence()
		{
			var toPurchase = getTestObject();

			try
			{
				toPurchase.save(new t_Purchase()
				{
					Occurrence = DateTime.Now.AddDays(1),
					Amount = TestAmount,
					Payer_ID = TestPayer.ID,
					Shop_ID = TestShop.ID
				});

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

		public void BadAmount()
		{
			var toPurchase = getTestObject();

			try
			{
				toPurchase.save(new t_Purchase()
				{
					Occurrence = TestOccurrence,
					Amount = -1,
					Payer_ID = TestPayer.ID,
					Shop_ID = TestShop.ID,
				});

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

		public void BadPayer()
		{
			var toPurchase = getTestObject();

			try
			{
				toPurchase.save(new t_Purchase()
				{
					Occurrence = TestOccurrence,
					Amount = TestAmount,
					Payer_ID = 0,
					Shop_ID = TestShop.ID,
				});

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

		public void BadShop()
		{
			var toPurchase = getTestObject();

			try
			{
				toPurchase.save(new t_Purchase()
				{
					Occurrence = TestOccurrence,
					Amount = TestAmount,
					Payer_ID = TestPayer.ID,
					Shop_ID = 0,
				});

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

		public void NewPurchase()
		{
			var toPurchase = getTestObject();

			try
			{
				var lngResult = toPurchase.save(new t_Purchase()
				{
					Occurrence = TestOccurrence,
					Amount = TestAmount,
					Payer_ID = TestPayer.ID,
					Shop_ID = TestShop.ID,
					Description = "Test"
				});

				if (lngResult < 1) Assert.Fail(TextBase.getErrorSave(TestOccurrence.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorSave(TestOccurrence.ToShortDateString(), ex.Message));
			}
		}

		public void EditPurchase()
		{
			var toPurchase = getTestObject();

			try
			{
				var cPurchase = getTestEntity(toPurchase);
				long lngResult;

				cPurchase.Description = TestDescription;

				lngResult = toPurchase.save(cPurchase);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorEdit(TestOccurrence.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorEdit(TestOccurrence.ToShortDateString(), ex.Message));
			}
		}

		public void DeletePurchase()
		{
			var toPurchase = getTestObject();

			try
			{
				var cPurchase = getTestEntity(toPurchase);
				long lngResult;

				lngResult = toPurchase.delete(cPurchase);

				if (lngResult < 1) Assert.Fail(TextBase.getErrorDelete(TestOccurrence.ToShortDateString(), TextBase.ErrorUnknown));
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.getErrorDelete(TestOccurrence.ToShortDateString(), ex.Message));
			}
		}

		private CPurchase getTestObject()
		{
			try
			{
				return new CPurchase(Models.Db.CDbContext.getInstance());
			}
			catch (Exception ex)
			{
				Assert.Fail(TextBase.ErrorOnTestObject + ": " + ex.Message);
			}

			return null;
		}

		public t_Purchase getTestEntity() { return getTestEntity(getTestObject(), true); }

		public t_Purchase getTestEntity(bool pv_blnWithAsserts) { return getTestEntity(getTestObject(), pv_blnWithAsserts); }

		public t_Purchase getTestEntity(CPurchase pv_toPurchase) { return getTestEntity(pv_toPurchase, true); }

		public t_Purchase getTestEntity(CPurchase pv_toPurchase, bool pv_blnWithAssert)
		{
			try
			{
				return pv_toPurchase.getEntities(x => x.Occurrence == TestOccurrence && x.Amount == TestAmount
													&& x.Payer_ID == TestPayer.ID && x.Shop_ID == TestShop.ID,
												x => x.Occurrence, x => x.Occurrence)[0];
			}
			catch (Exception ex)
			{
				if (pv_blnWithAssert) Assert.Fail(TextBase.getErrorNotFound(TestOccurrence.ToShortDateString(), ex.Message));
			}

			return null;
		}
	}
}