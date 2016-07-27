var Common;
(function (Common) {
    var m_strCoverId = "divContentCover";
    var m_strCoverSelector = "#" + m_strCoverId;
    var m_strInvisibleClass = "invisible";
    var DateMultiplier = (function () {
        function DateMultiplier(pv_intMultiplier, pv_strDMY) {
            this.Multiplier = pv_intMultiplier;
            this.DMY = pv_strDMY;
        }
        return DateMultiplier;
    }());
    function GetSearchContainerClass() { return "searchContainer"; }
    Common.GetSearchContainerClass = GetSearchContainerClass;
    function GetSearchContainerClassSelector() { return "." + GetSearchContainerClass(); }
    Common.GetSearchContainerClassSelector = GetSearchContainerClassSelector;
    function GetSearchId() { return "divSearch"; }
    Common.GetSearchId = GetSearchId;
    function GetSearchSelector() { return "#" + GetSearchId(); }
    Common.GetSearchSelector = GetSearchSelector;
    function GetContainerId() { return "divContent"; }
    Common.GetContainerId = GetContainerId;
    function GetContainerSelector() { return "#" + GetContainerId(); }
    Common.GetContainerSelector = GetContainerSelector;
    function GetSubContainerSelector() { return "#divSubContent"; }
    Common.GetSubContainerSelector = GetSubContainerSelector;
    function LoadContentWithSelector(pv_strURL, pv_strSelector, pv_objData) {
        LoadContentWithSelectorText(pv_strURL, pv_strSelector, pv_objData);
    }
    Common.LoadContentWithSelector = LoadContentWithSelector;
    function LoadContentWithSelectorText(pv_strURL, pv_strSelector, pv_objData) {
        LoadContentWithSelectorAndType(pv_strURL, pv_strSelector, pv_objData, Helpers.HttpRequests.GetContentTypeText());
    }
    Common.LoadContentWithSelectorText = LoadContentWithSelectorText;
    function LoadContentWithSelectorJSON(pv_strURL, pv_strSelector, pv_objData) {
        LoadContentWithSelectorAndType(pv_strURL, pv_strSelector, pv_objData, Helpers.HttpRequests.GetContentTypeJson());
    }
    Common.LoadContentWithSelectorJSON = LoadContentWithSelectorJSON;
    function LoadContentWithSelectorAndType(pv_strURL, pv_strSelector, pv_objData, pv_strContentType) {
        showPleaseWait();
        $(pv_strSelector).empty();
        var objRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strURL, pv_strContentType);
        objRequest.send(pv_objData);
        $(pv_strSelector).empty().append(objRequest.response);
        stopPleaseWait();
    }
    Common.LoadContentWithSelectorAndType = LoadContentWithSelectorAndType;
    function LoadContent(pv_strURL) {
        LoadContentWithSelector(pv_strURL, GetContainerSelector(), null);
        $('body').scrollTop(0).scrollLeft(0);
        $(GetContainerSelector()).scrollTop(0).scrollLeft(0);
        $(document).scrollTop(0).scrollLeft(0);
    }
    Common.LoadContent = LoadContent;
    function LoadSubContent(pv_strURL) {
        LoadContentWithSelector(pv_strURL, GetSubContainerSelector(), null);
    }
    Common.LoadSubContent = LoadSubContent;
    function showSubContent() {
        showPleaseWait();
        $(GetSubContainerSelector()).removeClass(m_strInvisibleClass);
        resizeSubContent();
        showContentCover();
        resizeContentCover();
        window.onresize = function () {
            resizePleaseWait();
            resizeSubContent();
            resizeContentCover();
        };
        stopPleaseWait();
    }
    Common.showSubContent = showSubContent;
    function hideSubContent() {
        $(GetSubContainerSelector()).addClass(m_strInvisibleClass);
        deleteContentCover();
    }
    Common.hideSubContent = hideSubContent;
    function showContentCover() {
        if ($(m_strCoverSelector).length < 1) {
            $('body').append('<div id="' + m_strCoverId + '"></div>');
        }
    }
    function resizeContentCover() {
        var intWidth = $(window).outerWidth();
        var intHeight = $(window).outerHeight();
        var intBodyWidth = $('body').outerWidth();
        var intBodyHeight = $('body').outerHeight();
        if (intBodyHeight > intHeight) {
            intHeight = intBodyHeight;
        }
        if (intBodyWidth > intWidth) {
            intWidth = intBodyWidth;
        }
        $(m_strCoverSelector).css({
            'width': intWidth + 'px',
            'height': intHeight + 'px'
        });
    }
    function deleteContentCover() { $(m_strCoverSelector).remove(); }
    function resizeSubContent() {
        var elSubContent = $(GetSubContainerSelector());
        if ((elSubContent.length > 0) && (elSubContent.hasClass(m_strInvisibleClass) == false)) {
            var intTop = $(document).scrollTop();
            if (elSubContent.parent().parent().attr('id') == GetContainerId()) {
                if (intTop < 60) {
                    intTop = 60;
                }
            }
            $(GetSubContainerSelector()).css({ 'top': intTop + 'px' });
        }
    }
    function AddCharacterToText(pv_strText, pv_intPosition, pv_strCharacter) {
        return pv_strText.substr(0, pv_intPosition) + pv_strCharacter + pv_strText.substring(pv_intPosition);
    }
    Common.AddCharacterToText = AddCharacterToText;
    function ActivateSearchDiv() {
        var elSearch;
        toggleSearch();
        elSearch = $(GetSearchSelector());
        if (elSearch.length > 0) {
            elSearch.click(toggleSearch);
        }
    }
    Common.ActivateSearchDiv = ActivateSearchDiv;
    function toggleSearch() {
        var elSearch = $(GetSearchContainerClassSelector());
        if (elSearch.hasClass(m_strInvisibleClass) === true) {
            elSearch.removeClass(m_strInvisibleClass);
            $(GetSearchSelector()).addClass(m_strInvisibleClass);
        }
        else {
            elSearch.addClass(m_strInvisibleClass);
            $(GetSearchSelector()).removeClass(m_strInvisibleClass);
        }
    }
    function Search(pv_strURL, pv_objSearch, pv_strTarget) {
        try {
            LoadContentWithSelectorJSON(pv_strURL, pv_strTarget, pv_objSearch);
        }
        catch (ex) {
            alert('Error while searching: ' + ex);
        }
        toggleSearch();
        stopPleaseWait();
    }
    Common.Search = Search;
    function FormatDate(pv_strDateString) {
        var strReturn = "";
        if (pv_strDateString.length > 0) {
            if (pv_strDateString.indexOf("+") != -1) {
                var arr1;
                if (pv_strDateString.charAt(0) == "+") {
                    strReturn = GetCurrentDateString();
                }
                strReturn = SplitDateByCharacterWithMultiplier(pv_strDateString, strReturn, ",");
                arr1 = strReturn.split(",");
                if (arr1[0].indexOf(".") != -1) {
                    strReturn = SplitDateByCharacterWithMultiplier(arr1[0], strReturn, ".");
                }
                else {
                    strReturn = SplitDateByCharacterWithMultiplier(strReturn, strReturn, ".");
                }
            }
            else {
                if (pv_strDateString.length < 4) {
                    strReturn = SplitDateByCharacterWithMultiplier(pv_strDateString, strReturn, ".");
                }
                if (pv_strDateString.length == 4) {
                    if (isNaN(Number(pv_strDateString)) == false) {
                        var arr = [pv_strDateString.slice(0, 2), pv_strDateString.slice(2, 4), new Date().getFullYear().toString()];
                        strReturn = ConvertDate(arr, strReturn, new DateMultiplier(0, "d"));
                    }
                }
                if (pv_strDateString.length == 6) {
                    if (isNaN(Number(pv_strDateString)) == false) {
                        var arr = new Array(pv_strDateString.slice(0, 2), pv_strDateString.slice(2, 4), (20 + Number(pv_strDateString.slice(4, 6))).toString());
                        strReturn = ConvertDate(arr, strReturn, new DateMultiplier(0, "d"));
                    }
                }
                if (pv_strDateString.length == 8) {
                    if (isNaN(Number(pv_strDateString)) == false) {
                        var arr = new Array(pv_strDateString.slice(0, 2), pv_strDateString.slice(2, 4), pv_strDateString.slice(4, 8));
                        strReturn = ConvertDate(arr, strReturn, new DateMultiplier(0, "d"));
                    }
                }
                strReturn = SplitDateByCharacter(pv_strDateString, strReturn, ",");
                strReturn = SplitDateByCharacter(pv_strDateString, strReturn, ".");
            }
        }
        return strReturn;
    }
    Common.FormatDate = FormatDate;
    function ConvertDate(pv_arrDate, pv_strDateString, pv_dmMultiplier) {
        var strErrorMessage = "Please check your entry: \n '01.09.2015' or '1.9.15' or '1,9,2015'";
        if (pv_arrDate.length != 3) {
            alert(strErrorMessage);
            return pv_strDateString;
        }
        else {
            var i;
            var intYear;
            var datDate;
            var intTemp;
            for (i = 0; i < pv_arrDate.length; i++) {
                if (isNaN(Number(pv_arrDate[i]))) {
                    alert(strErrorMessage);
                    return pv_strDateString;
                }
            }
            //Day
            if (pv_arrDate[0].length < 2) {
                pv_arrDate[0] = "0" + pv_arrDate[0];
            }
            else {
                if (Number(pv_arrDate[0]) > 31) {
                    alert(strErrorMessage);
                    return pv_strDateString;
                }
            }
            //Month
            if (pv_arrDate[1].length < 2) {
                pv_arrDate[1] = "0" + pv_arrDate[1];
            }
            else {
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
                }
                else {
                    if ((intYear >= 1753) && (intYear < 9999)) {
                        intYear = intYear;
                    }
                    else {
                        alert(strErrorMessage);
                        return pv_strDateString;
                    }
                }
            }
            else {
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
            }
            else {
                pv_strDateString += intTemp.toString();
            }
            pv_strDateString += ".";
            intTemp = datDate.getMonth() + 1;
            if (intTemp < 10) {
                pv_strDateString += "0" + intTemp.toString();
            }
            else {
                pv_strDateString += intTemp.toString();
            }
            pv_strDateString += "." + datDate.getFullYear().toString();
        }
        return pv_strDateString;
    }
    function GetDateMultiplier(pv_strDateString) {
        var dmMultiP;
        switch (pv_strDateString.charAt(pv_strDateString.length - 1).toUpperCase()) {
            case "W":
                pv_strDateString.replace("W", "");
                dmMultiP = new DateMultiplier(7, "d");
                break;
            case "M":
                pv_strDateString.replace("M", "");
                dmMultiP = new DateMultiplier(1, "m");
                break;
            case "J":
                pv_strDateString.replace("J", "");
                dmMultiP = new DateMultiplier(1, "y");
                break;
            default:
                pv_strDateString.replace("T", "");
                dmMultiP = new DateMultiplier(1, "T");
                break;
        }
        return dmMultiP;
    }
    function GetDayWithLeadingZero() {
        var intDay = new Date().getDate();
        if (intDay < 10) {
            return "0" + intDay.toString();
        }
        else {
            return intDay.toString();
        }
    }
    function GetMonthWithLeadingZero() {
        var intMonth = new Date().getMonth();
        if ((intMonth + 1) < 10) {
            return "0" + (intMonth + 1).toString();
        }
        else {
            return (intMonth + 1).toString();
        }
    }
    function GetFullYear() {
        return new Date().getFullYear().toString();
    }
    function GetCurrentDateString() {
        return GetDayWithLeadingZero() + "." + GetMonthWithLeadingZero() + "." + GetFullYear();
    }
    function Multiply(pv_objValueA, pv_objValueB) {
        var nmValueA = Number(pv_objValueA);
        var nmValueB = Number(pv_objValueB);
        if (!isNaN(nmValueA)) {
            if (!isNaN(nmValueB)) {
                return nmValueA * nmValueB;
            }
        }
        return 0;
    }
    function SplitDateByCharacter(pv_strDateString, pv_strReturnDate, pv_strCharacter) {
        if (pv_strDateString.indexOf(pv_strCharacter) != -1) {
            var arr = pv_strDateString.split(pv_strCharacter);
            if (arr.length == 2) {
                pv_strDateString += pv_strCharacter;
                arr = pv_strDateString.split(pv_strCharacter);
            }
            return ConvertDate(arr, pv_strReturnDate, new DateMultiplier(0, "d"));
        }
    }
    function SplitDateByCharacterWithMultiplier(pv_strDateString, pv_strReturnDate, pv_strCharacter) {
        var dmMulti = GetDateMultiplier(pv_strDateString);
        var arr1 = pv_strDateString.split("+");
        if (arr1[0].indexOf(pv_strCharacter) != -1) {
            var arr = arr1[0].split(pv_strCharacter);
            if (arr.length == 2) {
                arr1[0] += pv_strCharacter;
                arr = arr1[0].split(pv_strCharacter);
            }
            dmMulti.Multiplier = Multiply(dmMulti.Multiplier, arr1[1]);
            return ConvertDate(arr, pv_strReturnDate, dmMulti);
        }
    }
})(Common || (Common = {}));
//# sourceMappingURL=Common.js.map