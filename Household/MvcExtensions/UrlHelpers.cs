using System.Web.Mvc;

namespace Household.MvcExtensions
{
	public static class UrlHelpers
	{
		#region Server Manager

		public static string ActionServerManager(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.ServerManager, routeValues);
		}

		#endregion

		#region Home

		public static string ActionHome(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Home, routeValues);
		}

		#endregion

		#region HomeHDD

		public static string ActionHomeHDD(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.HomeHDD, routeValues);
		}

		#endregion

		#region Finance

		public static string ActionFinance(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Finance, routeValues);
		}

		public static string ActionExpenses(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Expenses, routeValues);
		}

		public static string ActionPurchases(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Purchases, routeValues);
		}

		public static string ActionReport(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Report, routeValues);
		}

		#endregion

		#region Work

		public static string ActionWork(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Work, routeValues);
		}

		#endregion

		#region Master Data

		public static string ActionMasterData(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.MasterData, routeValues);
		}

		public static string ActionBankAccount(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.BankAccount, routeValues);
		}

		public static string ActionCompany(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Company, routeValues);
		}

		public static string ActionDay(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Day, routeValues);
		}

		public static string ActionIncome(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Income, routeValues);
		}

		public static string ActionInterval(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Interval, routeValues);
		}

		public static string ActionPerson(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Person, routeValues);
		}

		public static string ActionShop(this UrlHelper url, string actionName, object routeValues = null)
		{
			return url.Action(actionName, ControllerNames.Shop, routeValues);
		}

		//public static string Action(this UrlHelper url, string actionName, object routeValues = null)
		//{
		//	return url.Action(actionName, ControllerNames., routeValues);
		//}

		#endregion
	}
}