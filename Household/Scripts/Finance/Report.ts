/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/highcharts/highcharts.d.ts" />
/// <reference path="../highcharts/highcharts.helpers.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="../Helpers/HttpRequest.ts" />

module Report {
	class Return {
		Message: string;
		Return: any;
	}

	/*
	 Shop Comparison
	 */
	export function RunCompareShop(pv_strContainerID: string, pv_strActionURL: string, pv_arrShops: Array<number>, pv_intYear: number): void {
		var arrSeries: HighchartsSeriesOptions[] = new Array();

		for (var i: number = 0; i < pv_arrShops.length; i++) {
			arrSeries.push(GetSeriesInfoShop(pv_strActionURL + "?id=" + pv_arrShops[i] + "&year=" + pv_intYear));
		}

		StartCompareShop(pv_strContainerID, arrSeries);
	}

	function StartCompareShop(pv_strContainerID: string, pv_arrSeries: HighchartsSeriesOptions[]): void {
		var chart: HighchartsChartOptions = {};
		var tooltip: HighchartsTooltipOptions = {};
		var plotOptions: HighchartsPlotOptions = {};
		var hcAxis: Highcharts_Helpers.Axis = new Highcharts_Helpers.Axis();

		chart.type = new Highcharts_Helpers.ChartType().getArea();
		chart.zoomType = "xy";
		chart.renderTo = pv_strContainerID;

		tooltip.valueSuffix = '€';

		plotOptions.area = {};
		plotOptions.area.pointStart = 0;
		plotOptions.area.marker = new Highcharts_Helpers.Marker().GetCircle();

		Start(pv_strContainerID, chart, new Highcharts_Helpers.Title().GetBasic("Shop Comparison"),
			new Highcharts_Helpers.Subtitle().GetStandardSubtitle(),
			hcAxis.GetAxisMonths(), hcAxis.GetAxisEuro(), tooltip, plotOptions, pv_arrSeries);
	}

	function GetSeriesInfoShop(pv_strActionURL: string): HighchartsSeriesOptions {
		return GetSeriesInfo(pv_strActionURL);
	}

	/*
	 Year Comparison
	 */
	export function RunCompareYear(pv_strContainerID: string, pv_strActionURL: string, pv_arrYears: Array<number>): void {
		var arrSeries: HighchartsSeriesOptions[] = new Array();
		var arrData: Array<any> = new Array();

		for (var i: number = 0; i < pv_arrYears.length; i++) {
			var objOptions: HighchartsSeriesOptions = GetSeriesInfoYear(pv_strActionURL + "?year=" + pv_arrYears[i]);

			arrData.push(objOptions.data);
		}

		var hhSeries: Highcharts_Helpers.Series = new Highcharts_Helpers.Series();

		arrSeries.push(hhSeries.BuildSeries("Year", null, arrData, null, hhSeries.BuildDataLabels("right", false, "", "", "#FFFFFF", true, "{point.y:.1f}", -90,
			new Highcharts_Helpers.Style().BuildCssObject("", "", "", "", "", "Verdana, sans-serif", "13px", "", "", -1, "", "", "", ""),
			-1, 10)));

		StartCompareYear(pv_strContainerID, arrSeries, pv_arrYears);
	}

	function StartCompareYear(pv_strContainerID: string, pv_arrSeries: HighchartsSeriesOptions[], pv_arrYears: Array<number>): void {
		var chart: HighchartsChartOptions = {};
		var tooltip: HighchartsTooltipOptions = {};
		var plotOptions: HighchartsPlotOptions = {};
		var hcAxis: Highcharts_Helpers.Axis = new Highcharts_Helpers.Axis();

		chart.type = new Highcharts_Helpers.ChartType().getColumn();
		chart.zoomType = "xy";
		chart.renderTo = pv_strContainerID;

		tooltip.valueSuffix = '€';

		plotOptions.area = {};
		plotOptions.area.pointStart = 0;
		plotOptions.area.marker = new Highcharts_Helpers.Marker().GetCircle();

		Start(pv_strContainerID, chart,
			new Highcharts_Helpers.Title().GetBasic("Year Comparison"),
			new Highcharts_Helpers.Subtitle().GetStandardSubtitle(),
			hcAxis.GetAxis("Year", "category", false, null, pv_arrYears),
			hcAxis.GetAxisEuro(), tooltip, plotOptions, pv_arrSeries);
	}

	function GetSeriesInfoYear(pv_strActionURL: string): HighchartsSeriesOptions {
		return GetSeriesInfo(pv_strActionURL);
	}

	function GetSeriesInfo(pv_strActionURL: string): HighchartsSeriesOptions {
		var objRequest: XMLHttpRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strActionURL, Helpers.HttpRequests.GetContentTypeJson());
		var objReturn: Return;

		objRequest.send();
		objReturn = JSON.parse(objRequest.response);

		if (objReturn.Message.length > 0) {
			alert(objReturn.Message);
			return null;
		}
		else {
			return objReturn.Return;
		}
	}

	function Start(pv_strContainerID: string, pv_objChart: HighchartsChartOptions, pv_objTitle: HighchartsTitleOptions,
		pv_objSubtitle: HighchartsSubtitleOptions, pv_objXAxis: HighchartsAxisOptions, pv_objYAxis: HighchartsAxisOptions,
		pv_objTooltip: HighchartsTooltipOptions, pv_objPlotOptions: HighchartsPlotOptions, pv_arrSeries: HighchartsSeriesOptions[]): void {
		var objOptions: HighchartsOptions = {};
		var elCon: JQuery = $("#" + pv_strContainerID);

		objOptions.chart = pv_objChart;
		objOptions.title = pv_objTitle;
		objOptions.subtitle = pv_objSubtitle;
		objOptions.xAxis = pv_objXAxis;
		objOptions.yAxis = pv_objYAxis;
		objOptions.tooltip = pv_objTooltip;
		objOptions.plotOptions = pv_objPlotOptions;
		objOptions.series = pv_arrSeries;

		elCon.empty();

		elCon.add('<div id="divHighcharts" style="width: 100%"></div>').highcharts(objOptions);
	}
}