using Household.BL.DATA.Base.Interfaces;

namespace Household.BL.DATA.t.Interfaces
{
	public interface IShoppingListItem : IContextBase
	{
		string Name { get; set; }

		long? Shop_ID { get; set; }

		decimal Amount { get; set; }

		string ToString();
	}
}