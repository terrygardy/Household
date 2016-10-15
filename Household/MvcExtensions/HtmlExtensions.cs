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
			else {
				templateName = type.Name;
			}

			return html.Partial($"~/Views/Shared/TableCellTemplates/{templateName}.cshtml", model);
		}
	}
}