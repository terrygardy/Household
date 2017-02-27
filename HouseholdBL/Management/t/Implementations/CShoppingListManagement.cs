using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Household.BL.Management.t.Interfaces;
using Household.Data.Db;
using Household.BL.DATA.t.Implementations;
using System.Linq;

namespace Household.BL.Management.t.Implementations
{
	public class CShoppingListManagement : CManagementBase<t_ShoppingListItem, string, string, CShoppingListItemData>, IShoppingListManagement
	{
		public CShoppingListManagement(IDb db)
		: base(db) { }

		protected override Expression<Func<t_ShoppingListItem, string>> getStandardOrderBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<t_ShoppingListItem, string>> getStandardThenBy()
		{
			return x => x.txx_Shop.Name;
		}

		public List<t_ShoppingListItem> getShoppingList()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy()).ToList();
		}
	}
}