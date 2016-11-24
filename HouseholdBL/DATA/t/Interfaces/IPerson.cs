using Household.BL.DATA.Base.Interfaces;

namespace Household.BL.DATA.t.Interfaces
{
	public interface IPerson : IContextBase
	{
		string Surname { get; set; }

		string Forename { get; set; }

		string ToString();
	}
}