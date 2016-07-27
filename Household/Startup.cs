using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Household.Startup))]
namespace Household
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			//ConfigureAuth(app);
		}
	}
}
