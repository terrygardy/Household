/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="MasterData.ts" />
/// <reference path="Company.ts" />
var Income;
(function (Income_1) {
    var m_objIncome;
    var Income = (function () {
        function Income(pv_intID, pv_strStartDate, pv_strEndDate, pv_intInterval, pv_intDay, pv_intPayee, pv_intCompany, pv_decAmount, pv_strDescription, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.StartDate = ko.observable(pv_strStartDate);
            this.EndDate = ko.observable(pv_strEndDate);
            this.Interval_ID = ko.observable(pv_intInterval);
            this.Day_ID = ko.observable(pv_intDay);
            this.Payee_ID = ko.observable(pv_intPayee);
            this.Company_ID = ko.observable(pv_intCompany);
            this.Amount = ko.observable(pv_decAmount);
            this.Description = ko.observable(pv_strDescription);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Income.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Income: this }), [this.StartDate(), this.EndDate(), this.Amount() + ' €', getCurrentCompanyText()]);
        };
        Income.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Income;
    }());
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
        this.m_objIncome = new Income(pv_intID, pv_strStartDate, pv_strEndDate, pv_intInterval, pv_intDay, pv_intPayee, pv_intCompany, pv_decAmount, pv_strDescription, pv_strBaseAction);
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