using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace Household.Test.Controllers
{
	public abstract class CTestBaseController<T>
		where T: Controller, new()
	{
		protected void BaseTestActionResult(Expression<Func<T, ActionResult>> pv_exCall)
		{
			new T().WithCallTo(pv_exCall).ShouldRenderDefaultView();
		}

		protected void BaseTestPartialViewResult(Expression<Func<T, PartialViewResult>> pv_exCall)
		{
			new T().WithCallTo(pv_exCall).ShouldRenderDefaultPartialView();
		}
	}
}
