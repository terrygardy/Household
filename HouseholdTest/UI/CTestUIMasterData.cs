using Household.Data.Models.Base;
using Household.Test.Base;
using NUnit.Framework;

namespace Household.Test.UI
{
	[TestFixture]
	public class CTestUIMasterData<T, Tinterface> : CTestUIBase<T, Tinterface>
		where T : class, IDataBase
		where Tinterface : ITestBase<T>, new()
	{
		public CTestUIMasterData(string pv_strGroupName) : base(pv_strGroupName) { }

		public override void NavigateToDataGroup() { NavigateToMasterData(); }
	}
}