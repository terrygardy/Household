using Household.BL.DATA.t.Implementations;
using Household.BL.Management.t.Interfaces;
using Household.Controllers.Base;
using Household.Data.Context;
using System.Web.Mvc;

namespace Household.Controllers
{
	public class ShoppingListController : CRUDController<t_ShoppingListItem, IShoppingListManagement, CShoppingListItemData>
	{
		public ShoppingListController(IShoppingListManagement management) : base(management)
		{
		}

		// GET: ShoppingList
		public ActionResult Index()
		{
			return View(Management.getShoppingList());
		}

		[HttpPost]
		public PartialViewResult Add(CShoppingListItemData shoppingListItem)
		{
			if (ModelState.IsValid)
			{
				Management.save(shoppingListItem);
			}

			return PartialView("_ShoppingListPartial", Management.getShoppingList());
		}
	}
}