/// <reference path="../typings/highcharts/highcharts.d.ts" />

module Highcharts_Helpers {
	export class ChartType {
		getArea(): string {
			return "area";
		}

		getBar(): string {
			return "bar";
		}

		getColumn(): string {
			return "column";
		}

		getLine(): string {
			return "line";
		}

		getPie(): string {
			return "pie";
		}

		getScatter(): string {
			return "scatter";
		}

		getSpline(): string {
			return "spline";
		}
	}

	export class Marker {
		GetCircle(): HighchartsMarker {
			var hcMarker: HighchartsMarker = {};

			hcMarker.enabled = false;
			hcMarker.symbol = 'circle';
			hcMarker.radius = 2;
			hcMarker.states = {};
			hcMarker.states.hover = {};
			hcMarker.states.hover.enabled = true;

			return hcMarker = {};
		}
	}

	export class Axis {
		GetAxis(pv_strTitleText: string, pv_strAxisType: string,
			pv_blnAllowDecimals: boolean, pv_fnFormatter: any, pv_arrCategories: Array<any>): HighchartsAxisOptions {
			var axis: HighchartsAxisOptions = {};

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
		}

		GetAxisEuro(): HighchartsAxisOptions {
			return this.GetAxis("Amount", "decimal", true, function () {
				return this.value + "€";
			}, null);
		}

		GetAxisMonths(): HighchartsAxisOptions {
			return this.GetAxis("", "", false, null, this.GetMonths());
		}

		GetMonths(): Array<string> {
			return ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
		}
	}

	export class Subtitle {
		GetBasic(pv_strSubtitle: string): HighchartsSubtitleOptions {
			var subtitle: HighchartsSubtitleOptions = {};
			subtitle.text = pv_strSubtitle;

			return subtitle;
		}

		GetStandardSubtitle(): HighchartsSubtitleOptions {
			return this.GetBasic("Household Chart");
		}
	}

	export class Title {
		GetBasic(pv_strTitle: string): HighchartsTitleOptions {
			var title: HighchartsTitleOptions = {};
			title.text = pv_strTitle;

			return title;
		}
	}

	export class Series {
		BuildSeries(pv_strName: string, pv_arrData: number[], pv_lstData: [string, number][], pv_dicData: [number, number][], pv_hcLabels: HighchartsDataLabels): HighchartsSeriesOptions {
			var hcSeries: HighchartsSeriesOptions = {};

			if (pv_strName.length > 0) { hcSeries.name = pv_strName; }
			if (pv_arrData != null) { hcSeries.data = pv_arrData; }
			if (pv_lstData != null) { hcSeries.data = pv_lstData; }
			if (pv_hcLabels != null) { hcSeries.dataLabels = pv_hcLabels; }

			return hcSeries;
		}

		BuildDataLabels(pv_strAlign: string, pv_blnAllowOverlap: boolean, pv_strBackgroundColor: string, pv_strBorderColor: string,
			pv_strColor: string, pv_blnEnabled: boolean, pv_strFormat: string, pv_intRotation: number, pv_hcStyle: HighchartsCSSObject,
			pv_intX: number, pv_intY: number): HighchartsDataLabels {
			var hcLabels: HighchartsDataLabels = {};

			if (pv_strAlign.length > 0) { hcLabels.align = pv_strAlign; }
			if (pv_blnAllowOverlap === true) { hcLabels.allowOverlap = pv_blnAllowOverlap; }
			if (pv_strBackgroundColor.length > 0) { hcLabels.backgroundColor = pv_strBackgroundColor; }
			if (pv_strBorderColor.length > 0) { hcLabels.borderColor = pv_strBorderColor; }
			if (pv_strColor.length > 0) { hcLabels.color = pv_strColor; }
			if (pv_blnEnabled === true) { hcLabels.enabled = pv_blnEnabled; }
			if (pv_strFormat.length > 0) { hcLabels.format = pv_strFormat; }
			if (pv_intRotation !== 0) { hcLabels.rotation = pv_intRotation; }
			if (pv_hcStyle != null) { hcLabels.style = pv_hcStyle; }
			if (pv_intX !== -1) { hcLabels.x = pv_intX; }
			if (pv_intY !== -1) { hcLabels.y = pv_intY; }

			return hcLabels;
		}
	}

	export class Style {
		BuildCssObject(pv_strBackground: string, pv_strBorder: string, pv_strColour: string, pv_strCursor: string, pv_strFont: string,
			pv_strFontFamily: string, pv_strFontSize: string, pv_strFontWeight: string, pv_strLeft: string, pv_intOpacity: number,
			pv_strPadding: string, pv_strPosition: string, pv_strTextShadow: string, pv_strTop: string): HighchartsCSSObject {
			var hcCSS: HighchartsCSSObject = {};

			if (pv_strBackground.length > 0) { hcCSS.background = pv_strBackground; }
			if (pv_strBorder.length > 0) { hcCSS.border = pv_strBorder; }
			if (pv_strColour.length > 0) { hcCSS.color = pv_strColour; }
			if (pv_strCursor.length > 0) { hcCSS.cursor = pv_strCursor; }
			if (pv_strFont.length > 0) { hcCSS.font = pv_strFont; }
			if (pv_strFontFamily.length > 0) { hcCSS.fontFamily = pv_strFontFamily; }
			if (pv_strFontSize.length > 0) { hcCSS.fontSize = pv_strFontSize; }
			if (pv_strFontWeight.length > 0) { hcCSS.fontWeight = pv_strFontWeight; }
			if (pv_strLeft.length > 0) { hcCSS.left = pv_strLeft; }
			if (pv_intOpacity != -1) { hcCSS.opacity = pv_intOpacity; }
			if (pv_strPadding.length > 0) { hcCSS.padding = pv_strPadding; }
			if (pv_strPosition.length > 0) { hcCSS.position = pv_strPosition; }
			if (pv_strTextShadow.length > 0) { hcCSS.textShadow = pv_strTextShadow; }
			if (pv_strTop.length > 0) { hcCSS.top = pv_strTop; }

			return hcCSS;
		}
	}
}