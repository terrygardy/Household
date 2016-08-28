using Household.BL.Functions.txx;
using System.Threading.Tasks;

namespace Household.Models.Environment
{
	public class CEnvironment
	{
		public CEnvironment()
		{
			Task<bool> db = loadDb();
		}

		private async Task<bool> loadDb()
		{
			await Task.Run(() =>
			{
				var cxxGet = new CShopManagement().getDataByID(1);

				cxxGet = null;
			});

			return true;
		}
	}
}