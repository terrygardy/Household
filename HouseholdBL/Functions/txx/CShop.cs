using System;
using System.Linq;
using System.Linq.Expressions;
using Household.Data.Context;
using Household.Data.Models.Base;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using System.Collections.Generic;
using Household.BL.DATA.txx;

namespace Household.BL.Functions.txx
{
	public class CShop : CModelBase<txx_Shop, string, string, CShopData>
	{
		public CShop() { }

		public override void validate(txx_Shop pv_cEntity)
		{
			if (string.IsNullOrEmpty(pv_cEntity.Name)) { throw new ValidationException(Shop.EnterName); }

			if (getModel(x => string.Compare(x.Name, pv_cEntity.Name, true) == 0 && x.ID != pv_cEntity.ID) != null) { throw new ValidationException(Shop.NameExists); }
		}

		protected override Expression<Func<txx_Shop, string>> getStandardOrderBy()
		{
			return x => x.Name;
		}

		protected override Expression<Func<txx_Shop, string>> getStandardThenBy()
		{
			return x => x.Description;
		}

		protected override Expression<Func<txx_Shop, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		protected override void deleteAllowed(txx_Shop pv_cEntity)
		{
			if (Database.t_Purchase.Where(x => x.Shop_ID == pv_cEntity.ID).Count() > 0) throw new DeleteNotAllowedException(Shop.InUsePurchase);

			base.deleteAllowed(pv_cEntity);
		}

		public List<txx_Shop> getShops()
		{
			return getEntities<string, string>(null, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
