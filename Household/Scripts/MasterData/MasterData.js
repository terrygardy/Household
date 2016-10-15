/// <reference path="../typings/jquery/jquery.d.ts" />
/// <reference path="../Helpers/Common.ts" />
/// <reference path="../jquery-pleaseWait.ts" />
/// <reference path="../validation.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var MasterData;
(function (MasterData) {
    /**
     * Internals
     */
    var m_strTableId = "tblDisplay";
    var m_strTableSelector = "#" + m_strTableId;
    var Return = (function () {
        function Return() {
        }
        return Return;
    }());
    function toggleHideableColumns() {
        $("#tblDisplay").removeClass("w90");
        showHideables();
        var windowWidth = $(window).width();
        var tableWidth = $("#tblDisplay").width() + 10;
        if (tableWidth > windowWidth) {
            hideHideables();
        }
        else {
            tableWidth += $("#tblDisplay thead tr > th").width();
            if (tableWidth < windowWidth) {
                showHideables();
            }
        }
        $("#tblDisplay").addClass("w90");
    }
    function showHideables() {
        $("th.hideable").each(function () {
            $(this).show();
        });
        $("td.hideable").each(function () {
            $(this).show();
        });
    }
    function hideHideables() {
        $("th.hideable").each(function () {
            $(this).hide();
        });
        $("td.hideable").each(function () {
            $(this).hide();
        });
    }
    /**
     * Exports
     */
    MasterData.OnClickAdd = '';
    var BaseMasterData = (function () {
        function BaseMasterData(pv_objOptions) {
            this.ID = ko.observable(pv_objOptions.ID);
            this.BaseAction = pv_objOptions.BaseAction;
        }
        return BaseMasterData;
    }());
    MasterData.BaseMasterData = BaseMasterData;
    var BaseNameMasterData = (function (_super) {
        __extends(BaseNameMasterData, _super);
        function BaseNameMasterData(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.Name = ko.observable(pv_objOptions.Name);
        }
        return BaseNameMasterData;
    }(BaseMasterData));
    MasterData.BaseNameMasterData = BaseNameMasterData;
    var BaseNameDescMasterData = (function (_super) {
        __extends(BaseNameDescMasterData, _super);
        function BaseNameDescMasterData(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.Description = ko.observable(pv_objOptions.Description);
        }
        return BaseNameDescMasterData;
    }(BaseNameMasterData));
    MasterData.BaseNameDescMasterData = BaseNameDescMasterData;
    var BaseDescMasterData = (function (_super) {
        __extends(BaseDescMasterData, _super);
        function BaseDescMasterData(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.Description = ko.observable(pv_objOptions.Description);
        }
        return BaseDescMasterData;
    }(BaseMasterData));
    MasterData.BaseDescMasterData = BaseDescMasterData;
    function deleteRow(pv_intID) {
        var spFooter;
        $(m_strTableSelector + ' tbody tr[id="' + pv_intID.toString() + '"]').remove();
        updateFooterText(-1);
    }
    MasterData.deleteRow = deleteRow;
    function updateFooterText(pv_intDifference) {
        var spFooter = $('#spDisplayFoot');
        if (spFooter.length > 0) {
            var intCount = $(m_strTableSelector + ' tbody tr').length;
            spFooter.text("Count: " + intCount);
        }
    }
    MasterData.updateFooterText = updateFooterText;
    function replaceBodyRow(pv_strBaseURL, pv_intID) {
        $.ajax({
            method: "POST",
            url: pv_strBaseURL + "/GetTableBodyRow",
            data: { id: pv_intID },
            success: function (data) {
                var row = $('#' + pv_intID);
                if (row.length > 0) {
                    $(data).insertAfter(row);
                    row.remove();
                }
                else {
                    var target = $(m_strTableSelector + " tbody");
                    if (target.length < 1) {
                        $("<tbody></tbody>").insertAfter($(m_strTableSelector + " thead"));
                    }
                    target.append(data);
                }
                MasterData.replaceTableFooter(pv_strBaseURL);
                toggleHideableColumns();
            }
        });
    }
    MasterData.replaceBodyRow = replaceBodyRow;
    function replaceTableFooter(pv_strBaseURL) {
        $.ajax({
            method: "POST",
            url: pv_strBaseURL + "/GetTableFooter",
            data: {
                search: Common.GetSearchObject()
            },
            success: function (data) {
                var footer = $(m_strTableSelector + " tfoot");
                footer.empty();
                footer.html(data);
            }
        });
    }
    MasterData.replaceTableFooter = replaceTableFooter;
    function updateRow(pv_intID, pv_arrParams) {
        var arrChildren = $(m_strTableSelector + ' tbody tr[id="' + pv_intID.toString() + '"]').children();
        if (arrChildren.length < 1) {
            var strTr = '<tr id="' + pv_intID.toString() + '"';
            if (this.OnClickAdd.length > 0) {
                strTr += ' class="clickable" onclick="Common.LoadSubContent(\'' + this.OnClickAdd + '/' + pv_intID.toString() + '\');Common.showSubContent();" ';
            }
            strTr += '>';
            for (var i = 0; i < pv_arrParams.length; i++) {
                strTr += "<td></td>";
            }
            strTr += "</tr>";
            if ($(m_strTableSelector + ' tbody').length < 1) {
                $('<tbody></tbody>').insertAfter($(m_strTableSelector + ' thead'));
            }
            $(m_strTableSelector + ' tbody').append(strTr);
            arrChildren = $(m_strTableSelector + ' tbody tr[id="' + pv_intID.toString() + '"]').children();
            updateFooterText(1);
            toggleHideableColumns();
        }
        for (var i = 0; i < pv_arrParams.length; i++) {
            if (arrChildren.length >= i) {
                $(arrChildren[i]).text(pv_arrParams[i]);
            }
        }
    }
    MasterData.updateRow = updateRow;
    function deleteMasterRecord(pv_objOptions, replaceFooter) {
        showPleaseWait();
        try {
            var objRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_objOptions.BaseAction + '/Delete/' + pv_objOptions.ID.toString(), Helpers.HttpRequests.GetContentTypeForm());
            var strReturn;
            objRequest.send();
            strReturn = objRequest.response;
            if (strReturn.length > 0) {
                alert(strReturn);
            }
            else {
                MasterData.deleteRow(pv_objOptions.ID);
                if (replaceFooter === true) {
                    MasterData.replaceTableFooter(pv_objOptions.BaseAction);
                }
                Common.hideSubContent();
            }
        }
        catch (ex) { }
        stopPleaseWait();
    }
    MasterData.deleteMasterRecord = deleteMasterRecord;
    function saveMasterRecord(pv_strBaseURL, pv_objData, pv_arrDisplayCells) {
        var strReturn = saveMasterRecordWithMessage(pv_strBaseURL, pv_objData, pv_arrDisplayCells, true);
        if (strReturn.length > 0) {
            alert(strReturn);
        }
    }
    MasterData.saveMasterRecord = saveMasterRecord;
    function saveMasterRecordWithMessage(pv_strBaseURL, pv_objData, pv_arrDisplayCells, pv_blnClose) {
        var strValidate = MasterData.isFormValid();
        if (strValidate !== '') {
            return strValidate;
        }
        else {
            showPleaseWait();
            try {
                var objRequest = Helpers.HttpRequests.CreateSyncRequestHandlerPOST(pv_strBaseURL + '/Save/', Helpers.HttpRequests.GetContentTypeJson());
                var objReturn;
                objRequest.send(pv_objData);
                objReturn = JSON.parse(objRequest.response);
                if (objReturn.Message.length > 0) {
                    return objReturn.Message;
                }
                else {
                    if (pv_arrDisplayCells !== null) {
                        MasterData.updateRow(objReturn.ID, pv_arrDisplayCells);
                    }
                    else {
                        MasterData.replaceBodyRow(pv_strBaseURL, objReturn.ID);
                    }
                    if (pv_blnClose === true) {
                        $('#btnClose').click();
                    }
                }
            }
            catch (ex) {
                return 'Save was unsuccessful: ' + ex;
            }
            finally {
                stopPleaseWait();
            }
            return '';
        }
    }
    MasterData.saveMasterRecordWithMessage = saveMasterRecordWithMessage;
    function isFormValid() {
        if (MasterData.isValid('form') === true) {
            return '';
        }
        else {
            return 'Some or all of your entries are invalid.';
        }
    }
    MasterData.isFormValid = isFormValid;
    function isValid(pv_strSelector) {
        return $(pv_strSelector).valid();
    }
    MasterData.isValid = isValid;
    function start() {
        var olBC = $('form').children('#olBC_MasterData');
        $(':text').each(function () {
            $(this).change(function () {
                $(this).val($(this).val().trim());
            });
        });
        $('input:text:not(textarea)').each(function () {
            $(this).keyup(function (e) {
                if (e.keyCode == 13) {
                    $('#btnSave').click();
                }
                else {
                    if (e.keyCode == 27) {
                        $('#btnClose').click();
                    }
                }
            });
        });
        if ((olBC.length > 0) && (olBC.children().length < 1)) {
            olBC.remove();
        }
        Validation.validateForm();
    }
    MasterData.start = start;
    function setupHideables() {
        toggleHideableColumns();
        $(window).resize(toggleHideableColumns);
    }
    MasterData.setupHideables = setupHideables;
})(MasterData || (MasterData = {}));
//# sourceMappingURL=MasterData.js.map