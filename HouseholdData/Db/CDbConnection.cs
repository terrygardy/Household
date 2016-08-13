using Household.Data.Context;

namespace Household.Data.Db
{
	public static class CDbConnection
	{
		private static bool Updated { get; set; }
		
		public static Database getInstance()
		{
			if (!Updated) {
				Database.UpdateDatabase();
				Updated = true;
			}

			return new Database();
		}
	}
}
