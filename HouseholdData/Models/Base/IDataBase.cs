namespace Household.Data.Models.Base
{
	public interface IDataBase
	{
		long ID { get; set; }

		string EntityName { get; }

		string EntityTitle { get; }

		string ToString();
	}
}