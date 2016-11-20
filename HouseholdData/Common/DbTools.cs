using System;

namespace Household.Data.Common
{
	public class DbTools
	{
		public static readonly DateTime MinDate = new DateTime(1753, 1, 1);
		public static readonly TimeSpan MinTime = new TimeSpan(0, 0, 0, 0, 1);
	}
}