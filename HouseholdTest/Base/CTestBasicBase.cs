using NSubstitute;
using Ploeh.AutoFixture;

namespace Household.Test.Base
{
	public class CTestBasicBase
	{
		protected Fixture FixtureInstance { get; }

		protected CTestBasicBase() {
			FixtureInstance = new Fixture();
		}

		protected T CreateFixture<T>() {
			return FixtureInstance.Create<T>();
		}

		protected T CreateSubstitute<T>()
			where T : class
		{
			return Substitute.For<T>();
		}
	}
}