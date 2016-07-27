namespace Household.BL.Interfaces.t
{
	public interface IPerson : IContextBase
	{
		string Surname { get; set; }

		string Forename { get; set; }

		string ToString();
	}
}
