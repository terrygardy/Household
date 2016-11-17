using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.DATA.t;
using Household.BL.Functions.Management.t;
using Household.Data.Db;

namespace Household.BL.Functions.t
{
	public class CPersonManagement : CManagementBase<t_Person, string, string, CPersonData>, IPersonManagement
	{
		public CPersonManagement(IDb db)
			: base(db) { }

		protected override Expression<Func<t_Person, string>> getStandardOrderBy()
		{
			return x => x.Surname;
		}

		protected override Expression<Func<t_Person, string>> getStandardThenBy()
		{
			return x => x.Forename;
		}

		public IEnumerable<t_Person> getPeople()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}