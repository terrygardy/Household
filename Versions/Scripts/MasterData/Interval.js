/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
var Interval;
(function (Interval_1) {
    var m_objInterval;
    var Interval = (function () {
        function Interval(pv_intID, pv_strName, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.Name = ko.observable(pv_strName);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Interval.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Interval: this }), [this.Name()]);
        };
        Interval.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Interval;
    }());
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
        this.m_objInterval = new Interval(pv_intID, pv_strName, pv_strBaseAction);
    }
    Interval_1.Fill = Fill;
    function start() {
        $('#tbxName').focus();
    }
    Interval_1.start = start;
})(Interval || (Interval = {}));
//# sourceMappingURL=Interval.js.map