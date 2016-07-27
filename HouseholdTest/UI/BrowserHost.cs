using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using TestStack.Seleno.Configuration;

namespace Household.Test.UI
{
	public static class BrowserHost
	{
		public static readonly SelenoHost Instance = new SelenoHost();
		public static readonly IWebDriver Browser;
		public static readonly string RootUrl;

		static BrowserHost()
		{
			Instance.Run("Household", 4223, null);

			RootUrl = Instance.Application.Browser.Url;

			Browser = Instance.Application.Browser;
		}

		public static void Wait()
		{
			Wait(1000);
		}

		public static void Wait(int pv_intMiliseconds) {
			Thread.Sleep(pv_intMiliseconds);
		}

		public static IWebElement FindElementById(string pv_strId) {
			return Browser.FindElement(By.Id(pv_strId));
		}

		public static IWebElement FindElementByClass(string pv_strCSS)
		{
			return Browser.FindElement(By.ClassName(pv_strCSS));
		}

		public static IWebElement FindElementByTagName(string pv_strTag)
		{
			return Browser.FindElement(By.TagName(pv_strTag));
		}

		public static void SelectOptionFromDropDown(string pv_strId, string pv_strValue) {
			new SelectElement(FindElementById(pv_strId)).SelectByValue(pv_strValue);
		}
	}
}
