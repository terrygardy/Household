using System;
using Household.Models.Chart;
using System.Web.Mvc;
using WebHelpers;

namespace Household.Controllers
{
	public class ReportController : Controller
	{
		[HttpPost]
		public string CompareShopInfo(long id, int year)
		{
			CReturn objReturn;

			try
			{
				objReturn = new CReturn() { Message = "", Return = new Models.Finance.CReportsModel().GetShopCompareChartInfo(id, year) };
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
				objReturn = new CReturn() { Message = "", Return = new Models.Finance.CReportsModel().GetYearCompareChartInfo(year) };
			}
			catch (Exception ex)
			{
				objReturn = new CReturn() { Message = ex.Message, Return = null };
			}

			return JSON.serialiseObject(objReturn);
		}
	}
}