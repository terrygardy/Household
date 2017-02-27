using Household.BL.DATA.t.Implementations;
using Household.Data.Context;
using Household.Data.Models.Base;
using System.Collections.Generic;

namespace Household.BL.Management.t.Interfaces
{
	public interface IShoppingListManagement : IManagementBase<t_ShoppingListItem, CShoppingListItemData>
	{
		List<t_ShoppingListItem> getShoppingList();
	}
}