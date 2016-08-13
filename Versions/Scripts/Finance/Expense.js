/// <reference path="../typings/knockout/knockout.d.ts" />
/// <reference path="../Helpers/httprequest.ts" />
/// <reference path="../MasterData/MasterData.ts" />
var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var Expense;
(function (Expense_1) {
    var m_objExpense;
    var Expense = (function (_super) {
        __extends(Expense, _super);
        function Expense(pv_objOptions) {
            _super.call(this, pv_objOptions);
            this.StartDate = ko.observable(pv_objOptions.StartDate);
            this.EndDate = ko.observable(pv_objOptions.EndDate);
            this.Company_ID = ko.observable(pv_objOptions.Company_ID);
            this.BankAccount_ID = ko.observable(pv_objOptions.BankAccount_ID);
            this.PaymentDay_ID = ko.observable(pv_objOptions.PaymentDay_ID);
            this.Interval_ID = ko.observable(pv_objOptions.Interval_ID);
            this.Amount = ko.observable(pv_objOptions.Amount);
            ko.applyBindings(this);
        }
        Expense.prototype.Save = function () {
            MasterData.saveMasterRecord(this.BaseAction, ko.toJSON({ Data: this }), [this.StartDate(), this.EndDate(), getCurrentBankAccountText(), getCurrentCompanyText(), this.Amount() + ' €']);
        };
        Expense.prototype.Delete = function () {
            MasterData.deleteMasterRecord({ BaseAction: this.BaseAction, ID: this.ID() });
        };
        return Expense;
    }(MasterData.BaseMasterData));
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
        this.m_objExpense = new Expense({
            ID: pv_intID,
            StartDate: pv_strStartDate,
            EndDate: pv_strEndDate,
            Company_ID: pv_lngCompany,
            BankAccount_ID: pv_lngBankAccount,
            PaymentDay_ID: pv_lngPaymentDay,
            Interval_ID: pv_lngInterval,
            Amount: pv_decAmount,
            Description: pv_strDescription,
            BaseAction: pv_strBaseAction
        });
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