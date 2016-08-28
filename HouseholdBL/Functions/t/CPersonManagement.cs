using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.DATA.t;
using Household.BL.Functions.Management.t;

namespace Household.BL.Functions.t
{
	public class CPersonManagement : CModelBase<t_Person, string, string, CPersonData>, IPersonManagement
	{
		public CPersonManagement() { }

		protected override Expression<Func<t_Person, string>> getStandardOrderBy()
		{
			return x => x.Surname;
		}

		protected override Expression<Func<t_Person, string>> getStandardThenBy()
		{
			return x => x.Forename;
		}

		protected override Expression<Func<t_Person, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		public List<t_Person> getPeople()
		{
			return getEntities<string, string>(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}