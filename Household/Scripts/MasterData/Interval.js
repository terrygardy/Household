/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Interval;
(function (Interval_1) {
    var m_objInterval;
    var Interval = (function (_super) {
        __extends(Interval, _super);
        function Interval(pv_objOptions) {
            var _this = _super.call(this, pv_objOptions) || this;
            ko.applyBindings(_this);
            return _this;
        }
        Interval.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.Name()]);
        };
        Interval.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() }, false);
        };
        return Interval;
    }(MasterData.BaseNameMasterData));
    Interval_1.Interval = Interval;
    function Save() {
        this.m_objInterval.Save();
    }
    Interval_1.Save = Save;
    function Delete() {
        this.m_objInterval.Delete();
    }
    Interval_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strName) {
        this.m_objInterval = new Interval({ ID: pv_intID, Name: pv_strName, BaseAction: pv_strBaseAction });
    }
    Interval_1.Fill = Fill;
    function start() {
        $('#tbxName').focus();
    }
    Interval_1.start = start;
})(Interval || (Interval = {}));
//# sourceMappingURL=Interval.js.map