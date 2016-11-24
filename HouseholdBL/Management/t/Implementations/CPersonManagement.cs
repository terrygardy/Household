using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.Management.t.Interfaces;
using Household.Data.Db;
using Household.BL.DATA.t.Implementations;

namespace Household.BL.Management.t.Implementations
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