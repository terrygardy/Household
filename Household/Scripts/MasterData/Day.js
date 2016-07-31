/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Day;
(function (Day_1) {
    var m_objDay;
    var Day = (function (_super) {
        __extends(Day, _super);
        function Day(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.Day = ko.observable(pv_objOptions.Day);
            ko.applyBindings(this);
        }
        Day.prototype.Save = function (pv_blnClose) {
            return MasterData.saveMasterRecordWithMessage(this.BaseAction, ko.toJSON({ Day: this }), [this.Day()], pv_blnClose);
        };
        Day.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
        };
        return Day;
    }(MasterData.BaseMasterData));
    Day_1.Day = Day;
    function SaveSingle() {
        if (m_objDay == null) {
            alert('The current day has not been set');
        }
        else {
            var strReturn = m_objDay.Save(true);
            if (strReturn.length > 0) {
                alert(strReturn);
            }
        }
    }
    Day_1.SaveSingle = SaveSingle;
    function Save() {
        if ($('#divMultiple').hasClass('invisible') == true) {
            SaveSingle();
        }
        else {
            var intStart = Number($('#tbxStart').val());
            var intEnd = Number($('#tbxEnd').val());
            if (intStart < 1) {
                intStart = 1;
            }
            if (intEnd < 1) {
                intEnd = 1;
            }
            if (intEnd < intStart) {
                alert('The entered time window is invalid');
            }
            else {
                var strBaseAction = m_objDay.BaseAction;
                var strMessage = '';
                for (var i = intStart; i <= intEnd; i++) {
                    var strReturn;
                    Fill(strBaseAction, 0, i);
                    strReturn = m_objDay.Save((i == intEnd));
                    if ((strReturn.length > 0) && (strMessage.indexOf(strReturn) < 0)) {
                        strMessage += '\n' + strReturn;
                    }
                }
                if (strMessage.length > 0) {
                    alert(strMessage);
                }
            }
        }
    }
    Day_1.Save = Save;
    function Delete() {
        m_objDay.Delete();
    }
    Day_1.Delete = Delete;
    function ShowMultiple() {
        $('#divMultiple').removeClass('invisible');
        $('#divInput').addClass('invisible');
    }
    Day_1.ShowMultiple = ShowMultiple;
    function HideMultiple() {
        $('#divMultiple').addClass('invisible');
        $('#divInput').removeClass('invisible');
    }
    Day_1.HideMultiple = HideMultiple;
    function Fill(pv_strBaseAction, pv_intID, pv_intDay) {
        if (m_objDay == null) {
            m_objDay = new Day({
                ID: pv_intID,
                Day: pv_intDay,
                BaseAction: pv_strBaseAction
            });
        }
        else {
            m_objDay.BaseAction = pv_strBaseAction;
            m_objDay.Day(pv_intDay);
            m_objDay.ID(pv_intID);
        }
    }
    Day_1.Fill = Fill;
    function start() {
        $('#tbxDay').focus();
    }
    Day_1.start = start;
})(Day || (Day = {}));
//# sourceMappingURL=Day.js.map