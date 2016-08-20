﻿using Household.BL.Functions.t;
using Household.Data.Context;
using Household.Models.Finance;
using Household.Models.Search;
using Household.Test.MainObjects;
using NUnit.Framework;

namespace Household.Test.Search.MainObjects
{
	[TestFixture]
	public class CTestSearchPurchase
	{
		[Test]
		public void Search()
		{
			var cTest = new CTestPurchase();
			t_Purchase tPurchase;

			try
			{
				var cSearch = new CSearchPurchase();
				CPurchasesModel cModel;
				int intRows;

				cTest.RemoveTestEntity();
				cTest.NewPurchase();
				tPurchase = cTest.GetTestEntity();

				cSearch.Amount = tPurchase.Amount;
				cSearch.Description = tPurchase.Description;
				cSearch.From = tPurchase.Occurrence;
				cSearch.To = tPurchase.Occurrence;
				cSearch.Where = tPurchase.txx_Shop.Name;
				cSearch.Who = tPurchase.txx_BankAccount.AccountName;

				cModel = new CPurchasesModel();
				intRows = cModel.search(cSearch).Body.Count;

				Assert.That(intRows == 1);
			}
			finally
			{
				cTest.RemoveTestEntity();
				tPurchase = null;
			}
		}

		[Test]
		public void EmptySearch()
		{
			int intRowsExpected = new CPurchase().getPurchases().Count;
			int intRowsFound = new CPurchasesModel().search(new CSearchPurchase()).Body.Count;

			Assert.That(intRowsExpected == intRowsFound);
		}
	}
}
