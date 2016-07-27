using System;

namespace Household.BL.Interfaces.t
{
	public interface IPurchase : IContextBase
	{
		DateTime Occurrence { get; set; }

		long? Shop_ID { get; set; }

		decimal Amount { get; set; }

		string Description { get; set; }
	}
}
