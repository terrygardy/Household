/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../typings/highcharts/highcharts.d.ts" />
/// <reference path="../highcharts/highcharts.helpers.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="../Helpers/HttpRequest.ts" />
var Report;
(function (Report) {
    var Return = (function () {
        function Return() {
        }
        return Return;
    }());
    /*
     Shop Comparison
     */
    function RunCompareShop(pv_strContainerID, pv_strActionURL, pv_arrShops, pv_intYear) {
        var arrSeries = new Array();
        for (var i = 0; i < pv_arrShops.length; i++) {
            arrSeries.push(GetSeriesInfoShop(pv_strActionURL + "?id=" + pv_arrShops[i] + "&year=" + pv_intYear));
        }
        StartCompareShop(pv_strContainerID, arrSeries);
    }
    Report.RunCompareShop = RunCompareShop;
    function StartCompareShop(pv_strContainerID, pv_arrSeries) {
        var chart = {};
        var tooltip = {};
        var plotOptions = {};
        var hcAxis = new Highcharts_Helpers.Axis();
        chart.type = new Highcharts_Helpers.ChartType().getArea();
        chart.zoomType = "xy";
        chart.renderTo = pv_strContainerID;
        tooltip.valueSuffix = '€';
        plotOptions.area = {};
        plotOptions.area.pointStart = 0;
        plotOptions.area.marker = new Highcharts_Helpers.Marker().GetCircle();
        Start(pv_strContainerID, chart, new Highcharts_Helpers.Title().GetBasic("Shop Comparison"), new Highcharts_Helpers.Subtitle().GetStandardSubtitle(), hcAxis.GetAxisMonths(), hcAxis.GetAxisEuro(), tooltip, plotOptions, pv_arrSeries);
    }
    function GetSeriesInfoShop(pv_strActionURL) {
        return GetSeriesInfo(pv_strActionURL);
    }
    /*
     Year Comparison
     */
    function RunCompareYear(pv_strContainerID, pv_strActionURL, pv_arrYears) {
        var arrSeries = new Array();
        var arrData = new Array();
        for (var i = 0; i < pv_arrYears.length; i++) {
            var objOptions = GetSeriesInfoYear(pv_strActionURL + "?year=" + pv_arrYears[i]);
            arrData.push(objOptions.data);
        }
        var hhSeries = new Highcharts_Helpers.Series();
        arrSeries.push(hhSeries.BuildSeries("Year", null, arrData, null, hhSeries.BuildDataLabels("right", false, "", "", "#FFFFFF", true, "{point.y:.1f}", -90, new Highcharts_Helpers.Style().BuildCssObject("", "", "", "", "", "Verdana, sans-serif", "13px", "", "", -1, "", "", "", ""), -1, 10)));
        StartCompareYear(pv_strContainerID, arrSeries, pv_arrYears);
    }
    Report.RunCompareYear = RunCompareYear;
    function StartCompareYear(pv_strContainerID, pv_arrSeries, pv_arrYears) {
        var chart = {};
        var tooltip = {};
        var plotOptions = {};
        var hcAxis = new Highcharts_Helpers.Axis();
        chart.type = new Highcharts_Helpers.ChartType().getColumn();
        chart.zoomType = "xy";
        chart.renderTo = pv_strContainerID;
        tooltip.valueSuffix = '€';
        plotOptions.area = {};
        plotOptions.area.pointStart = 0;
        plotOptions.area.marker = new Highcharts_Helpers.Marker().GetCircle();
        Start(pv_strContainerID, chart, new Highcharts_Helpers.Title().GetBasic("Year Comparison"), new Highcharts_Helpers.Subtitle().GetStandardSubtitle(), hcAxis.GetAxis("Year", "category", false, null, pv_arrYears), hcAxis.GetAxisEuro(), tooltip, plotOptions, pv_arrSeries);
    }
    function GetSeriesInfoYear(pv_strActionURL) {
        return GetSeriesInfo(pv_strActionURL);
    }
    function GetSeriesInfo(pv_strActionURL) {
        var objRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strActionURL, Helpers.HttpRequests.GetContentTypeJson());
        var objReturn;
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
    function Start(pv_strContainerID, pv_objChart, pv_objTitle, pv_objSubtitle, pv_objXAxis, pv_objYAxis, pv_objTooltip, pv_objPlotOptions, pv_arrSeries) {
        var objOptions = {};
        var elCon = $("#" + pv_strContainerID);
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
})(Report || (Report = {}));
//# sourceMappingURL=Report.js.map