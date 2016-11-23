using Household.BL.DATA.Base.Interfaces;
using System;

namespace Household.BL.DATA.t.Interfaces
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