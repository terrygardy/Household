/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />
var Expense;
(function (Expense_1) {
    var m_objExpense;
    var Expense = (function () {
        function Expense(pv_intID, pv_strStartDate, pv_strEndDate, pv_lngCompany, pv_lngBankAccount, pv_lngPaymentDay, pv_lngInterval, pv_decAmount, pv_strDescription, pv_strBaseAction) {
            this.ID = ko.observable(pv_intID);
            this.StartDate = ko.observable(pv_strStartDate);
            this.EndDate = ko.observable(pv_strEndDate);
            this.Company_ID = ko.observable(pv_lngCompany);
            this.BankAccount_ID = ko.observable(pv_lngBankAccount);
            this.PaymentDay_ID = ko.observable(pv_lngPaymentDay);
            this.Interval_ID = ko.observable(pv_lngInterval);
            this.Amount = ko.observable(pv_decAmount);
            this.Description = ko.observable(pv_strDescription);
            this.BaseAction = pv_strBaseAction;
            ko.applyBindings(this);
        }
        Expense.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Expense: this }), [this.StartDate(), this.EndDate(), getCurrentBankAccountText(), getCurrentCompanyText(), this.Amount() + ' €']);
        };
        Expense.prototype.Delete = function () {
            MasterData.deleteMasterRecord(this.BaseAction, this.ID());
        };
        return Expense;
    }());
    Expense_1.Expense = Expense;
    function Save() {
        this.m_objExpense.Save();
    }
    Expense_1.Save = Save;
    function Delete() {
        this.m_objExpense.Delete();
    }
    Expense_1.Delete = Delete;
    function Fill(pv_strBaseAction, pv_intID, pv_strStartDate, pv_strEndDate, pv_lngCompany, pv_lngBankAccount, pv_lngPaymentDay, pv_lngInterval, pv_decAmount, pv_strDescription) {
        this.m_objExpense = new Expense(pv_intID, pv_strStartDate, pv_strEndDate, pv_lngCompany, pv_lngBankAccount, pv_lngPaymentDay, pv_lngInterval, pv_decAmount, pv_strDescription, pv_strBaseAction);
    }
    Expense_1.Fill = Fill;
    function getCurrentCompanyText() {
        return $('#cboCompany option:selected').text();
    }
    function getCurrentBankAccountText() {
        var strBankAccount = $('#cboBankAccount option:selected').text();
        return strBankAccount.substring(0, strBankAccount.indexOf(":")).trim();
    }
    function start() {
        $('#tbxStartDate').focus();
    }
    Expense_1.start = start;
})(Expense || (Expense = {}));
//# sourceMappingURL=Expense.js.map