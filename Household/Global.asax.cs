using Household.BL.Functions.txx;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Household
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			loadDb();
		}

		private async void loadDb()
		{
			await System.Threading.Tasks.Task.Run(() =>
			{
				var cxxGet = new CShop().getDataByID(1);

				cxxGet = null;
			});
		}
	}
}
