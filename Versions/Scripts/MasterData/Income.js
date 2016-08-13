/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
/// <reference path="Company.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Income;
(function (Income_1) {
    var m_objIncome;
    var Income = (function (_super) {
        __extends(Income, _super);
        function Income(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.StartDate = ko.observable(pv_objOptions.StartDate);
            this.EndDate = ko.observable(pv_objOptions.EndDate);
            this.Interval_ID = ko.observable(pv_objOptions.Interval_ID);
            this.Day_ID = ko.observable(pv_objOptions.Day_ID);
            this.Payee_ID = ko.observable(pv_objOptions.Payee_ID);
            this.Company_ID = ko.observable(pv_objOptions.Company_ID);
            this.Amount = ko.observable(pv_objOptions.Amount);
            ko.applyBindings(this);
        }
        Income.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Income: this }), [this.StartDate(), this.EndDate(), this.Amount() + ' €', getCurrentCompanyText()]);
        };
        Income.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
        };
        return Income;
    }(MasterData.BaseDescMasterData));
    Income_1.Income = Income;
    function Save() {
        this.m_objIncome.Save();
    }
    Income_1.Save = Save;
    function Delete() {
        this.m_objIncome.Delete();
    }
    Income_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strStartDate, pv_strEndDate, pv_intInterval, pv_intDay, pv_intPayee, pv_intCompany, pv_decAmount, pv_strDescription) {
        this.m_objIncome = new Income({
            ID: pv_intID,
            Description: pv_strDescription,
            BaseAction: pv_strBaseAction,
            StartDate: pv_strStartDate,
            EndDate: pv_strEndDate,
            Interval_ID: pv_intInterval,
            Day_ID: pv_intDay,
            Payee_ID: pv_intPayee,
            Company_ID: pv_intCompany,
            Amount: pv_decAmount
        });
    }
    Income_1.Fill = Fill;
    function getCurrentCompanyText() {
        return $('#cboCompany option:selected').text();
    }
    function start() {
        $('#tbxStartDate').focus();
    }
    Income_1.start = start;
})(Income || (Income = {}));
//# sourceMappingURL=Income.js.map