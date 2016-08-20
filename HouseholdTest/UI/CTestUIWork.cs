using Household.Test.Base;
using NUnit.Framework;
using Household.Data.Models.Base;

namespace Household.Test.UI
{
	[TestFixture]
	public class CTestUIWork<T, Tinterface> : CTestUIBase<T, Tinterface>
		where T : class, IDataBase
		where Tinterface : ITestBase<T>, new()
	{
		public CTestUIWork(string pv_strGroupName) : base(pv_strGroupName) { }

		public override void NavigateToDataGroup() { NavigateToWork(); }
	}
}