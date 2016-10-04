using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Household.MvcExtensions
{
	public static class KnockoutConstruction
	{
		public static MvcHtmlString KnockoutTextBox<TModel>(this HtmlHelper<TModel> htmlHelper, string id, string data_bind, bool required)
		{
			object htmlAttributes;

			if (required)
			{
				htmlAttributes = new { required = "required", id, data_bind };
			}
			else
			{
				htmlAttributes = new { id, data_bind };
			}

			return htmlHelper.TextBox(id, null, htmlAttributes);
		}

		public static MvcHtmlString KnockoutDropDownListFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
			Expression<Func<TModel, TValue>> expression, string id, string data_bind, bool required)
		{
			var requiredAttribute = (required) ? "required" : "";

			return new MvcHtmlString($"<select id=\"{id}\" data-bind=\"{data_bind}\" {requiredAttribute}>" +
											htmlHelper.EditorFor(expression, "SelectOptions") +
										"</select>");
		}
	}
}