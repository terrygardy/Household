using Household.BL.DATA.Base.Interfaces;
using System;

namespace Household.BL.DATA.t.Interfaces
{
	public interface IPurchase : IContextBase
	{
		DateTime Occurrence { get; set; }

		long? Shop_ID { get; set; }

		decimal Amount { get; set; }

		string Description { get; set; }
	}
}