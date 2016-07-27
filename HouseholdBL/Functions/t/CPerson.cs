using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using Household.BL.DATA.t;

namespace Household.BL.Functions.t
{
	public class CPerson : CModelBase<t_Person, string, string, CPersonData>
	{
		public CPerson() { }

		public CPerson(Database dbHousehold) : base(dbHousehold) { }

		public override void validate(t_Person pv_cEntity)
		{
			if (string.IsNullOrWhiteSpace(pv_cEntity.Surname)) { throw new ValidationException(Person.EnterName); }

			if (string.IsNullOrWhiteSpace(pv_cEntity.Forename)) pv_cEntity.Forename = "";

			pv_cEntity.Surname = pv_cEntity.Surname.Trim();
			pv_cEntity.Forename = pv_cEntity.Forename.Trim();

			if (getModel(x => x.ID != pv_cEntity.ID &&
						string.Compare(x.Surname, pv_cEntity.Surname, true) == 0 &&
						string.Compare(x.Forename, pv_cEntity.Forename, true) == 0) != null) throw new ValidationException(Person.PersonExists);
		}

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