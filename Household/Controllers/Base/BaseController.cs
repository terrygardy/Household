using System.Threading;
using System.Web.Mvc;

namespace Household.Controllers.Base
{
    public class BaseController : Controller
    {
		public BaseController()
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("de-DE");
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
		}
    }
}