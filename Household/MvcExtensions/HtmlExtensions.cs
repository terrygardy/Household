using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Household.MvcExtensions
{
	public static class HtmlExtensions
	{
		public static MvcHtmlString DisplayStandardRecordButtons<TModel>(this HtmlHelper<TModel> html, string objectName)
		{
			return html.Partial("~/Views/Shared/DisplayTemplates/StandardRecordButtons.cshtml", objectName);
		}

		public static MvcHtmlString DisplayErrorContainer<TModel>(this HtmlHelper<TModel> html)
		{
			return html.Partial("~/Views/Shared/DisplayTemplates/ErrorContainer.cshtml");
		}

		public static MvcHtmlString DisplayTableCell<TModel>(this HtmlHelper<TModel> html, object model)
		{
			if (model == null) return MvcHtmlString.Create("-");

			var type = model.GetType();
			string templateName;

			if (type.Namespace.Contains("Proxies"))
			{
				templateName = type.BaseType.Name;
			}
			else
			{
				templateName = type.Name;
			}

			return html.Partial($"~/Views/Shared/TableCellTemplates/{templateName}.cshtml", model);
		}

		public static MvcHtmlString PreviewActionLink<TModel>(this HtmlHelper<TModel> html, string controller)
			where TModel : Data.Models.Base.IDataBase
		{
			return html.ActionLink(html.ViewData.Model.ToString(), "Preview", new { controller = controller, id = html.ViewData.Model.ID }, new { @class = "preview" });
		}

		public static MvcHtmlString PreviewActionLinkShop<TModel>(this HtmlHelper<TModel> html)
			where TModel : Data.Models.Base.IDataBase
		{
			return PreviewActionLink(html, ControllerNames.Shop);
		}

		public static MvcHtmlString PreviewActionLinkCompany<TModel>(this HtmlHelper<TModel> html)
			where TModel : Data.Models.Base.IDataBase
		{
			return PreviewActionLink(html, ControllerNames.Company);
		}

		public static MvcHtmlString PreviewActionLinkBankAccount<TModel>(this HtmlHelper<TModel> html)
			where TModel : Data.Models.Base.IDataBase
		{
			return PreviewActionLink(html, ControllerNames.BankAccount);
		}

		#region Actions

		#region Server Manager

		public static MvcHtmlString ActionLinkServerManager(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.ServerManager, routeValues, htmlAttributes);
		}

		#endregion

		#region Home

		public static MvcHtmlString ActionLinkHome(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Home, routeValues, htmlAttributes);
		}

		#endregion

		#region HomeHDD

		public static MvcHtmlString ActionLinkHomeHDD(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.HomeHDD, routeValues, htmlAttributes);
		}

		#endregion

		#region Finance

		public static MvcHtmlString ActionLinkFinance(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Finance, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkExpenses(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Expenses, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkPurchases(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Purchases, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkReport(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Report, routeValues, htmlAttributes);
		}

		#endregion

		#region Work

		public static MvcHtmlString ActionLinkWork(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Work, routeValues, htmlAttributes);
		}

		#endregion

		#region Master Data

		public static MvcHtmlString ActionLinkMasterData(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.MasterData, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkBankAccount(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.BankAccount, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkCompany(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Company, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkDay(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Day, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkIncome(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Income, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkInterval(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Interval, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkPerson(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Person, routeValues, htmlAttributes);
		}

		public static MvcHtmlString ActionLinkShop(this HtmlHelper htmlHelper, string linkText, string actionName, object routeValues = null, object htmlAttributes = null)
		{
			return htmlHelper.ActionLink(linkText, actionName, ControllerNames.Shop, routeValues, htmlAttributes);
		}

		#endregion

		#endregion
	}
}