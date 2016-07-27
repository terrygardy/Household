using NUnit.Framework;
using System;

namespace Household.Test.UI
{
	[TestFixture]
	public class CTestUIMasterData<T> : CTestUIBase<T>
		where T : class
	{
		public CTestUIMasterData(string pv_strGroupName) : base(pv_strGroupName) { }

		public override void NavigateToDataGroup() { NavigateToMasterData(); }
	}
}