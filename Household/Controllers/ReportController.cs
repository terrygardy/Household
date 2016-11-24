using System;
using Household.Models.Chart;
using System.Web.Mvc;
using WebHelpers;
using Household.BL.Management.txx.Interfaces;
using Household.BL.Management.t.Interfaces;

namespace Household.Controllers
{
	public class ReportController : Controller
	{
		private readonly IShopManagement _shopManagement;
		private readonly IPurchaseManagement _purchaseManagement;

		public ReportController(IShopManagement shopManagement,
			IPurchaseManagement purchaseManagement)
		{
			_shopManagement = shopManagement;
			_purchaseManagement = purchaseManagement;
		}

		[HttpPost]
		public string CompareShopInfo(long id, int year)
		{
			CReturn objReturn;

			try
			{
				objReturn = new CReturn() { Message = "", Return = new Models.Finance.CReportsModel(_shopManagement).GetShopCompareChartInfo(_purchaseManagement, id, year) };
			}
			catch (Exception ex)
			{
				objReturn = new CReturn() { Message = ex.Message, Return = null };
			}

			return JSON.serialiseObject(objReturn);
		}

		[HttpPost]
		public string CompareYearInfo(int year)
		{
			CReturn objReturn;

			try
			{
				objReturn = new CReturn() { Message = "", Return = new Models.Finance.CReportsModel(_shopManagement).GetYearCompareChartInfo(_purchaseManagement, year) };
			}
			catch (Exception ex)
			{
				objReturn = new CReturn() { Message = ex.Message, Return = null };
			}

			return JSON.serialiseObject(objReturn);
		}
	}
}