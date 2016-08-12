using System;

namespace Household.BL.Interfaces.t
{
	public interface IWorkDay : IContextBase
	{
		DateTime WorkDay { get; set; }

		TimeSpan Begin { get; set; }

		TimeSpan End { get; set; }

		decimal BreakDuration { get; set; }

		decimal HoursWorked { get; }
	}
}
