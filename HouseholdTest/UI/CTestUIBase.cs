using Household.Test.Base;
using NUnit.Framework;
using System;
using Household.Data.Models.Base;

namespace Household.Test.UI
{
	[TestFixture]
	public abstract class CTestUIBase<T, Tinterface>
		where T : class, IDataBase
		where Tinterface : ITestBase<T>, new()
	{
		protected string GroupName { get; set; }
		protected Tinterface TestObj { get; set; }

		public CTestUIBase(string pv_strGroupName)
		{
			GroupName = pv_strGroupName;
			TestObj = new Tinterface();
		}

		public void NavigateToHome()
		{
			BrowserHost.Instance.Application.Browser.Navigate().GoToUrl(BrowserHost.RootUrl + "/Home/Index");
			//BrowserHost.Wait();
		}

		public void NavigateToFinance()
		{
			NavigateToHome();
			ClickPanel("finance");
		}

		public void NavigateToWork()
		{
			NavigateToHome();
			ClickPanel("work");
		}

		public void NavigateToMasterData()
		{
			NavigateToFinance();
			ClickPanel("masterData");
		}

		public virtual void NavigateToDataGroup() { throw new NotImplementedException(); }

		public void NavigateToDataGroup(string pv_strGroupName)
		{
			NavigateToDataGroup();

			ClickPanel(pv_strGroupName);
		}

		public void NavigateToNewDataEntry() { NavigateToNewDataEntry(GroupName); }

		public void NavigateToNewDataEntry(string pv_strGroupName)
		{
			NavigateToDataGroup(pv_strGroupName);

			ClickAddButton();
		}

		public void NavigateToNewDataEntryWithTestData()
		{
			NavigateToNewDataEntry();
			LoadTestData();
		}

		public void NavigateToDataEntry(string pv_strId) { NavigateToDataEntry(GroupName, pv_strId); }

		public void NavigateToDataEntry(string pv_strGroupName, string pv_strId)
		{
			NavigateToDataGroup(pv_strGroupName);

			ClickElement(pv_strId);
		}

		#region "Click Element"
		public static void ClickPanel(string pv_strName)
		{
			BrowserHost.FindElementByClass("panel-" + pv_strName).Click();

			//BrowserHost.Wait();
		}

		public static void ClickElement(string pv_strId)
		{
			BrowserHost.FindElementById(pv_strId).Click();

			//BrowserHost.Wait();
		}

		public static void ClickAddButton()
		{
			ClickElement("btnAdd");
		}

		public static void ClickSaveButton()
		{
			ClickElement("btnSave");
		}

		public static void ClickDeleteButton()
		{
			ClickElement("btnDelete");
		}
		#endregion

		public static void ClearElementContent(string pv_strId)
		{
			BrowserHost.FindElementById(pv_strId).Clear();
		}

		public static void SendTextToElement(string pv_strId, string pv_strText)
		{
			ClearElementContent(pv_strId);
			BrowserHost.FindElementById(pv_strId).SendKeys(pv_strText);
			//BrowserHost.Wait();
		}

		public static void SelectOptionDropDownList(string pv_strId, string pv_strValue)
		{
			BrowserHost.SelectOptionFromDropDown(pv_strId, pv_strValue);
		}

		#region "Load Data"
		public virtual void LoadTestData() { throw new NotImplementedException(); }

		public virtual void LoadEditData() { throw new NotImplementedException(); }
		#endregion

		public T GetTestEntity() { return TestObj.GetTestEntity(false); }

		public long GetTestId() { return GetTestEntity().ID; }

		public void RemoveTestEntity() { TestObj.RemoveTestEntity(); }

		#region "Delete Entries"
		public virtual void DeleteEntry()
		{
			DeleteEntry(NavigateToDataEntry);
		}

		protected void DeleteEntry(Action<string> pv_fnNavigateToEntry)
		{
			pv_fnNavigateToEntry.Invoke(GetTestId().ToString());

			ClickDeleteButton();
		}
		#endregion

		#region "Add Entries"

		public virtual void AddTestEntry()
		{
			AddTestEntry(NavigateToNewDataEntryWithTestData);
		}

		public void AddTestEntry(Action pv_fnNavigateToDataEntry)
		{
			RemoveTestEntity();

			pv_fnNavigateToDataEntry.Invoke();

			ClickSaveButton();
		}
		#endregion

		public void AssertTestEntityDeleted() { Assert.That(GetTestEntity(), Is.EqualTo(null)); }

		#region "Standard Functions"
		[Test]
		public virtual void AddAndDeleteWithFullRedirect()
		{
			AddTestEntry();

			DeleteEntry();

			AssertTestEntityDeleted();
		}

		[Test]
		public virtual void AddAndDeleteDirectFromList()
		{
			AddTestEntry();

			ClickElement(GetTestId().ToString());

			ClickDeleteButton();

			AssertTestEntityDeleted();
		}

		[Test]
		public virtual void AddEditAndDeleteDirectFromList()
		{
			string strTestId;

			AddTestEntry();

			strTestId = GetTestId().ToString();

			ClickElement(strTestId);

			LoadEditData();

			ClickSaveButton();

			ClickElement(strTestId);

			ClickDeleteButton();

			AssertTestEntityDeleted();
		}
		#endregion
	}
}
