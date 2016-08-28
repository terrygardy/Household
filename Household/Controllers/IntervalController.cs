﻿using Household.BL.DATA.txx;
using Household.Controllers.Base;
using Household.Data.Context;
using Household.BL.Functions.Management.txx;

namespace Household.Controllers
{
	public class IntervalController : CRUDController<txx_Interval, IIntervalManagement, string, string, CIntervalData>
	{
		public IntervalController(IIntervalManagement management)
			: base(management)
		{ }

		protected override long GetDataID(CIntervalData data)
		{
			return data.ID;
		}
	}
}