using Household.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Household.BL.Functions.Management.t
{
	public interface IBankingManagement
	{
		decimal getCurrentBankBalance();
	}
}