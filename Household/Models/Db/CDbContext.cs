using Household.Data.Context;

namespace Household.Models.Db
{
	public static class CDbContext
	{
		private static Database m_dbHousehold = null;

		public static Database getInstance()
		{
			if (m_dbHousehold == null) Database.UpdateDatabase();

			resetDb();

			return m_dbHousehold;
		}

		private static void resetDb()
		{
			closeDb();
			m_dbHousehold = new Database();
		}

		public static void closeDb()
		{
			if (m_dbHousehold != null) m_dbHousehold.Dispose();

			m_dbHousehold = null;
		}
	}
}