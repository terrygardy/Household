/// <reference path="../typings/highcharts/highcharts.d.ts" />
var Highcharts_Helpers;
(function (Highcharts_Helpers) {
    var ChartType = (function () {
        function ChartType() {
        }
        ChartType.prototype.getArea = function () {
            return "area";
        };
        ChartType.prototype.getBar = function () {
            return "bar";
        };
        ChartType.prototype.getColumn = function () {
            return "column";
        };
        ChartType.prototype.getLine = function () {
            return "line";
        };
        ChartType.prototype.getPie = function () {
            return "pie";
        };
        ChartType.prototype.getScatter = function () {
            return "scatter";
        };
        ChartType.prototype.getSpline = function () {
            return "spline";
        };
        return ChartType;
    }());
    Highcharts_Helpers.ChartType = ChartType;
    var Marker = (function () {
        function Marker() {
        }
        Marker.prototype.GetCircle = function () {
            var hcMarker = {};
            hcMarker.enabled = false;
            hcMarker.symbol = 'circle';
            hcMarker.radius = 2;
            hcMarker.states = {};
            hcMarker.states.hover = {};
            hcMarker.states.hover.enabled = true;
            return hcMarker = {};
        };
        return Marker;
    }());
    Highcharts_Helpers.Marker = Marker;
    var Axis = (function () {
        function Axis() {
        }
        Axis.prototype.GetAxis = function (pv_strTitleText, pv_strAxisType, pv_blnAllowDecimals, pv_fnFormatter, pv_arrCategories) {
            var axis = {};
            if (pv_strTitleText.length > 0) {
                axis.title = {};
                axis.title.text = pv_strTitleText;
            }
            if (pv_strAxisType.length > 0) {
                axis.type = pv_strAxisType;
            }
            axis.allowDecimals = pv_blnAllowDecimals;
            if (pv_fnFormatter != null) {
                axis.labels = {};
                axis.labels.formatter = pv_fnFormatter;
            }
            if ((pv_arrCategories != null) && (pv_arrCategories.length > 0)) {
                axis.categories = pv_arrCategories;
            }
            return axis;
        };
        Axis.prototype.GetAxisEuro = function () {
            return this.GetAxis("Amount", "decimal", true, function () {
                return this.value + "€";
            }, null);
        };
        Axis.prototype.GetAxisMonths = function () {
            return this.GetAxis("", "", false, null, this.GetMonths());
        };
        Axis.prototype.GetMonths = function () {
            return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
        };
        return Axis;
    }());
    Highcharts_Helpers.Axis = Axis;
    var Subtitle = (function () {
        function Subtitle() {
        }
        Subtitle.prototype.GetBasic = function (pv_strSubtitle) {
            var subtitle = {};
            subtitle.text = pv_strSubtitle;
            return subtitle;
        };
        Subtitle.prototype.GetStandardSubtitle = function () {
            return this.GetBasic("Household Chart");
        };
        return Subtitle;
    }());
    Highcharts_Helpers.Subtitle = Subtitle;
    var Title = (function () {
        function Title() {
        }
        Title.prototype.GetBasic = function (pv_strTitle) {
            var title = {};
            title.text = pv_strTitle;
            return title;
        };
        return Title;
    }());
    Highcharts_Helpers.Title = Title;
    var Series = (function () {
        function Series() {
        }
        Series.prototype.BuildSeries = function (pv_strName, pv_arrData, pv_lstData, pv_dicData, pv_hcLabels) {
            var hcSeries = {};
            if (pv_strName.length > 0) {
                hcSeries.name = pv_strName;
            }
            if (pv_arrData != null) {
                hcSeries.data = pv_arrData;
            }
            if (pv_lstData != null) {
                hcSeries.data = pv_lstData;
            }
            if (pv_hcLabels != null) {
                hcSeries.dataLabels = pv_hcLabels;
            }
            return hcSeries;
        };
        Series.prototype.BuildDataLabels = function (pv_strAlign, pv_blnAllowOverlap, pv_strBackgroundColor, pv_strBorderColor, pv_strColor, pv_blnEnabled, pv_strFormat, pv_intRotation, pv_hcStyle, pv_intX, pv_intY) {
            var hcLabels = {};
            if (pv_strAlign.length > 0) {
                hcLabels.align = pv_strAlign;
            }
            if (pv_blnAllowOverlap === true) {
                hcLabels.allowOverlap = pv_blnAllowOverlap;
            }
            if (pv_strBackgroundColor.length > 0) {
                hcLabels.backgroundColor = pv_strBackgroundColor;
            }
            if (pv_strBorderColor.length > 0) {
                hcLabels.borderColor = pv_strBorderColor;
            }
            if (pv_strColor.length > 0) {
                hcLabels.color = pv_strColor;
            }
            if (pv_blnEnabled === true) {
                hcLabels.enabled = pv_blnEnabled;
            }
            if (pv_strFormat.length > 0) {
                hcLabels.format = pv_strFormat;
            }
            if (pv_intRotation !== 0) {
                hcLabels.rotation = pv_intRotation;
            }
            if (pv_hcStyle != null) {
                hcLabels.style = pv_hcStyle;
            }
            if (pv_intX !== -1) {
                hcLabels.x = pv_intX;
            }
            if (pv_intY !== -1) {
                hcLabels.y = pv_intY;
            }
            return hcLabels;
        };
        return Series;
    }());
    Highcharts_Helpers.Series = Series;
    var Style = (function () {
        function Style() {
        }
        Style.prototype.BuildCssObject = function (pv_strBackground, pv_strBorder, pv_strColour, pv_strCursor, pv_strFont, pv_strFontFamily, pv_strFontSize, pv_strFontWeight, pv_strLeft, pv_intOpacity, pv_strPadding, pv_strPosition, pv_strTextShadow, pv_strTop) {
            var hcCSS = {};
            if (pv_strBackground.length > 0) {
                hcCSS.background = pv_strBackground;
            }
            if (pv_strBorder.length > 0) {
                hcCSS.border = pv_strBorder;
            }
            if (pv_strColour.length > 0) {
                hcCSS.color = pv_strColour;
            }
            if (pv_strCursor.length > 0) {
                hcCSS.cursor = pv_strCursor;
            }
            if (pv_strFont.length > 0) {
                hcCSS.font = pv_strFont;
            }
            if (pv_strFontFamily.length > 0) {
                hcCSS.fontFamily = pv_strFontFamily;
            }
            if (pv_strFontSize.length > 0) {
                hcCSS.fontSize = pv_strFontSize;
            }
            if (pv_strFontWeight.length > 0) {
                hcCSS.fontWeight = pv_strFontWeight;
            }
            if (pv_strLeft.length > 0) {
                hcCSS.left = pv_strLeft;
            }
            if (pv_intOpacity != -1) {
                hcCSS.opacity = pv_intOpacity;
            }
            if (pv_strPadding.length > 0) {
                hcCSS.padding = pv_strPadding;
            }
            if (pv_strPosition.length > 0) {
                hcCSS.position = pv_strPosition;
            }
            if (pv_strTextShadow.length > 0) {
                hcCSS.textShadow = pv_strTextShadow;
            }
            if (pv_strTop.length > 0) {
                hcCSS.top = pv_strTop;
            }
            return hcCSS;
        };
        return Style;
    }());
    Highcharts_Helpers.Style = Style;
})(Highcharts_Helpers || (Highcharts_Helpers = {}));
//# sourceMappingURL=highcharts.helpers.js.map