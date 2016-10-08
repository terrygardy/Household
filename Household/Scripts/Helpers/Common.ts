module Common {

	interface ISearch {
		URL: string,
		TargetContainerSelector: string,
		GetSearchObjectFunc();
	}

	var m_strCoverId: string = "divContentCover";
	var m_strCoverSelector: string = "#" + m_strCoverId;
	var m_strInvisibleClass: string = "invisible";
	var m_iSearch: ISearch;

	class DateMultiplier {
		Multiplier: number;
		DMY: string;

		constructor(pv_intMultiplier: number, pv_strDMY: string) {
			this.Multiplier = pv_intMultiplier;
			this.DMY = pv_strDMY;
		}
	}

	export function GetSearchContainerClass(): string { return "searchContainer"; }
	export function GetSearchContainerClassSelector(): string { return "." + GetSearchContainerClass(); }
	export function GetSearchId(): string { return "divSearch"; }
	export function GetSearchSelector(): string { return "#" + GetSearchId(); }
	export function GetSearchButtonId(): string { return "btnSearch"; }
	export function GetSearchButtonSelector(): string { return "#" + GetSearchButtonId(); }
	export function GetSearchCancelButtonId(): string { return "btnSearchCancel"; }
	export function GetSearchCancelButtonSelector(): string { return "#" + GetSearchCancelButtonId(); }
	export function GetContainerId(): string { return "divContent"; }
	export function GetContainerSelector(): string { return "#" + GetContainerId(); }
	export function GetSubContainerSelector(): string { return "#divSubContent"; }

	export function LoadContentWithSelector(pv_strURL: string, pv_strSelector: string, pv_objData: any): void {
		LoadContentWithSelectorText(pv_strURL, pv_strSelector, pv_objData);
	}

	export function LoadContentWithSelectorText(pv_strURL: string, pv_strSelector: string, pv_objData: any): void {
		LoadContentWithSelectorAndType(pv_strURL, pv_strSelector, pv_objData, Helpers.HttpRequests.GetContentTypeText());
	}

	export function LoadContentWithSelectorJSON(pv_strURL: string, pv_strSelector: string, pv_objData: any): void {
		LoadContentWithSelectorAndType(pv_strURL, pv_strSelector, pv_objData, Helpers.HttpRequests.GetContentTypeJson());
	}

	export function LoadContentWithSelectorAndType(pv_strURL: string, pv_strSelector: string, pv_objData: any, pv_strContentType: string): void {
		showPleaseWait();
		$(pv_strSelector).empty();
		var objRequest: XMLHttpRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strURL, pv_strContentType);

		objRequest.send(pv_objData);

		$(pv_strSelector).empty().append(objRequest.response);

		stopPleaseWait();
	}

	export function LoadContent(pv_strURL: string): void {
		LoadContentWithSelector(pv_strURL, GetContainerSelector(), null);

		$('body').scrollTop(0).scrollLeft(0);
		$(GetContainerSelector()).scrollTop(0).scrollLeft(0);
		$(document).scrollTop(0).scrollLeft(0);
	}

	export function LoadSubContent(pv_strURL: string): void {
		LoadContentWithSelector(pv_strURL, GetSubContainerSelector(), null);
	}

	export function showSubContent(): void {
		showPleaseWait();
		$(GetSubContainerSelector()).removeClass(m_strInvisibleClass);
		resizeSubContent();
		resizeContentCover();

		window.onresize = function () {
			resizePleaseWait();
			resizeSubContent();
			resizeContentCover();
		};

		stopPleaseWait();
	}

	export function hideSubContent(): void {
		$(GetSubContainerSelector()).addClass(m_strInvisibleClass);
		deleteContentCover();
	}

	function showContentCover(): void {
		if ($(m_strCoverSelector).length < 1) {
			$('body').append('<div id="' + m_strCoverId + '"></div>');
		}
	}

	function resizeContentCover(): void {
		var intWidth: number, intHeight: number, intBodyWidth: number, intBodyHeight: number;

		deleteContentCover();

		if (($(GetSubContainerSelector()).length > 0) && (!$(GetSubContainerSelector()).hasClass(m_strInvisibleClass))) {
			showContentCover();

			intWidth = $(window).outerWidth();
			intHeight = $(window).outerHeight();
			intBodyWidth = $('body').outerWidth();
			intBodyHeight = $('body').outerHeight();

			if (intBodyHeight > intHeight) { intHeight = intBodyHeight; }
			if (intBodyWidth > intWidth) { intWidth = intBodyWidth; }

			$(m_strCoverSelector).css({
				'width': intWidth + 'px',
				'height': intHeight + 'px'
			});
		}
	}

	function deleteContentCover(): void { $(m_strCoverSelector).remove(); }

	function resizeSubContent() {
		var elSubContent: JQuery = $(GetSubContainerSelector());

		if ((elSubContent.length > 0) && (elSubContent.hasClass(m_strInvisibleClass) == false)) {
			var intTop: number = $(document).scrollTop() + 5;

			if (elSubContent.parent().parent().attr('id') == GetContainerId()) {

				if (intTop < 60) {
					intTop = 60;
				}
			}

			$(GetSubContainerSelector()).css({ 'top': intTop + 'px' });
		}
	}

	export function AddCharacterToText(pv_strText: string, pv_intPosition: number, pv_strCharacter: string) {
		return pv_strText.substr(0, pv_intPosition) + pv_strCharacter + pv_strText.substring(pv_intPosition);
	}

	export function ActivateSearchDiv(): void {
		var elSearch: JQuery;

		ToggleSearch();

		elSearch = $(GetSearchSelector());

		if (elSearch.length > 0) {
			elSearch.click(ToggleSearch);
		}
	}

	export function ActivateSearchButtons(): void {
		var elSearch: JQuery;

		elSearch = $(GetSearchButtonSelector());

		if (elSearch.length > 0) {
			elSearch.click(Search);
			elSearch.attr('title', elSearch.text());
		}

		elSearch = $(GetSearchCancelButtonSelector());

		if (elSearch.length > 0) {
			elSearch.click(ToggleSearch);
			elSearch.attr('title', elSearch.text());
		}
	}

	export function ToggleSearch(): void {
		var elSearch: JQuery = $(GetSearchContainerClassSelector());

		if (elSearch.hasClass(m_strInvisibleClass) === true) {
			elSearch.removeClass(m_strInvisibleClass);
			$(GetSearchSelector()).addClass(m_strInvisibleClass);
		} else {
			elSearch.addClass(m_strInvisibleClass);
			$(GetSearchSelector()).removeClass(m_strInvisibleClass);
		}
	}

	export function ActivateSearch(pv_strURL: string, pv_strTarget: string, pv_fnGetSearchObject: () => any): void {
		ActivateSearchDiv();

		ActivateSearchButtons();

		m_iSearch = {
			URL: pv_strURL,
			TargetContainerSelector: pv_strTarget,
			GetSearchObjectFunc: pv_fnGetSearchObject
		};
	}

	export function Search(): void {
		try {
			LoadContentWithSelectorJSON(m_iSearch.URL, m_iSearch.TargetContainerSelector, m_iSearch.GetSearchObjectFunc());

			ToggleSearch();
		}
		catch (ex) {
			alert('Error while searching: ' + ex);
		}

		stopPleaseWait();
	}

	export function FormatDate(pv_strDateString: string): string {
		var strReturn: string = "";

		if (pv_strDateString.length > 0) {
			if (pv_strDateString.indexOf("+") != -1) {
				var arr1: Array<string>;

				if (pv_strDateString.charAt(0) == "+") {
					strReturn = GetCurrentDateString();
				}

				strReturn = SplitDateByCharacterWithMultiplier(pv_strDateString, strReturn, ",");

				arr1 = strReturn.split(",");

				if (arr1[0].indexOf(".") != -1) {
					strReturn = SplitDateByCharacterWithMultiplier(arr1[0], strReturn, ".");
				} else {
					strReturn = SplitDateByCharacterWithMultiplier(strReturn, strReturn, ".");
				}
			} else {
				if (pv_strDateString.length < 4) {
					strReturn = SplitDateByCharacterWithMultiplier(pv_strDateString, strReturn, ".");
				}

				if (pv_strDateString.length == 4) {
					if (isNaN(Number(pv_strDateString)) == false) {
						var arr: Array<string> = [pv_strDateString.slice(0, 2), pv_strDateString.slice(2, 4), new Date().getFullYear().toString()];
						strReturn = ConvertDate(arr, strReturn, new DateMultiplier(0, "d"));
					}
				}

				if (pv_strDateString.length == 6) {
					if (isNaN(Number(pv_strDateString)) == false) {
						var arr: Array<string> = new Array(pv_strDateString.slice(0, 2), pv_strDateString.slice(2, 4), (20 + Number(pv_strDateString.slice(4, 6))).toString());
						strReturn = ConvertDate(arr, strReturn, new DateMultiplier(0, "d"));
					}
				}

				if (pv_strDateString.length == 8) {
					if (isNaN(Number(pv_strDateString)) == false) {
						var arr: Array<string> = new Array(pv_strDateString.slice(0, 2), pv_strDateString.slice(2, 4), pv_strDateString.slice(4, 8));
						strReturn = ConvertDate(arr, strReturn, new DateMultiplier(0, "d"));
					}
				}

				strReturn = SplitDateByCharacter(pv_strDateString, strReturn, ",");
				strReturn = SplitDateByCharacter(pv_strDateString, strReturn, ".");
			}
		}

		return strReturn;
	}

	function ConvertDate(pv_arrDate: Array<string>, pv_strDateString: string, pv_dmMultiplier: DateMultiplier): string {
		var strErrorMessage = "Please check your entry: \n '01.09.2015' or '1.9.15' or '1,9,2015'";

		if (pv_arrDate.length != 3) {
			alert(strErrorMessage);
			return pv_strDateString;
		} else {
			var i: number;
			var intYear: number;
			var datDate: Date;
			var intTemp: number;

			for (i = 0; i < pv_arrDate.length; i++) {
				if (isNaN(Number(pv_arrDate[i]))) {
					alert(strErrorMessage);
					return pv_strDateString;
				}
			}

			//Day
			if (pv_arrDate[0].length < 2) {
				pv_arrDate[0] = "0" + pv_arrDate[0];
			} else {
				if (Number(pv_arrDate[0]) > 31) {
					alert(strErrorMessage);
					return pv_strDateString;
				}
			}

			//Month
			if (pv_arrDate[1].length < 2) {
				pv_arrDate[1] = "0" + pv_arrDate[1];
			} else {
				if (Number(pv_arrDate[1]) > 12) {
					alert(strErrorMessage);
					return pv_strDateString;
				}
			}

			//Year
			if (pv_arrDate[2] == "") {
				pv_arrDate[2] = new Date().getFullYear().toString();
			}

			intYear = Number(pv_arrDate[2]);

			if (isNaN(intYear) == false) {
				if ((intYear < 100) && (intYear >= 0)) {
					intYear = 2000 + intYear;
					pv_arrDate[2] = intYear.toString();
				} else {
					if ((intYear >= 1753) && (intYear < 9999)) {
						intYear = intYear;
					} else {
						alert(strErrorMessage);
						return pv_strDateString;
					}
				}
			} else {
				alert(strErrorMessage);
				return pv_strDateString;
			}

			switch (pv_dmMultiplier.DMY) {
				case "m":
					datDate = new Date(Number(pv_arrDate[2]), Number(pv_arrDate[1]) - 1 + pv_dmMultiplier.Multiplier, Number(pv_arrDate[0]));
					break;
				case "y":
					datDate = new Date(Number(pv_arrDate[2]) + pv_dmMultiplier.Multiplier, Number(pv_arrDate[1]) - 1, Number(pv_arrDate[0]));
					break;
				default:
					datDate = new Date(Number(pv_arrDate[2]), Number(pv_arrDate[1]) - 1, Number(pv_arrDate[0]) + pv_dmMultiplier.Multiplier);
					break;
			}

			pv_strDateString = "";
			intTemp = datDate.getDate();

			if (intTemp < 10) {
				pv_strDateString += "0" + intTemp.toString();
			} else {
				pv_strDateString += intTemp.toString();
			}

			pv_strDateString += ".";
			intTemp = datDate.getMonth() + 1;

			if (intTemp < 10) {
				pv_strDateString += "0" + intTemp.toString();
			} else {
				pv_strDateString += intTemp.toString();
			}

			pv_strDateString += "." + datDate.getFullYear().toString();
		}

		return pv_strDateString;
	}

	function GetDateMultiplier(pv_strDateString: string): DateMultiplier {
		var dmMultiP: DateMultiplier;

		switch (pv_strDateString.charAt(pv_strDateString.length - 1).toUpperCase()) {
			case "W":
				pv_strDateString.replace("W", "");
				dmMultiP = new DateMultiplier(7, "d")
				break;
			case "M":
				pv_strDateString.replace("M", "");
				dmMultiP = new DateMultiplier(1, "m")
				break;
			case "J":
				pv_strDateString.replace("J", "");
				dmMultiP = new DateMultiplier(1, "y")
				break;
			default:
				pv_strDateString.replace("T", "");
				dmMultiP = new DateMultiplier(1, "T")
				break;
		}

		return dmMultiP;
	}

	function GetDayWithLeadingZero(): string {
		var intDay: number = new Date().getDate();

		if (intDay < 10) {
			return "0" + intDay.toString();
		} else {
			return intDay.toString();
		}
	}

	function GetMonthWithLeadingZero(): string {
		var intMonth: number = new Date().getMonth();

		if ((intMonth + 1) < 10) {
			return "0" + (intMonth + 1).toString();
		} else {
			return (intMonth + 1).toString();
		}
	}

	function GetFullYear(): string {
		return new Date().getFullYear().toString();
	}

	function GetCurrentDateString(): string {
		return GetDayWithLeadingZero() + "." + GetMonthWithLeadingZero() + "." + GetFullYear();
	}

	function Multiply(pv_objValueA: any, pv_objValueB: any): number {
		var nmValueA: number = Number(pv_objValueA);
		var nmValueB: number = Number(pv_objValueB);

		if (!isNaN(nmValueA)) {
			if (!isNaN(nmValueB)) {
				return nmValueA * nmValueB;
			}
		}

		return 0;
	}

	function SplitDateByCharacter(pv_strDateString: string, pv_strReturnDate: string, pv_strCharacter: string): string {
		if (pv_strDateString.indexOf(pv_strCharacter) != -1) {
			var arr: Array<string> = pv_strDateString.split(pv_strCharacter);

			if (arr.length == 2) {
				pv_strDateString += pv_strCharacter;
				arr = pv_strDateString.split(pv_strCharacter);
			}

			return ConvertDate(arr, pv_strReturnDate, new DateMultiplier(0, "d"));
		}
	}

	function SplitDateByCharacterWithMultiplier(pv_strDateString: string, pv_strReturnDate: string, pv_strCharacter: string): string {
		var dmMulti: DateMultiplier = GetDateMultiplier(pv_strDateString);
		var arr1: Array<string> = pv_strDateString.split("+");

		if (arr1[0].indexOf(pv_strCharacter) != -1) {
			var arr: Array<string> = arr1[0].split(pv_strCharacter);

			if (arr.length == 2) {
				arr1[0] += pv_strCharacter;
				arr = arr1[0].split(pv_strCharacter);
			}

			dmMulti.Multiplier = Multiply(dmMulti.Multiplier, arr1[1]);

			return ConvertDate(arr, pv_strReturnDate, dmMulti);
		}
	}
}