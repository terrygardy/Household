using NUnit.Framework;
using System;

namespace Household.Test.UI
{
	[TestFixture]
	public class CTestUIFinance<T> : CTestUIBase<T>
		where T : class
	{
		public CTestUIFinance(string pv_strGroupName) : base(pv_strGroupName) { }

		public override void NavigateToDataGroup() { NavigateToFinance(); }
	}
}