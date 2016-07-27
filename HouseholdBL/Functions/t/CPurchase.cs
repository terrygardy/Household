using Household.Data.Context;
using Household.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Helpers.Exceptions;
using Household.Data.Text.Error;
using Household.BL.DATA.t;
using Household.BL.Returns;

namespace Household.BL.Functions.t
{
	public class CPurchase : CModelBase<t_Purchase, DateTime, string, CPurchaseData>
	{
		public CPurchase(Database pv_dmHH_DB) : base(pv_dmHH_DB) { }

		public override void validate(t_Purchase pv_cEntity)
		{
			if (pv_cEntity.Occurrence <= MinDate) throw new ValidationException(Purchase.EnterDate);
			if (pv_cEntity.Occurrence > DateTime.Now) throw new ValidationException(Purchase.DateInFuture);

			if (pv_cEntity.Amount < 0) throw new ValidationException(Purchase.EnterAmount);
			if (pv_cEntity.Payer_ID == 0) throw new ValidationException(Purchase.EnterPayer);
			if ((pv_cEntity.Shop_ID == 0) && (string.IsNullOrEmpty(pv_cEntity.Description))) { throw new ValidationException(Purchase.EnterShopOrDescription); }
		}

		protected override Expression<Func<t_Purchase, DateTime>> getStandardOrderBy()
		{
			return x => x.Occurrence;
		}

		protected override Expression<Func<t_Purchase, string>> getStandardThenBy()
		{
			return x => x.txx_Shop.Name;
		}

		protected override Expression<Func<t_Purchase, bool>> getStandardWhereID(long pv_lngID)
		{
			return x => x.ID == pv_lngID;
		}

		public List<CShopChartInfo> getPurchaseInfoForShopChart(long pv_lngShop, int pv_intYear)
		{
			return Database.t_Purchase.Where(x => x.Shop_ID == pv_lngShop && x.Occurrence.Year == pv_intYear)
										.GroupBy(x => x.Occurrence.Month)
										.Select(x =>
											new CShopChartInfo
											{
												Integer = x.Key,
												Decimal = x.Sum(w => w.Amount)
											})
											.OrderBy(x => x.Integer).ToList();
			//return base.getEntities(x => x.Shop_ID == pv_lngShop && x.Occurrence.Year == pv_intYear, x => x.Occurrence.Month, getStandardThenBy());
		}

		public decimal getSumByYear(int pv_intYear)
		{
			var lstPurchases = Database.t_Purchase.Where(x => x.Occurrence.Year == pv_intYear).ToList();

			if (lstPurchases.Count > 0)
			{
				return lstPurchases.Sum(x => x.Amount);
			}
			else
			{
				return 0;
			}
		}

		public List<t_Purchase> getPurchases()
		{
			return getPurchases(null);
		}

		public List<t_Purchase> getPurchases(Expression<Func<t_Purchase, bool>> pv_exWhere)
		{
			return base.getEntities(pv_exWhere, getStandardOrderBy(), getStandardThenBy());
		}
	}
}
