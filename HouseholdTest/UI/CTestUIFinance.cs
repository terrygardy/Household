using Household.Data.Models.Base;
using Household.Test.Base;
using NUnit.Framework;
using System;

namespace Household.Test.UI
{
	[TestFixture]
	public class CTestUIFinance<T, Tinterface> : CTestUIBase<T, Tinterface>
		where T : class, IDataBase
		where Tinterface : ITestBase<T>, new()
	{
		public CTestUIFinance(string pv_strGroupName) : base(pv_strGroupName) { }

		public override void NavigateToDataGroup() { NavigateToFinance(); }
	}
}