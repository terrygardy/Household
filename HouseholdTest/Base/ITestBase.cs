namespace Household.Test.Base
{
	public interface ITestBase<T>
		where T : class
	{
		T getTestEntity();
	}
}
