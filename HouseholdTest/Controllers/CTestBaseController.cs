using Household.Test.Base;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace Household.Test.Controllers
{
	public abstract class CTestBaseController<T> : CTestBasicBase
		where T : Controller
	{
		protected T Controller { get; set; }

		protected void BaseTestActionResult(Expression<Func<T, ActionResult>> pv_exCall)
		{
			Controller.WithCallTo(pv_exCall).ShouldRenderDefaultView();
		}

		protected void BaseTestPartialViewResult(Expression<Func<T, PartialViewResult>> pv_exCall)
		{
			Controller.WithCallTo(pv_exCall).ShouldRenderDefaultPartialView();
		}
	}
}