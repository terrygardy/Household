/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var WorkDay;
(function (WorkDay_1) {
    var m_objWorkDay;
    var WorkDay = (function (_super) {
        __extends(WorkDay, _super);
        function WorkDay(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.WorkDay = ko.observable(pv_objOptions.WorkDay);
            this.Begin = ko.observable(pv_objOptions.Begin);
            this.End = ko.observable(pv_objOptions.End);
            this.BreakDuration = ko.observable(pv_objOptions.BreakDuration);
            ko.applyBindings(this);
        }
        WorkDay.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.WorkDay(), this.Begin(), this.End(), this.BreakDuration()]);
        };
        WorkDay.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
        };
        return WorkDay;
    }(MasterData.BaseMasterData));
    WorkDay_1.WorkDay = WorkDay;
    function Save() {
        this.m_objWorkDay.Save();
    }
    WorkDay_1.Save = Save;
    function Delete() {
        this.m_objWorkDay.Delete();
    }
    WorkDay_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strWorkDay, pv_strBegin, pv_strEnd, pv_decBreakDuration) {
        this.m_objWorkDay = new WorkDay({
            ID: pv_intID,
            WorkDay: pv_strWorkDay,
            Begin: pv_strBegin,
            End: pv_strEnd,
            BreakDuration: pv_decBreakDuration,
            BaseAction: pv_strBaseAction
        });
    }
    WorkDay_1.Fill = Fill;
    function Start() {
        $('#tbxWorkDay').focus();
    }
    WorkDay_1.Start = Start;
})(WorkDay || (WorkDay = {}));
//# sourceMappingURL=WorkHours.js.map