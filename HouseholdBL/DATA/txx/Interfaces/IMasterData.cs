using Household.BL.DATA.Base.Interfaces;

namespace Household.BL.DATA.txx.Interfaces
{
	public interface IMasterData : IContextBase
	{
		string Name { get; set; }
	}
}