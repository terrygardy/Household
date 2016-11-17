using Household.BL.Functions.Management.txx;
using System.Threading.Tasks;

namespace Household.Models.Environment
{
	public class CEnvironment
	{
		public CEnvironment(IShopManagement shopManagement)
		{
			Task<bool> db = loadDb(shopManagement);
		}

		private async Task<bool> loadDb(IShopManagement shopManagement)
		{
			await Task.Run(() =>
			{
				var cxxGet = shopManagement.getDataByID(1);

				cxxGet = null;
			});

			return true;
		}
	}
}