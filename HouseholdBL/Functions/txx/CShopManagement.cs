using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx;
using Household.BL.Functions.Management.txx;
using Household.Data.Db;

namespace Household.BL.Functions.txx
{
	public class CShopManagement : CManagementBase<txx_Shop, string, string, CShopData>, IShopManagement
	{
		public CShopManagement(IDb db)
		: base(db) { }

		protected override Expression<Func<txx_Shop, string>> getStandardOrderBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<txx_Shop, string>> getStandardThenBy()
		{
			return x => x.Description;
		}

		protected override void deleteAllowed(txx_Shop pv_cEntity)
		{
			if (Db.GetGenericRepository<t_Purchase>().Where(x => x.Shop_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Shop.InUsePurchase);

			base.deleteAllowed(pv_cEntity);
		}

		public IEnumerable<txx_Shop> getShops()
		{
			return getEntities(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}